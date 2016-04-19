post "/users" do
  user = User.new(username: form_data["username"], password: form_data["password"])
  if user.save
    200
  else
    [400, [error: user.errors.messages].to_json]
  end
end
