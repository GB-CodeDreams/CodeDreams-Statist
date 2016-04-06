using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Statist.Model;

namespace Statist.DAL
{
    public static class DBInitializer
    {
        public static List<Persons> FillPersons()
        {
            List<Persons> persons = new List<Persons>();
            Persons personPutin = new Persons() { Id = 1, Name = "Путин" };
            Persons personMed = new Persons() { Id = 2, Name = "Медведев" };
            persons.Add(personPutin);
            persons.Add(personMed);
            return persons;
        }
        public static List<Sites> FillSites()
        {
            List<Sites> sites = new List<Sites>();
            Sites siteLenta = new Sites() { Id = 1, Name = "Лента" };
            Sites siteRia = new Sites() { Id = 2, Name = "РИА" };
            sites.Add(siteLenta);
            sites.Add(siteRia);
            return sites;
        }
        public static List<Pages> FillPages()
        {
            List<Pages> pages = new List<Pages>();

            Pages pageLenta = new Pages()
            {
                Id = 1,
                Url = "lenta.ru",
                SiteId = 1,
                FoundDateTime = new DateTime(2016, 04, 06, 18, 05, 30),
                LastScanDate = new DateTime(2016, 04, 06, 18, 13, 30)
            };
            Pages pageRia = new Pages()
            {
                Id = 2,
                Url = "ria.ru",
                SiteId = 2,
                FoundDateTime = new DateTime(2016, 04, 06, 18, 10, 30),
                LastScanDate = new DateTime(2016, 04, 06, 18, 23, 30)
            };

            pages.Add(pageLenta);
            pages.Add(pageRia);
            return pages;
        }
    }
}
