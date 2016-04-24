before %r{^/users(\/\d+)?\Z} do
  set_permitted_params(:username, :password) if request.patch? || request.post?
end

post "/users" do
  user = User.new(data_without_extra_params)
  if user.save
    200
  else
    object_validation_error(user)
  end
end

patch "/users/:id" do
  user = User.find_by(id: params[:id])
  resource_not_found(:users) unless user
  unless current_user.admin?
    authorize unless user == current_user
    form_data.delete "admin"
  end
  if user.update_attributes(data_without_extra_params)
    200
  else
    object_validation_error(user)
  end
end

get "/users" do
  User.all.map{|u| u.attributes.extract!("id", "username")}.to_json
end
