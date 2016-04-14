class User < ActiveRecord::Base
  has_many :persons
  has_many :sites
  
  validates :username, presence: true
  validates :password, presence: true
end