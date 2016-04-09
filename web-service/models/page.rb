class Page < ActiveRecord::Base
  has_many    :person_page_ranks, dependent: :destroy
  belongs_to  :site
  validates_presence_of :url, :site_id

  scope :last_scan, -> {
    maximum("last_scan_date")
  }
end
