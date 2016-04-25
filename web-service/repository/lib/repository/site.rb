
module Repository
  class Site
    include LocalObjects

    attr_accessor :name

    def initialize(name)
      @name = name
      set_id
    end

  end
end
