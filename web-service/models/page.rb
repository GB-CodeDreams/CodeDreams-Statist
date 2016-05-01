class Page < ActiveRecord::Base
  has_many    :person_page_ranks, dependent: :destroy
  belongs_to  :site
  validates   :url, format: { with: /\A#{URI::regexp(['http', 'https'])}\z/, message: "Invalid URL format" }
  validates   :url, :site_id, presence: true

  scope :last_scan, -> {
    maximum("last_scan_date")
  }
end
