class CreateKeywords < ActiveRecord::Migration
  def change
    create_table :keywords do |t|
      t.string :name
      t.references :person, index: true
      t.timestamps null: false
    end
    add_foreign_key :keywords, :persons
  end
end
