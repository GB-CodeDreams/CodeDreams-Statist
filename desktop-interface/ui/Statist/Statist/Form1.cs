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

        public frmStatist()
        {
            InitializeComponent();

            persons = DBInitializer.FillPersons();
            sites = DBInitializer.FillSites();

            foreach (var site in sites)
            {
                cmbSite.Items.Add(site.Name);
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            //var item = cmbSite.SelectedItem;
        }
    }
}
