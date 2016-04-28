require 'sinatra'
require "sinatra/activerecord"
require 'json'
require 'pony'
require_relative './environments'
require_relative './controller/helper'
require_relative './controller/filters'
require_relative './controller/users_controller'
require_relative './controller/persons_controller'
require_relative './controller/keywords_controller'
require_relative './controller/sites_controller'
require_relative './models/user'
require_relative './models/person'
require_relative './models/keyword'
require_relative './models/person_page_rank'
require_relative './models/page'
require_relative './models/site'
require_relative './repository/lib/repository'

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
  user ? send_new_password(user) : resource_not_found(:users)
end

get "/:key" do |k|
  classes = ["persons", "sites"]
  get_collection_by_permission(k) if classes.include? k
end
