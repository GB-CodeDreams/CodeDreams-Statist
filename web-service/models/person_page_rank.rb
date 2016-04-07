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

    find_by_sql("#{person_rank} JOIN (#{site_pages}) as s_p ON s_p.id = r.page_id GROUP BY query_word")
  }

  scope :day_statistic, ->(site, person, start_date, end_date) {
    person_rank = %{
      SELECT sum(r.rank) as rank, per.name as query_word, s_p.name as site, s_p.date
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

    find_by_sql("#{person_rank} JOIN (#{site_pages}) as s_p ON s_p.id = r.page_id WHERE (per.name = '#{person}') GROUP BY s_p.date ORDER BY s_p.date DESC")
  }

  def self.hash_result_without_id(query_result)
    query_result.map do |string|
      hash = JSON.parse(string.to_json)
      hash.delete('id')
      hash
    end
  end


end
