require_relative "repository/local_objects"
require_relative "repository/site"
require_relative "repository/person"
require_relative "repository/keyword"
require_relative "repository/fake_repository"
require_relative "repository/db_repository"

module Repository

  class << self
    def set_repository(repository)
      @repository = repository
    end

    def repository
      @repository
    end
  end
end
