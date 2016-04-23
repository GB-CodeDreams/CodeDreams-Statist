post "/persons" do
  person = Person.new(name: form_data["name"], user_id: form_data["user_id"])
  if person.save
    get_collection_by_permission("persons")
  else
    [400, [error: person.errors.messages].to_json ]
  end
end

patch "/persons/:id" do
  person = Person.find_by(id: params[:id])
  resource_not_found(:persons) unless person
  authorize unless has_permission?(person)
  if person.update_attributes(data_without_extra_params)
    get_collection_by_permission("persons")
  else
    [400, [error: person.errors.messages].to_json]
  end
end

delete "/persons/:id" do
  person = Person.find_by(id: params[:id])
  authorize unless has_permission?(person)
  if person
    person.destroy
    get_collection_by_permission("persons")
  else
    [400, [error: {persons: ["person not found"]}].to_json ]
  end
end
