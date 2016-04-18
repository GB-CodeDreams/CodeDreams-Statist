using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Statist.Model;
using Statist.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace Statist.DAL
{
    public static class DBWebService
    {
        public static List<Persons> GetPersons(ref List<Persons> persons)
        {
            string response = "";
            using (var webClient = new WebClient())
            {
                try
                {
                    webClient.Encoding = Encoding.UTF8;
                    response = webClient.DownloadString(Resources.GetPersons + "?" + Resources.Authorization);
                    persons = JsonConvert.DeserializeObject<List<Persons>>(response);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }                
            }
            return persons.OrderBy(n => n.Name).ToList();
        }
        public static List<Sites> GetSites(ref List<Sites> sites)
        {
            string response = "";
            using (var webClient = new WebClient())
            {
                try
                {
                    webClient.Encoding = Encoding.UTF8;
                    response = webClient.DownloadString(Resources.GetSites + "?" + Resources.Authorization);
                    sites = JsonConvert.DeserializeObject<List<Sites>>(response);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                return sites.OrderBy(n => n.Name).ToList();
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
                    response = webClient.DownloadString(Resources.GetGeneralStatistics + nameSite + "&" + Resources.Authorization);
                    generalStatistics = JsonConvert.DeserializeObject<List<GeneralStatistics>>(response);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
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
                        namePerson + "&start_date=" + periodFrom + "&end_date=" + periodBefore + "&" + Resources.Authorization);
                    dailyStatistics = JsonConvert.DeserializeObject<List<DailyStatistics>>(response);
                    dailyStatistics.RemoveAt(dailyStatistics.Count - 1);
                    //var dynObj = (JArray)JsonConvert.DeserializeObject(response);
                    //var last = dynObj.Last;
                    //foreach (var item in last)
                    //{
                    //    var item1 = item;
                    //    foreach (JObject trend in item["trends"])
                    //    {                            

                    //    }
                    //}

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                return dailyStatistics;
            }
        }
    }
}
