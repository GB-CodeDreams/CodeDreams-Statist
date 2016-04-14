
post "/sites" do
  body = request.POST
  site = Site.new(name: body["name"])
  if site.save
    Site.all.to_json
  else
    [{error: site.errors.messages}].to_json
  end
end

patch "/sites/:id" do
  body = request.POST
  site = Site.find_by(id: params[:id])
  return [{error: {sites: ["site not found"]}}].to_json unless site
  if site.update_attributes(body)
    Site.all.to_json
  else
    [{error: site.errors.messages}].to_json
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
