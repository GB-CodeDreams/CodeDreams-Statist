class AddSiteRefToPages < ActiveRecord::Migration
  def change
    add_reference   :pages, :site, index: true
    add_foreign_key :pages, :sites
  end
end
