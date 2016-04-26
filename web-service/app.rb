require 'sinatra'
require "sinatra/activerecord"
require 'json'
require 'pony'
require './config/pony_config'
require './environments'
require './controller/helper'
require './controller/filters'
require './controller/users_controller'
require './controller/persons_controller'
require './controller/keywords_controller'
require './controller/sites_controller'
require './models/user'
require './models/person'
require './models/keyword'
require './models/person_page_rank'
require './models/page'
require './models/site'
require './repository/lib/repository'

get '/total_statistic' do
  site = params[:site]
  if site
    result = PersonPageRank.site_persons_rank(site)
    PersonPageRank.hash_result_without_id(result).to_json
  end
end

get '/day_statistic' do
  query = [params["site"], params["query_word"], params["start_date"], params["end_date"]].compact
  if query.length == 4
    result = PersonPageRank.day_statistic(*query)
    PersonPageRank.hash_result_without_id(result).to_json
  end
end

get "/" do
  ["Persons", "Keywords", "Sites"].to_json
end

post "/signin" do
  if form_data["username"] && form_data["password"]
    user = User.find_by(username: form_data["username"], password: pass_and_name_to_hash)
    user ? [token: user.password, id: user.id, username: user.username].to_json : authenticate
  end
end

post "/remind" do
  user = User.find_by(username: form_data["username"])
  if user
    remind_password(user)
  else
    resource_not_found(:users)
  end
end

post "/restore_password" do
  user = User.find_by(username: form_data["username"])
  send_new_password(user)
end

get "/:key" do |k|
  classes = ["persons", "sites"]
  get_collection_by_permission(k) if classes.include? k
end
