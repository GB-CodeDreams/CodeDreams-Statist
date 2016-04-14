# encoding: UTF-8
# This file is auto-generated from the current state of the database. Instead
# of editing this file, please use the migrations feature of Active Record to
# incrementally modify your database, and then regenerate this schema definition.
#
# Note that this schema.rb definition is the authoritative source for your
# database schema. If you need to create the application database on another
# system, you should be using db:schema:load, not running all the migrations
# from scratch. The latter is a flawed and unsustainable approach (the more migrations
# you'll amass, the slower it'll run and the greater likelihood for issues).
#
# It's strongly recommended that you check this file into your version control system.

ActiveRecord::Schema.define(version: 20160414072207) do

  create_table "keywords", force: :cascade do |t|
    t.string   "name",       limit: 255
    t.integer  "person_id",  limit: 4
    t.datetime "created_at",             null: false
    t.datetime "updated_at",             null: false
  end

  add_index "keywords", ["person_id"], name: "index_keywords_on_person_id", using: :btree

  create_table "pages", force: :cascade do |t|
    t.string   "url",             limit: 255
    t.datetime "found_date_time"
    t.datetime "last_scan_date"
    t.datetime "created_at",                  null: false
    t.datetime "updated_at",                  null: false
    t.integer  "site_id",         limit: 4
  end

  add_index "pages", ["found_date_time"], name: "index_pages_on_found_date_time", using: :btree
  add_index "pages", ["last_scan_date"], name: "index_pages_on_last_scan_date", using: :btree
  add_index "pages", ["site_id"], name: "index_pages_on_site_id", using: :btree

  create_table "person_page_ranks", force: :cascade do |t|
    t.integer  "rank",       limit: 4
    t.integer  "person_id",  limit: 4
    t.integer  "page_id",    limit: 4
    t.datetime "created_at",           null: false
    t.datetime "updated_at",           null: false
  end

  add_index "person_page_ranks", ["page_id"], name: "index_person_page_ranks_on_page_id", using: :btree
  add_index "person_page_ranks", ["person_id"], name: "index_person_page_ranks_on_person_id", using: :btree

  create_table "persons", force: :cascade do |t|
    t.string   "name",       limit: 255
    t.datetime "created_at"
    t.datetime "updated_at"
    t.integer  "user_id",    limit: 4
  end

  add_index "persons", ["user_id"], name: "index_persons_on_user_id", using: :btree

  create_table "sites", force: :cascade do |t|
    t.string   "name",       limit: 255
    t.datetime "created_at",             null: false
    t.datetime "updated_at",             null: false
    t.integer  "user_id",    limit: 4
  end

  add_index "sites", ["user_id"], name: "index_sites_on_user_id", using: :btree

  create_table "users", force: :cascade do |t|
    t.string  "username", limit: 255
    t.string  "password", limit: 255
    t.integer "admin",    limit: 1,   default: 0
  end

  add_foreign_key "keywords", "persons"
  add_foreign_key "pages", "sites"
  add_foreign_key "person_page_ranks", "pages"
  add_foreign_key "person_page_ranks", "persons"
  add_foreign_key "persons", "users"
  add_foreign_key "sites", "users"
end
