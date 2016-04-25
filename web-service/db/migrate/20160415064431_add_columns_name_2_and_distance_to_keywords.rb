class AddColumnsName2AndDistanceToKeywords < ActiveRecord::Migration
  def change
    add_column :keywords, :name_2,   :string
    add_column :keywords, :distance, :integer
  end
end
