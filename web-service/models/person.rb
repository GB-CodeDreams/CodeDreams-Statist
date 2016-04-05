# пришлось называть таблицу во множественном числе, иначе activerecord
# ищет таблицу people вместо persons
class Persons < ActiveRecord::Base
  has_many :keywords, foreign_key: "person_id", dependent: :destroy
  has_many :person_page_rank, foreign_key: "person_id", dependent: :destroy

  validates_presence_of :name
end
