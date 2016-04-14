post "/users" do
  user = User.new(form_data)
  if user.save
    200
  else
    [error: user.errors.messages].to_json
  end
end