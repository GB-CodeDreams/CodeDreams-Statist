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
