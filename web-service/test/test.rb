require_relative "../app"
require 'minitest/autorun'
require "rack/test"

set :environmets, :test

class UserTest < Minitest::Test
  include Rack::Test::Methods

  def app
    Sinatra::Application
  end
  
  def test_list_users
    admin = User.find_by(admin: true)
    get "/users", token: admin.password
    assert last_response.ok?
    assert last_response.body.include? 'username'
    assert last_response.body.include? 'id'
    assert last_response.body.include? 'token'
  end
  
  def test_list_users_permission_error
    user = User.find_by(admin: false)
    get "/users", token: user.password
    assert last_response.forbidden?
    assert last_response.body.include? 'Permission error'
  end
end