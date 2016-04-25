module Repository
  class DbRepository
    def initialize
    end

    def method_missing(name, *arg)
      const = Object.const_get(arg[0])
      raise "Model not found" unless const.ancestors.include? ActiveRecord::Base
      const.send(name, *arg.slice(1..-1))
    end

  end
end
