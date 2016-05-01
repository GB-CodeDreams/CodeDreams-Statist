post "/users" do
  user = User.new(form_data)
  if user.save
    200
  else
    [400, [error: user.errors.messages].to_json]
  end
end
