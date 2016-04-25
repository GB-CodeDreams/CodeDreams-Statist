require "digest/md5"

class User < ActiveRecord::Base

  SALT = "geekbrains"

  email_regex = /\A([\w+\-]\.?)+@[a-z\d\-]+(\.[a-z]+)*\.[a-z]+\z/i

  has_many :persons, dependent: :destroy
  has_many :sites,   dependent: :destroy

  validates :username, presence:   true
  validates :username, uniqueness: true
  validates :username, format:   { with: email_regex, message: "Username must be of email format (yourname@example.com)" }
  validates :password, presence:   true, length: {minimum: 6}

  before_save :password_to_md5, if: Proc.new {|user| user.password_changed? }

  def password_to_md5
    self.password = Digest::MD5.hexdigest(password + SALT + self.username)
  end

  def admin?
    self.admin
  end
end
