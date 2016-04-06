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
            var item = cmbSite.SelectedItem;
            Pages page = Pages.GetPageById(pages, (item as Sites).Id);
            txtUpdateDate.Text = page.LastScanDate.ToString();
        }
    }
}
