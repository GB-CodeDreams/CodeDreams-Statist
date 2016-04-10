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

            Persons personPutin = new Persons()
            {
                Id = 1,
                Name = "Путин"
            };
            Persons personMed = new Persons()
            {
                Id = 2,
                Name = "Медведев"
            };

            persons.Add(personPutin);
            persons.Add(personMed);

            FillPersonPageRanks(persons);

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
                FoundDateTime = new DateTime(2016, 04, 01, 18, 05, 30),
                LastScanDate = new DateTime(2016, 04, 01, 18, 13, 30)
            };
            Pages pageLenta1 = new Pages()
            {
                Id = 3,
                Url = "lenta.ru/1",
                SiteId = 1,
                FoundDateTime = new DateTime(2016, 04, 02, 16, 05, 30),
                LastScanDate = new DateTime(2016, 04, 02, 16, 13, 30)
            };
            Pages pageRia = new Pages()
            {
                Id = 2,
                Url = "ria.ru",
                SiteId = 2,
                FoundDateTime = new DateTime(2016, 04, 01, 18, 10, 30),
                LastScanDate = new DateTime(2016, 04, 01, 18, 23, 30)
            };
            Pages pageRia1 = new Pages()
            {
                Id = 4,
                Url = "ria.ru/1",
                SiteId = 2,
                FoundDateTime = new DateTime(2016, 04, 03, 10, 05, 30),
                LastScanDate = new DateTime(2016, 04, 03, 10, 13, 30)
            };

            pages.Add(pageLenta);
            pages.Add(pageRia);
            pages.Add(pageLenta1);            
            pages.Add(pageRia1);

            FillPersonPageRanks(pages);

            return pages;
        }

        static void FillPersonPageRanks<T>(List<T> list)
        {
            PersonPageRanks personPageRank1 = new PersonPageRanks() { PersonId = 1, PageId = 1, Rank = 8 };
            PersonPageRanks personPageRank2 = new PersonPageRanks() { PersonId = 1, PageId = 2, Rank = 7 };
            PersonPageRanks personPageRank3 = new PersonPageRanks() { PersonId = 2, PageId = 1, Rank = 6 };
            PersonPageRanks personPageRank4 = new PersonPageRanks() { PersonId = 2, PageId = 2, Rank = 5 };
            PersonPageRanks personPageRank5 = new PersonPageRanks() { PersonId = 1, PageId = 3, Rank = 4 };
            PersonPageRanks personPageRank6 = new PersonPageRanks() { PersonId = 2, PageId = 3, Rank = 3 };
            PersonPageRanks personPageRank7 = new PersonPageRanks() { PersonId = 1, PageId = 4, Rank = 2 };
            PersonPageRanks personPageRank8 = new PersonPageRanks() { PersonId = 2, PageId = 4, Rank = 1 };

            if (list is List<Persons>)
            {
                (list[0] as Persons).PersonPageRanks.Add(personPageRank1);
                (list[0] as Persons).PersonPageRanks.Add(personPageRank2);
                (list[0] as Persons).PersonPageRanks.Add(personPageRank5);
                (list[0] as Persons).PersonPageRanks.Add(personPageRank7);
                (list[1] as Persons).PersonPageRanks.Add(personPageRank3);
                (list[1] as Persons).PersonPageRanks.Add(personPageRank4);
                (list[1] as Persons).PersonPageRanks.Add(personPageRank6);
                (list[1] as Persons).PersonPageRanks.Add(personPageRank8);
            }
            else if(list is List<Pages>)
            {
                (list[0] as Pages).PersonPageRanks.Add(personPageRank1);
                (list[0] as Pages).PersonPageRanks.Add(personPageRank3);
                (list[1] as Pages).PersonPageRanks.Add(personPageRank2);
                (list[1] as Pages).PersonPageRanks.Add(personPageRank4);
                (list[2] as Pages).PersonPageRanks.Add(personPageRank5);
                (list[2] as Pages).PersonPageRanks.Add(personPageRank6);
                (list[3] as Pages).PersonPageRanks.Add(personPageRank7);
                (list[3] as Pages).PersonPageRanks.Add(personPageRank8);
            }
        }
    }
}
