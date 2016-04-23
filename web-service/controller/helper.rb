helpers do

  def form_data
    request.POST
  end

  def data_without_extra_params
    data = form_data
    form_data.extract!("id", "token")
    data
  end

  def set_current_user
    get_auth_params
    if auth_params && user = User.find_by(password: auth_params["token"])
      @current_user = user
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
    if (form_data["user_id"].to_i != current_user.id) && !current_user.admin?
      halt 403, [error: ["You're not owner of the data or user_id blank"]].to_json
    end
  end

  def resource_not_found(resource)
    resource = resource.to_sym
    halt 400, [error: {resource.to_sym => ["#{resource.to_s.singularize} not found"]}].to_json
  end

  def object_validation_error(object)
    [400, [error: object.errors.messages].to_json]
  end

  def users_resources?(request)
    site = Site.find_by(name: params["site"])
    user_id = current_user.id
    case request
      when :day_statistic
        person = Person.find_by(name: params["query_word"])
        site.user_id == user_id && person.user_id == user_id if site && person
      when :total_statistic
        site.user_id == user_id if site
    end
  end

  def has_permission?(object)
    object.user_id == current_user.id
  end

  def get_auth_params
    data = (request.post? || request.patch?) ? form_data : params
    data.has_key?("token") ? @auth_params = data : false
  end

  def pass_and_name_to_hash
    Digest::MD5.hexdigest(form_data["password"] + User::SALT + form_data["username"]) if form_data
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

  def remind_password(user)
  end

end
