class CreateUser < ActiveRecord::Migration
  def change
    create_table :users do |t|
      t.string  :username
      t.string  :password
      t.integer :admin, limit: 1, default: 0
    end
  end
end
