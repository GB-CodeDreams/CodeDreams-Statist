module Repository
  class FakeRepository

    def collections
      @collection ||= {}
    end

    def find_by(object_class, params)
      key, value = params.first
      collections[object_class].find{|object| object.send(key) == value}
    end

    def update(object_class, id, params)
      object = find_by(object_class, id: id)
      raise "Object not found" unless object
      params.each{|k,v| object.send("#{k}=".to_sym, v)}
    end

    def delete(object_class, id)
      collections[object_class].delete_if{|o| o.id == id}
    end

    def get(object_class)
      collections[object_class]
    end

    def create(object_class, params)
      new_object = full_name(object_class).new(params)
      collections[object_class.to_s] = [] unless collections.has_key? object_class.to_s
      collections[object_class.to_s] << new_object
      new_object
    end

    private

    def full_name(klass)
      Object.const_get(self.class.name.split('::')[0] + "::" + klass)
    end
  end
end
