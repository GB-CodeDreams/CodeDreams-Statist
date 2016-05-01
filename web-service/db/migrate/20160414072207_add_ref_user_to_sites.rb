class AddRefUserToSites < ActiveRecord::Migration
  def change
    add_reference   :sites, :user, index: true
    add_foreign_key :sites, :users
  end
end
