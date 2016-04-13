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
        public static List<Persons> GetPersons()
        {
            string response = "";
            List<Persons> persons = new List<Persons>();
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
        public static List<Sites> GetSites()
        {
            string response = "";
            List<Sites> sites = new List<Sites>();
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
    }
}
