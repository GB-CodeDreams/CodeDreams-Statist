using Newtonsoft.Json;
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
                    response = webClient.DownloadString(Resources.GetPersons);                    
                    persons = JsonConvert.DeserializeObject<List<Persons>>(response);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
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
                    response = webClient.DownloadString(Resources.GetSites);
                    sites = JsonConvert.DeserializeObject<List<Sites>>(response);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
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
                    response = webClient.DownloadString(Resources.GetGeneralStatistics + nameSite);
                    generalStatistics = JsonConvert.DeserializeObject<List<GeneralStatistics>>(response);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                return generalStatistics;
            }
        }
    }
}
