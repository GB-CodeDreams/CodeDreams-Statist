helpers do

  def form_data
    request.POST
  end

  def set_current_user
    get_auth_params
    if auth_params && user = User.find_by(id: auth_params["uid"])
      @current_user = user if user.password == auth_params["token"]
    end
  end

  def current_user
    @current_user
  end

  def authenticate
    halt 401, [error: ["Authentication error!"]].to_json unless current_user
  end

  def authorize
    halt 403, [error: ["Permission error!"]].to_json unless current_user.admin?
  end

  def check_owner
    if (form_data["user_id"] != current_user.id) && !current_user.admin?
      halt 403, [error: ["You're not owner of the data or user_id blank"]].to_json
    end
  end

  def has_perrmission?(object)
    object.user_id == current_user.id
  end

  def get_auth_params
    data = (request.post? || request.patch?) ? form_data : params
    if data.has_key?("uid") && data.has_key?("token")
      @auth_params = data
    else
      false
    end
  end

  def auth_params
    @auth_params
  end

  def get_collection_by_permission(collection)
    if current_user.admin?
      constant_from_collection(collection).all.to_json
    else
      current_user.send(collection.to_sym).to_json
    end
  end

  def constant_from_collection(collection)
    collection.singularize.capitalize.constantize
  end

end
