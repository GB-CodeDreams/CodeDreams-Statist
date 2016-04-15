
post "/persons/:id/keywords" do
  person = Person.find_by(id: params[:id])
  return [400, [error: {persons: ["person not found"]}].to_json]  unless person
  authorize unless has_perrmission?(person)
  keyword = Keyword.new(name: form_data["name"], person_id: params[:person_id])
  if keyword.save
    person.keywords.to_json
  else
    [400, [{error: keyword.errors.messages}].to_json ]
  end
end

patch "/persons/:person_id/keywords/:id" do
  person = Person.find_by(id: params[:person_id])
  return [400, [error: {persons: ["person not found"]}].to_json ] unless person
  authorize unless has_perrmission?(person)
  keyword = Keyword.find_by(id: params[:id])
  return [400, [error: {keywords: ["keyword not found"]}].to_json ] unless keyword
  if keyword.update_attributes(form_data)
    person.keywords.to_json
  else
    [400, [error: keyword.errors.messages].to_json ]
  end
end

delete "/persons/:person_id/keyword/:id" do
  person = Person.find_by(id: params[:person_id])
  return [400, [error: {persons: ["person not found"]}].to_json ]  unless person
  authorize unless has_perrmission?(person)
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
  return [400, [error: {persons: ["person not found"]}].to_json ] unless person
  authorize unless has_perrmission?(person)
  person.keywords.to_json
end
