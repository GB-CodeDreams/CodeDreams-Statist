class PersonPageRank < ActiveRecord::Base
  belongs_to :person, class_name: "Persons"
  belongs_to :page
end
