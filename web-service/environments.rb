configure :development, :test do
 set :database_file, "config/database.yml"
end

configure :production do
 set :database_file, "config/database.yml"
end
