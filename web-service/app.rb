require 'sinatra'
require "sinatra/activerecord"
require 'json'
require './environments'
require './models/user'
require './models/person'
require './models/keyword'
require './models/person_page_rank'
require './models/page'
require './models/site'

get '/' do
 a = {a: "c", b: "b"}
 a.to_json
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
    [{error: {persons: ["person not found"]}}].to_json if person.nil?
  end
end

post "/persons/:id/keywords" do
  body = request.POST
  person = Person.find_by(id: params[:id])
  return [{error: {persons: ["person not found"]}}].to_json  unless person
  keyword = Keyword.new(name: body["name"], person_id: params[:person_id])
  if keyword.save
    person.keywords.to_json
  else
    [{error: keyword.errors.messages}].to_json
  end
end

patch "/persons/:person_id/keyword/:id" do
  body = request.POST
  person = Person.find_by(id: params[:person_id])
  return [{error: {persons: ["person not found"]}}].to_json  unless person
  keyword = Keyword.find_by(id: params[:id])
  if keyword.update_attributes(body)
    person.keywords.to_json
  else
    [{error: keyword.errors.messages}].to_json
  end
end

delete "/persons/:person_id/keyword/:id" do
  person = Person.find_by(id: params[:person_id])
  return [{error: {persons: ["person not found"]}}].to_json  unless person
  keyword = Site.find_by(id: params[:id])
  if keyword
    keyword.destroy
    person.keywords.to_json
  else
    [{error: {keywords: "keyword not found"}}].to_json
  end
end

post "/sites" do
  body = request.POST
  site = Site.new(name: body["name"])
  if site.save
    Site.all.to_json
  else
    [{error: site.errors.messages}].to_json
  end
end

patch "/sites/:id" do
  body = request.POST
  site = Site.find_by(id: params[:id])
  return [{error: {sites: ["site not found"]}}].to_json unless site
  if site.update_attributes(body)
    Site.all.to_json
  else
    [{error: site.errors.messages}].to_json
  end
end

delete "/sites/:id" do
  site = Site.find_by(id: params[:id])
  if site
    site.destroy
    Site.all.to_json
  else
    [{error: {sites: ["site not found"]}}].to_json
  end
end

post "/persons" do
  body = request.POST
  person = Person.new(name: body["name"])
  if person.save
    Person.all.to_json
  else
    [{error: person.errors.messages}].to_json
  end
end

patch "/persons/:id" do
  body = request.POST
  person = Person.find_by(id: params[:id])
  return [{error: {persons: ["person not found"]}}].to_json unless person
  if person.update_attributes(body)
    Person.all.to_json
  else
    [{error: person.errors.messages}].to_json
  end
end

delete "/persons/:id" do
  person = Person.find_by(id: params[:id])
  if person
    person.destroy
    Person.all.to_json
  else
    [{error: {persons: ["person not found"]}}].to_json
  end
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
