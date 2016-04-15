require 'sinatra'
require "sinatra/activerecord"
require 'json'
require './environments'
require './controller/helper'
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


before %r{^/(sites|persons|keywords)} do
  set_current_user
  authenticate
end

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

get "/:key" do |k|
  classes = ["persons", "sites"]
  k.singularize.capitalize.constantize.all.to_json if classes.include? k
end

# post "/test" do
#   p request.POST
#   # p JSON.parse(request.body.read)
# end

# get "/test" do
#   p params
#   # p JSON.parse(request.body.read)
# end
