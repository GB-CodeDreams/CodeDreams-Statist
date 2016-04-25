using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Statist.Model;
using Statist.Properties;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace Statist.DAL
{
    public static class DBWebService
    {
        static string userId = "12";
        static string tokenUser = "06d9f00ce052a83b9e0eaa45f65f9dea";

        public static List<Persons> GetPersons(ref List<Persons> persons)
        {
            string response = "";
            using (var webClient = new WebClient())
            {
                try
                {
                    webClient.Encoding = Encoding.UTF8;
                    response = webClient.DownloadString(Resources.Persons + "?" + "token=" + User.Token);
                    persons = JsonConvert.DeserializeObject<List<Persons>>(response);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }                
            }
            return persons;
        }
        public static List<Sites> GetSites(ref List<Sites> sites)
        {
            string response = "";
            using (var webClient = new WebClient())
            {
                try
                {
                    webClient.Encoding = Encoding.UTF8;
                    response = webClient.DownloadString(Resources.Sites + "?" + "token=" + User.Token);
                    sites = JsonConvert.DeserializeObject<List<Sites>>(response);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                return sites;
            }
        }
        public static List<Keywords> GetKeywords(ref List<Keywords> keywords, int idPerson)
        {
            string response = "";
            using (var webClient = new WebClient())
            {
                try
                {
                    webClient.Encoding = Encoding.UTF8;
                    response = webClient.DownloadString(Resources.Persons + "/" + idPerson + "/keywords" + "?" + "token=" + User.Token);
                    keywords = JsonConvert.DeserializeObject<List<Keywords>>(response);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                return keywords;
            }
        }
        public static List<GeneralStatistics> GetGeneralStatistics(string nameSite, ref List<GeneralStatistics> generalStatistics)
        {
            string response = "";
            using (var webClient = new WebClient())
            {
                try
                {
                    webClient.Encoding = Encoding.UTF8;
                    response = webClient.DownloadString(Resources.GetGeneralStatistics + nameSite + "&" + "token=" + User.Token);
                    generalStatistics = JsonConvert.DeserializeObject<List<GeneralStatistics>>(response);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                return generalStatistics;
            }
        }
        public static List<DailyStatistics> GetDailyStatistics(string nameSite, string namePerson, string periodFrom, string periodBefore, ref List<DailyStatistics> dailyStatistics)
        {
            string response = "";
            using (var webClient = new WebClient())
            {
                try
                {
                    webClient.Encoding = Encoding.UTF8;
                    response = webClient.DownloadString(Resources.GetDailyStatistics + nameSite + "&query_word=" +
                        namePerson + "&start_date=" + periodFrom + "&end_date=" + periodBefore + "&" + "token=" + User.Token);
                    dailyStatistics = JsonConvert.DeserializeObject<List<DailyStatistics>>(response);
                    dailyStatistics.RemoveAt(dailyStatistics.Count - 1);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                return dailyStatistics;
            }
        }
        public static bool AddSite(string nameSite, string urlSite)
        {
            using (var webClient = new WebClient())
            {
                try
                {
                    var pars = new NameValueCollection();

                    pars.Add("token", User.Token);
                    pars.Add("name", nameSite);
                    pars.Add("url", urlSite);
                    pars.Add("user_id", User.Id);

                    webClient.UploadValues(Resources.Sites, "POST", pars);
                    return true;

                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }
        public static bool EditSite(string idSite, string newNameSite)
        {
            using (var webClient = new WebClient())
            {
                try
                {
                    var pars = new NameValueCollection();

                    pars.Add("token", User.Token);
                    pars.Add("name", newNameSite);
                    pars.Add("user_id", User.Id);
                    webClient.UploadValues(Resources.Sites + "/" + idSite, "PATCH", pars);
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }
        public static bool DeleteSite(string idSite)
        {
            using (var webClient = new WebClient())
            {
                try
                {
                    var pars = new NameValueCollection();

                    pars.Add("token", User.Token);
                    webClient.UploadValues(Resources.Sites + "/" + idSite, "DELETE", pars);
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }
        public static bool AddPerson(string namePerson)
        {
            using (var webClient = new WebClient())
            {
                try
                {
                    var pars = new NameValueCollection();

                    pars.Add("token", User.Token);
                    pars.Add("name", namePerson);
                    pars.Add("user_id", User.Id);

                    webClient.UploadValues(Resources.Persons, "POST", pars);
                    return true;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }
        public static bool DeletePerson(string idPerson)
        {
            using (var webClient = new WebClient())
            {
                try
                {
                    var pars = new NameValueCollection();

                    pars.Add("token", User.Token);
                    webClient.UploadValues(Resources.Persons + "/" + idPerson, "DELETE", pars);
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }
        public static bool EditPerson(string idPerson, string newNamePerson)
        {
            using (var webClient = new WebClient())
            {
                try
                {
                    var pars = new NameValueCollection();

                    pars.Add("token", User.Token);
                    pars.Add("name", newNamePerson);
                    pars.Add("user_id", User.Id);
                    webClient.UploadValues(Resources.Persons + "/" + idPerson, "PATCH", pars);
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }
        public static bool AddKeyword(string name, string name2, string distance, string idPerson)
        {
            using (var webClient = new WebClient())
            {
                try
                {
                    var pars = new NameValueCollection();

                    pars.Add("token", User.Token);
                    pars.Add("name", name);
                    pars.Add("name_2", name2);
                    pars.Add("distance", distance);
                    pars.Add("person_id", idPerson);

                    webClient.UploadValues(Resources.Persons + "/" + idPerson + "/keywords", "POST", pars);
                    return true;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }
        public static bool DeleteKeywords(string idPerson, string idKeyword)
        {
            using (var webClient = new WebClient())
            {
                try
                {
                    var pars = new NameValueCollection();

                    pars.Add("token", User.Token);
                    webClient.UploadValues(Resources.Persons + "/" + idPerson + "/keywords/" + idKeyword, "DELETE", pars);
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }
        public static bool EditKeyword(string name, string name2, string distance, string idPerson, string idKeyword)
        {
            using (var webClient = new WebClient())
            {
                try
                {
                    var pars = new NameValueCollection();

                    pars.Add("token", User.Token);
                    pars.Add("name", name);
                    pars.Add("name_2", name2);
                    pars.Add("distance", distance);
                    pars.Add("person_id", idPerson);

                    webClient.UploadValues(Resources.Persons + "/" + idPerson + "/keywords/" + idKeyword, "PATCH", pars);
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }
        public static bool Authorization(string username, string password)
        {
            using (var webClient = new WebClient())
            {
                try
                {
                    var pars = new NameValueCollection();

                    pars.Add("username", username);
                    pars.Add("password", password);
                    var response2 = webClient.UploadValues(Resources.Auth, "POST", pars);
                    string str = Encoding.ASCII.GetString(response2);

                    var dynObj = (JArray)JsonConvert.DeserializeObject(str);
                    var first = dynObj.First;
                    foreach (var item in first)
                    {
                        switch((item as JProperty).Name)
                        {
                            case "token":
                                User.Token = (item as JProperty).Value.ToString();
                                break;
                            case "id":
                                User.Id = (item as JProperty).Value.ToString();
                                break;
                            case "username":
                                User.Name = (item as JProperty).Value.ToString();
                                break;
                        }
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }
    }
}
