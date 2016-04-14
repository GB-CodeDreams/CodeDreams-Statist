
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

get "/persons/:id/keywords" do
  person = Person.find_by(id: params[:id])
  if person
    person.keywords.to_json
  else
    [{error: {persons: ["person not found"]}}].to_json if person.nil?
  end
end
