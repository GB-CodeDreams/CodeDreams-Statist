before %r{^/persons/\d+/keywords(\/\d+)?\Z} do
  set_permitted_params(:person_id, :name, :name_2, :distance) if request.patch? || request.post?
end

post "/persons/:id/keywords" do
  person = Person.find_by(id: params[:id])
  resource_not_found(:persons) unless person
  authorize unless has_permission?(person)
  keyword = Keyword.new(data_without_extra_params)
  if keyword.save
    person.keywords.to_json
  else
    [400, [{error: keyword.errors.messages}].to_json ]
  end
end

patch "/persons/:person_id/keywords/:id" do
  person = Person.find_by(id: params[:person_id])
  resource_not_found(:persons) unless person
  authorize unless has_permission?(person)
  keyword = Keyword.find_by(id: params[:id])
  resource_not_found(:keywords) unless keyword
  if keyword.update_attributes(data_without_extra_params)
    person.keywords.to_json
  else
    [400, [error: keyword.errors.messages].to_json ]
  end
end

delete "/persons/:person_id/keywords/:id" do
  person = Person.find_by(id: params[:person_id])
  resource_not_found(:persons) unless person
  authorize unless has_permission?(person)
  keyword = Keyword.find_by(id: params[:id])
  if keyword
    keyword.destroy
    person.keywords.to_json
  else
    resource_not_found(:keywords)
  end
end

get "/persons/:id/keywords" do
  person = Person.find_by(id: params[:id])
  resource_not_found(:persons) unless person
  authorize unless has_permission?(person)
  person.keywords.to_json
end
