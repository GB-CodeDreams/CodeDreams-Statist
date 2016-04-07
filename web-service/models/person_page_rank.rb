class PersonPageRank < ActiveRecord::Base
  belongs_to :person
  belongs_to :page

  scope :site_persons_rank, ->(site) {
    person_rank = "SELECT sum(r.rank) as rank, per.name as person_name, s_p.name as site_name FROM person_page_ranks r JOIN persons per ON r.person_id = per.id"
    site_pages = "SELECT s.name, p.id FROM sites AS s INNER JOIN pages AS p ON s.id = p.site_id WHERE (s.name = '#{site}')"
    find_by_sql("#{person_rank} JOIN (#{site_pages}) as s_p ON s_p.id = r.page_id GROUP BY site_name, person_name")
  }

  def self.hash_result_without_id(query_result)
    query_result.map do |string|
      hash = JSON.parse(string.to_json)
      hash.delete('id')
      hash
    end
  end

end