
module Repository
  class Keyword

    include LocalObjects

    attr_accessor :id, :name, :name_2, :distance

    def initialize(params)
      @name = params[:name]
      @person = params[:person_id]
      @name_2 = params[:name_2]
      @distance = params[:distance]
      set_id
    end
  end
end
