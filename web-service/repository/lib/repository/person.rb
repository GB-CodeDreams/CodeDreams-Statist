

module Repository
  class Person
    include LocalObjects

    attr_accessor :name

    def initialize(name)
      @name = name
      set_id
    end

  end
end
