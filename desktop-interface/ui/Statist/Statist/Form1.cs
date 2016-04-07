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

        public frmStatist()
        {
            InitializeComponent();

            persons = DBInitializer.FillPersons();
            sites = DBInitializer.FillSites();
            pages = DBInitializer.FillPages();

            cmbSite.DataSource = sites;
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            generalStatistics.Clear();
            var selectedSite = cmbSite.SelectedItem;
            Pages page = Pages.GetPageById(pages, (selectedSite as Sites).Id);

            if(page != null)
                txtUpdateDate.Text = page.LastScanDate.ToString();

            List<Pages> newPages = Pages.GetPagesBySiteId(pages, (selectedSite as Sites).Id);

            foreach (var person in persons)
            {
                GeneralStatistics generalStatist = new GeneralStatistics();
                generalStatist.Name = person.Name;
                generalStatist.Rank = newPages.Where(si => si.SiteId == (selectedSite as Sites).Id).SelectMany(p => p.PersonPageRanks).Where(pi => pi.PersonId == person.Id).Sum(r => r.Rank);
                generalStatistics.Add(generalStatist);
            }
            dgvGeneralStatistics.DataSource = generalStatistics;
            dgvGeneralStatistics.Refresh();         
        }
    }
}
