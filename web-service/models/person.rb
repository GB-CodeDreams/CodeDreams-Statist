class Persons < ActiveRecord::Base
  has_many :keywords
  has_many :person_page_rank
  
  validates_presence_of :name
end
