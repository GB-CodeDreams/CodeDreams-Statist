class CreatePages < ActiveRecord::Migration
  def change
    create_table :pages do |t|
      t.string     :url
      t.datetime   :found_date_time,   index:true
      t.datetime   :last_scan_date,    index:true

      t.timestamps null: false
    end
  end
end
