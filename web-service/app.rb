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

get "/catalogs" do
  ["Persons", "Keywords", "Sites"].to_json
end

get "/persons/:id/keywords" do
  person = Person.find_by(id: params[:id])
  person.keywords.to_json if person
end

post "/persons/:id/keywords" do
  person = Person.find_by(id: params[:id])
  if person && params[:name]
    person.keywords.create(name: params[:name])
    person.keywords.to_json
  else
    [{error: "person not found"}].to_json if person.nil?
    [{error: "keyword name not must be empty"}].to_json if params[:name].nil?
  end
end

get "/:key" do |k|
  classes = ["persons", "sites"]
  k.singularize.capitalize.constantize.all.to_json if classes.include? k
end
