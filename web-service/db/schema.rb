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

ActiveRecord::Schema.define(version: 20160406091931) do

  create_table "keywords", force: :cascade do |t|
    t.string   "name"
    t.integer  "person_id"
    t.datetime "created_at", null: false
    t.datetime "updated_at", null: false
  end

  add_index "keywords", ["person_id"], name: "index_keywords_on_person_id"

  create_table "pages", force: :cascade do |t|
    t.string   "url"
    t.datetime "found_date_time"
    t.datetime "last_scan_date"
    t.integer  "site_id"
    t.datetime "created_at",      null: false
    t.datetime "updated_at",      null: false
  end

  add_index "pages", ["found_date_time"], name: "index_pages_on_found_date_time"
  add_index "pages", ["last_scan_date"], name: "index_pages_on_last_scan_date"
  add_index "pages", ["site_id"], name: "index_pages_on_site_id"

  create_table "person_page_ranks", force: :cascade do |t|
    t.integer  "rank"
    t.integer  "person_id"
    t.integer  "page_id"
    t.datetime "created_at", null: false
    t.datetime "updated_at", null: false
  end

  add_index "person_page_ranks", ["page_id"], name: "index_person_page_ranks_on_page_id"
  add_index "person_page_ranks", ["person_id"], name: "index_person_page_ranks_on_person_id"

  create_table "persons", force: :cascade do |t|
    t.string   "name"
    t.datetime "created_at"
    t.datetime "updated_at"
  end

  create_table "sites", force: :cascade do |t|
    t.string   "name"
    t.datetime "created_at", null: false
    t.datetime "updated_at", null: false
  end

end
