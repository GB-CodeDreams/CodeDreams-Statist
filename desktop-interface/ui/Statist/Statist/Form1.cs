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
using System.Windows.Forms.DataVisualization.Charting;
using System.Collections;

namespace Statist
{
    public partial class frmStatist : Form
    {
        List<Sites> sites = new List<Sites>();
        List<Persons> persons = new List<Persons>();
        List<GeneralStatistics> generalStatistics = new List<GeneralStatistics>();
        List<DailyStatistics> dailyStatistics = new List<DailyStatistics>();

        public frmStatist()
        {
            InitializeComponent();

            DBWebService.GetPersons(ref persons);
            DBWebService.GetSites(ref sites);

            cmbSiteGeneral.DataSource = sites;
            cmbSiteDaily.DataSource = sites;
            cmbPersonDaily.DataSource = persons;
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            generalStatistics.Clear();

            var selectedSiteGeneral = cmbSiteGeneral.SelectedItem;

            DBWebService.GetGeneralStatistics((selectedSiteGeneral as Sites).Name, ref generalStatistics);

            BindingSource bindGeneral = new BindingSource { DataSource = generalStatistics };
            if (generalStatistics.Count != 0)
            {
                txtUpdateDate.Text = generalStatistics[0].LastScanDate.ToString();
                dgvGeneralStatistics.DataSource = bindGeneral;
                FillChart(chartGeneralStatistics, bindGeneral, "Name", "Rank");
            }
            else
            {
                txtUpdateDate.Text = "";
                dgvGeneralStatistics.DataSource = bindGeneral;
                ClearChart(chartGeneralStatistics);
                MessageBox.Show("Данных не найдено.");
            }
        }

        private void btnApplyDaily_Click(object sender, EventArgs e)
        {
            dailyStatistics.Clear();
            dgvDailyStatistics.Rows.Clear();

            var selectedSiteDaily = cmbSiteDaily.SelectedItem;
            var selectedPersonDaily = cmbPersonDaily.SelectedItem;
            var periodFrom = dtpPeriodFrom.Value.Date.GetDateTimeFormats('d');
            var periodBefore = dtpPeriodBefore.Value.Date.AddDays(1).GetDateTimeFormats('d');

            DBWebService.GetDailyStatistics((selectedSiteDaily as Sites).Name, (selectedPersonDaily as Persons).Name, periodFrom[4], periodBefore[4], ref dailyStatistics);

            if (dailyStatistics.Count != 0)
            {
                FillDailyDataGridViewRows(dailyStatistics, dgvDailyStatistics);
                FillChart(chartDailyStatistics, dailyStatistics, "LastScanDate", "Rank");
            }
            else
            {
                ClearChart(chartDailyStatistics);
                MessageBox.Show("За указанный период, данных не найдено.");
            }
        }

        void FillDailyDataGridViewRows(List<DailyStatistics> dailyStatistics, DataGridView dgv)
        {
            foreach (var dailyStatist in dailyStatistics)
            {
                DataGridViewRow row = new DataGridViewRow();
                DataGridViewTextBoxCell dateCell = new DataGridViewTextBoxCell();
                DataGridViewTextBoxCell rankCell = new DataGridViewTextBoxCell();
                dateCell.Value = dailyStatist.LastScanDate.ToShortDateString();
                rankCell.Value = dailyStatist.Rank;
                row.Cells.Add(dateCell);
                row.Cells.Add(rankCell);
                dgv.Rows.Add(row);
            }

            DataGridViewRow totalRow = new DataGridViewRow();
            DataGridViewTextBoxCell totalDateCell = new DataGridViewTextBoxCell();
            DataGridViewTextBoxCell totalRankCell = new DataGridViewTextBoxCell();
            totalDateCell.Value = "Всего:";
            totalRankCell.Value = dailyStatistics.Sum(l => l.Rank);
            totalRow.Cells.Add(totalDateCell);
            totalRow.Cells.Add(totalRankCell);
            dgv.Rows.Add(totalRow);

        }

        void ClearChart(Chart chart)
        {
            chart.Series[0].Points.Clear();
        }

        void FillChart(Chart chart, IEnumerable dataSource, string xField, string yField)
        {
            chart.Series[0].Points.DataBindXY(dataSource, xField, dataSource, yField);
        }
    }
}
