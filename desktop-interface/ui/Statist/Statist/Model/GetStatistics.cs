using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Statist.Model
{
    public static class GetStatistics
    {
        public static List<GeneralStatistics> GetGeneralStatistics(int idSite, List<Persons> persons, List<Pages> pages, ref List<GeneralStatistics> generalStatistics)
        {
            generalStatistics.Clear();

            List<Pages> selectedPages = Pages.GetPagesBySiteId(pages, idSite);

            if (selectedPages.Count != 0)
            {
                foreach (var person in persons)
                {
                    GeneralStatistics generalStatist = new GeneralStatistics();
                    generalStatist.Name = person.Name;
                    generalStatist.Rank = selectedPages.Where(si => si.SiteId == idSite).SelectMany(p => p.PersonPageRanks).
                        Where(pi => pi.PersonId == person.Id).Sum(r => r.Rank);
                    generalStatistics.Add(generalStatist);
                }
                return generalStatistics;
            }
            else
                return generalStatistics;

            /*BindingSource bindGeneral = new BindingSource { DataSource = generalStatistics };
            dgvGeneralStatistics.DataSource = bindGeneral;*/
        }
        public static List<DailyStatistics> GetDailyStatistics(List<Pages> pages, DateTime periodFrom, DateTime periodBefore, int idSite, int idPerson, ref List<DailyStatistics> dailyStatistics)
        {
            dailyStatistics.Clear();

            List<Pages> selectedPages = pages.Where(d => d.LastScanDate > periodFrom).Where(dt => dt.LastScanDate < periodBefore).
                Where(si => si.SiteId == idSite).ToList();

            if (selectedPages.Count != 0)
            {
                foreach (var page in selectedPages)
                {
                    DailyStatistics dailyStatist = new DailyStatistics();
                    dailyStatist.LastScanDate = page.LastScanDate;
                    dailyStatist.Rank = page.PersonPageRanks.Where(p => p.PersonId == idPerson).Select(r => r.Rank).FirstOrDefault();
                    dailyStatistics.Add(dailyStatist);
                }
                return dailyStatistics;
            }
            else
                return dailyStatistics;

        }

    }
}
