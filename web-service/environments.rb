configure :development do
 set :database_file, "config/database.yml"
end

configure :production do
ActiveRecord::Base.establish_connection(
  :adapter  => "mysql2",
  :host     => "host",
  :username => "user",
  :password => "password",
  :database => "db"
)
end
