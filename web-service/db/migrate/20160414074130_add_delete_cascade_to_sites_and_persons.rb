class AddDeleteCascadeToSitesAndPersons < ActiveRecord::Migration
  def change
    remove_foreign_key :persons, :users
    remove_foreign_key :sites,   :users
    add_foreign_key    :persons, :users, on_delete: :cascade
    add_foreign_key    :sites,   :users, on_delete: :cascade
  end
end
