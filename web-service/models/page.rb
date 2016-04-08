class Page < ActiveRecord::Base
  has_many    :person_page_ranks, dependent: :destroy
  belongs_to  :site
  
  scope :last_scan, -> {
    maximum("last_scan_date")
  }
end
