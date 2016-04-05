# set :environment, :production
configure :development do
 set :database_file, "config/database.yml"
end

configure :production do
 db = URI.parse(ENV['DATABASE_URL'] || 'postgres://test:testest@localhost:5432/geekbrains')

 ActiveRecord::Base.establish_connection(
   :adapter  => db.scheme == 'postgres' ? 'postgresql' : db.scheme,
   :host     => db.host,
   :username => db.user,
   :password => db.password,
   :database => db.path[1..-1],
   :encoding => 'utf8'
 )
end
