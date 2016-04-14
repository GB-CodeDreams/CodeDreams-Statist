class PersonPageRank < ActiveRecord::Base
  belongs_to :person
  belongs_to :page

  scope :site_persons_rank, ->(site) {
    person_rank = %{
      SELECT sum(r.rank) as rank, per.name as query_word, s_p.name as site, max(s_p.last_scan_date) as last_scan_date
      FROM   person_page_ranks r
      JOIN   persons per ON r.person_id = per.id
    }.gsub(/\s+/, ' ').strip

    site_pages = %{
      SELECT s.name, p.id, p.last_scan_date FROM sites AS s
      INNER JOIN pages AS p ON s.id = p.site_id
      WHERE (s.name = '#{site}')
    }.gsub(/\s+/, ' ').strip

    find_by_sql("#{person_rank} JOIN (#{site_pages}) as s_p ON s_p.id = r.page_id GROUP BY query_word ORDER BY rank DESC")
  }

  scope :day_statistic, ->(site, query_word, start_date, end_date) {
    result = ''
    clear_error
    validate_date(start_date, end_date)
    if valid_date?
      person_rank = %{
        SELECT sum(r.rank) as rank, s_p.date
        FROM   person_page_ranks r
        JOIN   persons per ON r.person_id = per.id
      }.gsub(/\s+/, ' ').strip

      site_pages = %{
        SELECT      s.name, p.id, p.last_scan_date as date
        FROM        sites AS s
        INNER JOIN  pages AS p ON s.id = p.site_id
        WHERE       (s.name = '#{site}'
          AND p.last_scan_date BETWEEN STR_TO_DATE('#{start_date}', '%Y-%m-%d %H:%i:%s')
          AND STR_TO_DATE('#{end_date}', '%Y-%m-%d %H:%i:%s'))
      }.gsub(/\s+/, ' ').strip

      result = find_by_sql("#{person_rank} JOIN (#{site_pages}) as s_p ON s_p.id = r.page_id WHERE (per.name = '#{query_word}') GROUP BY s_p.date ORDER BY s_p.date DESC")
      sum = result.inject(0){|start, next_item| start + next_item.rank}
      result << {total_rank: sum}
    else
      result = error
    end
    result
  }

  def self.hash_result_without_id(query_result)
    query_result.map do |string|
      hash = JSON.parse(string.to_json)
      hash.delete('id')
      hash
    end
  end

  def self.validate_date(start_date, end_date)
    begin
      start_date = start_date.to_datetime
      end_date = end_date.to_datetime
      @error = [{error: "no statistic for that period" }] if start_date > Page.last_scan
      @error = [{error: "start_date more then end_date"}] if start_date > end_date
    rescue ArgumentError => e
      @error = [{error: e.message }]
    end
  end

  def self.valid_date?
    @error.nil?
  end

  def self.clear_error
    @error = nil
  end

  def self.error
    @error
  end

end
