before %r{^/(sites|persons|keywords|total_statistic|day_statistic|users)} do
  set_current_user
  authenticate
end

before "/users" do
  authorize
end

before %r{^/(sites|persons(\/\d+)?\Z)} do
  check_owner if request.post? || request.patch?
end

before "/total_statistic" do
  authorize unless users_resources?(:total_statistic)
end
before "/day_statistic" do
  authorize unless users_resources?(:day_statistic)
end
