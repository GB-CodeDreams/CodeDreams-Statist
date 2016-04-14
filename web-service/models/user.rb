class User < ActiveRecord::Base
  has_many :persons, dependent: :destroy
  has_many :sites,   dependent: :destroy
  
  validates :username, presence: true
  validates :password, presence: true
end