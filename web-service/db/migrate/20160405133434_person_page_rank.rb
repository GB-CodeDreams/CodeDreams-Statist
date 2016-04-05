class PersonPageRank < ActiveRecord::Migration
  def change
    create_table :person_page_rank do |t|
      t.integer :rank
      t.references :person, index: true
      t.references :page, index: true
      t.timestamps null: false
    end
    add_foreign_key :person_page_rank, :pages
    add_foreign_key :person_page_rank, :persons
  end
end
