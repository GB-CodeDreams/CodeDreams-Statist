
post "/sites" do
  return [400, [error: {pages: ["url can't be blank"]}].to_json] if form_data["url"].nil? || form_data["url"].empty?
  site = Site.new(name: form_data["name"])
  if site.save
    site.pages.create(url: form_data["url"])
    Site.all.to_json
  else
    [400, [error: site.errors.messages].to_json]
  end
end
 
#тяжелый метод, в одном запросе могут передаваться данные для двух таблиц
patch "/sites/:id" do
  site = Site.find_by(id: params[:id])
  return [400, [error: {sites: ["site not found"]}].to_json] unless site
  if form_data["name"] && form_data["url"]
    page = site.pages.first
    if site.update_attributes(name: form_data["name"]) && page.update_attributes(url: form_data["url"])
      Site.all.to_json
    else
      [400, [error: [site, page].find{|i| !i.valid?}.errors.messages].to_json ]
    end
  elsif form_data["name"]
    if site.update_attributes(name: form_data["name"])
      Site.all.to_json
    else
      [400, [error: site.errors.messages].to_json]
    end
  else form_data["url"]
    page = site.pages.first
    if page.update_attributes(url: form_data["url"])
      Site.all.to_json
    else
      [400, [error: page.errors.messages].to_json]
    end
  end
end

delete "/sites/:id" do
  site = Site.find_by(id: params[:id])
  if site
    site.destroy
    Site.all.to_json
  else
    [{error: {sites: ["site not found"]}}].to_json
  end
end
