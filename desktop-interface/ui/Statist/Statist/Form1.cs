using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Statist.Model;
using Statist.DAL;

namespace Statist
{
    public partial class frmStatist : Form
    {
        List<Sites> sites = new List<Sites>();
        List<Persons> persons = new List<Persons>();
        List<Pages> pages = new List<Pages>();
        List<GeneralStatistics> generalStatistics = new List<GeneralStatistics>();
        List<DailyStatistics> dailyStatistics = new List<DailyStatistics>();

        public frmStatist()
        {
            InitializeComponent();

            persons = DBInitializer.FillPersons();
            sites = DBInitializer.FillSites();
            pages = DBInitializer.FillPages();

            cmbSiteGeneral.DataSource = sites;
            cmbSiteDaily.DataSource = sites;
            cmbPersonDaily.DataSource = persons;
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            generalStatistics.Clear();
            var selectedSiteGeneral = cmbSiteGeneral.SelectedItem;
            Pages page = Pages.GetPageById(pages, (selectedSiteGeneral as Sites).Id);

            if(page != null)
                txtUpdateDate.Text = page.LastScanDate.ToString();

            List<Pages> selectedPages = Pages.GetPagesBySiteId(pages, (selectedSiteGeneral as Sites).Id);

            if (selectedPages.Count != 0)
            {
                foreach (var person in persons)
                {
                    GeneralStatistics generalStatist = new GeneralStatistics();
                    generalStatist.Name = person.Name;
                    generalStatist.Rank = selectedPages.Where(si => si.SiteId == (selectedSiteGeneral as Sites).Id).SelectMany(p => p.PersonPageRanks).
                        Where(pi => pi.PersonId == person.Id).Sum(r => r.Rank);
                    generalStatistics.Add(generalStatist);
                }
                BindingSource bindGeneral = new BindingSource { DataSource = generalStatistics };
                dgvGeneralStatistics.DataSource = bindGeneral;

            }
            else
                MessageBox.Show("Данных не найдено.");
        }

        private void btnApplyDaily_Click(object sender, EventArgs e)
        {
            dailyStatistics.Clear();

            var selectedSiteDaily = cmbSiteDaily.SelectedItem;
            var selectedPersonDaily = cmbPersonDaily.SelectedItem;            
            var periodFrom = dtpPeriodFrom.Value.Date;
            var periodBefore = dtpPeriodBefore.Value.Date;
            periodBefore = periodBefore.AddDays(1);

            List<Pages> selectedPages = pages.Where(d => d.LastScanDate > periodFrom).Where(dt => dt.LastScanDate < periodBefore).
                Where(si => si.SiteId == (selectedSiteDaily as Sites).Id).ToList();

            if (selectedPages.Count != 0)
            {
                foreach (var page in selectedPages)
                {
                    DailyStatistics dailyStatist = new DailyStatistics();
                    dailyStatist.LastScanDate = page.LastScanDate;
                    dailyStatist.Rank = page.PersonPageRanks.Where(p => p.PersonId == (selectedPersonDaily as Persons).Id).Select(r => r.Rank).FirstOrDefault();
                    dailyStatistics.Add(dailyStatist);
                }
                BindingSource bindDaily = new BindingSource { DataSource = dailyStatistics };
                dgvDailyStatistics.DataSource = bindDaily;
            }
            else
            {
                MessageBox.Show("За указанный период поиск не производился.");
            }
        }
    }
}
