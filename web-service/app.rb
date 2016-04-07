require 'sinatra'
require "sinatra/activerecord"
require 'json'
require './environments'
require './models/person'
require './models/keyword'
require './models/person_page_rank'
require './models/page'
require './models/site'

get '/' do
 a = {a: "c", b: "b"}
 a.to_json
end

get '/hi' do
	"prived!"
end

get '/users' do
	@persons = Persons.all.to_json
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
  puts query
  if query.length == 4
    result = PersonPageRank.day_statistic(*query)
    PersonPageRank.hash_result_without_id(result).to_json
  end
end
