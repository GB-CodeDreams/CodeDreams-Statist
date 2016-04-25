class AddUserIdColumnToPersons < ActiveRecord::Migration
  def change
    add_reference   :persons, :user, index: true
    add_foreign_key :persons, :users 
  end
end
