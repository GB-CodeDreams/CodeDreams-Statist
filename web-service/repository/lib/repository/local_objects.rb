module Repository
  module LocalObjects

    def self.included(klass)
      klass.extend(ClassMethods)
    end

    module ClassMethods
      def count
        @count ||= 1
      end

      def increase_count
        @count += 1
      end
    end

    private

    def set_id
      @id = self.class.count
      self.class.increase_count
    end
  end
end
