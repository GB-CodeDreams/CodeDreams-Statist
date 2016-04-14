helpers do
  def form_data
    request.POST
  end
 
  def set_current_user
    token = (request.request_method == "POST" || request.request_method == "PATCH") ? form_data["token"] : params[:token]
    @current_user = User.find_by(password: token) if token
  end
  
  def current_user
    @current_user
  end
end