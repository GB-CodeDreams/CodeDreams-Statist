class RenamePersonPageRank < ActiveRecord::Migration
  def change
    rename_table :person_page_rank, :person_page_ranks
  end
end
