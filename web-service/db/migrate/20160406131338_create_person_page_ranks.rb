class CreatePersonPageRanks < ActiveRecord::Migration
  def change
    create_table :person_page_ranks do |t|
      t.integer :rank
      t.references :person, index: true
      t.references :page, index: true
      t.timestamps null: false
    end
    add_foreign_key :person_page_ranks, :pages
    add_foreign_key :person_page_ranks, :persons
  end
end
