class Page < ActiveRecord::Base
  has_many    :person_page_ranks, dependent: :destroy
  belongs_to  :site
end
