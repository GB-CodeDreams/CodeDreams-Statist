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
using System.Net;
using System.IO;
using System.Collections.Specialized;
using Newtonsoft.Json;

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

            //DBWebService.GetPersons(ref persons);
            //DBWebService.GetSites(ref sites);
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

            //DBWebService.GetGeneralStatistics((selectedSiteGeneral as Sites).Name, ref generalStatistics);

            //BindingSource bindGeneral = new BindingSource { DataSource = generalStatistics };
            //if (generalStatistics.Count != 0)
            //{
            //    txtUpdateDate.Text = generalStatistics[0].LastScanDate.ToString();              
            //    dgvGeneralStatistics.DataSource = bindGeneral;
            //}
            //else
            //{
            //    txtUpdateDate.Text = "";
            //    dgvGeneralStatistics.DataSource = bindGeneral;
            //    MessageBox.Show("Данных не найдено.");
            //}


            Pages page = Pages.GetPageById(pages, (selectedSiteGeneral as Sites).Id);

            if (page != null)
                txtUpdateDate.Text = page.LastScanDate.ToString();

            generalStatistics = GetStatistics.GetGeneralStatistics((selectedSiteGeneral as Sites).Id, persons, pages, ref generalStatistics);

            if (generalStatistics.Count != 0)
            {
                BindingSource bindGeneral = new BindingSource { DataSource = generalStatistics };
                dgvGeneralStatistics.DataSource = bindGeneral;

            }
            else
                MessageBox.Show("Данных не найдено.");
        }

        private void btnApplyDaily_Click(object sender, EventArgs e)
        {
            dailyStatistics.Clear();
            //dgvDailyStatistics.Rows.Clear();

            var selectedSiteDaily = cmbSiteDaily.SelectedItem;
            var selectedPersonDaily = cmbPersonDaily.SelectedItem;
            //var periodFrom = dtpPeriodFrom.Value.Date.GetDateTimeFormats('d');
            //var periodBefore = dtpPeriodBefore.Value.Date.AddDays(1).GetDateTimeFormats('d');
            var periodFrom = dtpPeriodFrom.Value.Date;
            var periodBefore = dtpPeriodBefore.Value.Date;
            periodBefore = periodBefore.AddDays(1);

            //DBWebService.GetDailyStatistics((selectedSiteDaily as Sites).Name, (selectedPersonDaily as Persons).Name, periodFrom[4], periodBefore[4], ref dailyStatistics);

            //BindingSource bindDaily = new BindingSource { DataSource = dailyStatistics };
            //if (dailyStatistics.Count != 0)
            //{
            //    //bindDaily.AddNew();
            //    //dgvDailyStatistics.DataSource = bindDaily;

            //    foreach(var dailyStatist in dailyStatistics)
            //    {
            //        DataGridViewRow row = new DataGridViewRow();
            //        DataGridViewTextBoxCell dateCell = new DataGridViewTextBoxCell();
            //        DataGridViewTextBoxCell rankCell = new DataGridViewTextBoxCell();
            //        dateCell.Value = dailyStatist.LastScanDate.ToShortDateString();
            //        rankCell.Value = dailyStatist.Rank;
            //        row.Cells.Add(dateCell);
            //        row.Cells.Add(rankCell);
            //        dgvDailyStatistics.Rows.Add(row);
            //    }

            //    DataGridViewRow totalRow = new DataGridViewRow();
            //    DataGridViewTextBoxCell totalDateCell = new DataGridViewTextBoxCell();
            //    DataGridViewTextBoxCell totalRankCell = new DataGridViewTextBoxCell();
            //    totalDateCell.Value = "Всего:";
            //    totalRankCell.Value = dailyStatistics.Sum(l => l.Rank);
            //    totalRow.Cells.Add(totalDateCell);
            //    totalRow.Cells.Add(totalRankCell);                
            //    dgvDailyStatistics.Rows.Add(totalRow);

            //    //dgvDailyStatistics.Rows[dgvDailyStatistics.RowCount - 1].Cells[0].Value = "Всего:";
            //    //dgvDailyStatistics.Rows[dgvDailyStatistics.RowCount - 1].Cells[1].Value = 123;
            //}
            //else
            //{
            //    //dgvDailyStatistics.DataSource = bindDaily;
            //    MessageBox.Show("За указанный период, данных не найдено.");
            //}

            dailyStatistics = GetStatistics.GetDailyStatistics(pages, periodFrom, periodBefore, (selectedSiteDaily as Sites).Id, (selectedPersonDaily as Persons).Id, ref dailyStatistics);

            BindingSource bindDaily = new BindingSource { DataSource = dailyStatistics };
            if (dailyStatistics.Count != 0)
            {
                dgvDailyStatistics.DataSource = bindDaily;
            }
            else
            {
                dgvDailyStatistics.DataSource = bindDaily;
                MessageBox.Show("За указанный период поиск не производился.");
            }
        }
    }
}
