class Site < ActiveRecord::Base
  has_many   :pages
  belongs_to :user
  validates :name, presence: true
end