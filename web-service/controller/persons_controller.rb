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
  return [400, [error: {persons: ["person not found"]}].to_json ] unless person
  authorize unless has_perrmission?(person)
  if person.update_attributes(form_data)
    current_user.admin ? Person.all.to_json : current_user.persons.to_json
  else
    [400, [error: person.errors.messages].to_json]
  end
end

delete "/persons/:id" do
  person = Person.find_by(id: params[:id])
  authorize unless has_perrmission?(person)
  if person
    person.destroy
    current_user.admin ? Person.all.to_json : current_user.persons.to_json
  else
    [{error: {persons: ["person not found"]}}].to_json
  end
end
