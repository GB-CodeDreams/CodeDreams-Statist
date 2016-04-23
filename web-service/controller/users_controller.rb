post "/users" do
  user = User.new(username: form_data["username"], password: form_data["password"])
  if user.save
    200
  else
    [400, [error: user.errors.messages].to_json]
  end
end

patch "/users/:id" do
  user = User.find_by(id: params[:id])
  resource_not_found(:users) unless user
  unless current_user.admin?
    authorize unless user == current_user
    form_data.delete "admin"
  end
  form_data.delete "token"
  if user.update_attributes(data_without_extra_params)
    200
  else
    object_validation_error(user)
  end
end

get "/users" do
  User.all.map{|u| u.attributes.extract!("id", "username")}.to_json
end
