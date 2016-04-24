# пришлось называть таблицу во множественном числе, иначе activerecord
# ищет таблицу people вместо persons
class Person < ActiveRecord::Base
  self.table_name = "persons"
  has_many :keywords, dependent: :destroy
  has_many :person_page_ranks, dependent: :destroy

  validates_presence_of :name
end
