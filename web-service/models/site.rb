class Site < ActiveRecord::Base
  has_many   :pages
  belongs_to :user

  validates  :name,    presence: true
  validates  :user_id, presence: true
end
