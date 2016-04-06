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
    }
}
