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
  if person
    person.keywords.to_json if person
  else
    [{error: {persons: "person not found"}}].to_json if person.nil?
  end
end

post "/persons/:id/keywords" do
  body = JSON.parse(request.body.read)
  person = Person.find_by(id: params[:id])
  return [{error: {persons: "person not found"}}].to_json  unless person
  keyword = Keyword.new(body)
  if keyword.save
    keyword.to_json
  else
    [{error: keyword.errors.messages}].to_json
  end
end

patch "/persons/:person_id/keyword/:id" do

end

delete "/persons/:person_id/keyword/:id" do
  person = Person.find_by(id: params[:person_id])
  return [{error: {persons: "person not found"}}].to_json  unless person
  keyword = Site.find_by(id: params[:id])
  if keyword
    keyword.destroy
  else
    [{error: {keywords: "keyword not found"}}].to_json
  end
end

post "/sites" do
  body = JSON.parse(request.body.read)
  site = Site.new(body["name"])
  if site.save
    site.to_json
  else
    [{error: site.errors.messages}].to_json
  end
end

patch "/sites/:id" do

end

delete "/sites/:id" do
  site = Site.find_by(id: params[:id])
  if site
    site.destroy
  else
    [{error: {sites: "site not found"}}].to_json
  end
end

post "/persons" do
  person = Person.new(body["name"])
  if person.save
    person.to_json
  else
    [{error: person.errors.messages}].to_json
  end
end

patch "/persons/:id" do

end

delete "/persons/:id" do
  person = Person.find_by(id: params[:id])
  if person
    person.destroy
  else
    [{error: {persons: "person not found"}}].to_json
  end
end

get "/:key" do |k|
  classes = ["persons", "sites"]
  k.singularize.capitalize.constantize.all.to_json if classes.include? k
end
