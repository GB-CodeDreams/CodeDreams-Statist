class Keyword < ActiveRecord::Base
  belongs_to :person, class_name: "Persons"
end
