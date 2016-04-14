require "digest/md5"

class User < ActiveRecord::Base

  SALT = "geekbrains"

  has_many :persons, dependent: :destroy
  has_many :sites,   dependent: :destroy

  validates :username, presence: true
  validates :password, presence: true, length: {minimum: 6}

  before_create :password_to_md5

  def password_to_md5
    self.password = Digest::MD5.hexdigest(password + SALT)
  end

  def admin?
    self.admin
  end
end
