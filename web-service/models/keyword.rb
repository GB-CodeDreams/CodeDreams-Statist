class Keyword < ActiveRecord::Base
  belongs_to :person
  validates :name,      presence: true
  validates :person_id, presence: true
end
