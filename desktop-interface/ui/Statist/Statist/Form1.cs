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
        List<Keywords> keywords = new List<Keywords>();
        BindingSource bindGuideSites = new BindingSource();
        BindingSource bindGuidePersons = new BindingSource();
        BindingSource bindGuideKeywords = new BindingSource();
        object selectedPersonGuideKeyword;
        frmLogin frmLogin;

        public frmStatist(frmLogin frmLogin)
        {
            InitializeComponent();
            this.frmLogin = frmLogin;
            txtDistanceGuideKeywords.LostFocus += new EventHandler(txtDistanceGuideKeywords_LostFocus);

            DBWebService.GetPersons(ref persons);
            DBWebService.GetSites(ref sites);

            bindGuideSites.DataSource = sites.OrderBy(n => n.Name);
            dgvGuideSites.DataSource = bindGuideSites;
            bindGuidePersons.DataSource = persons.OrderBy(n => n.Name);
            dgvGuidePersons.DataSource = bindGuidePersons;

            cmbSiteGeneral.DataSource = sites.OrderBy(n => n.Name).ToList();
            cmbSiteDaily.DataSource = sites.OrderBy(n => n.Name).ToList();
            cmbPersonDaily.DataSource = persons.OrderBy(n => n.Name).ToList();
            cmbPersonGuideKeyword.DataSource = persons.OrderBy(n => n.Name).ToList();
        }
        private void txtDistanceGuideKeywords_LostFocus(object sender, EventArgs e)
        {
            int sum = 0;
            if (!int.TryParse(txtDistanceGuideKeywords.Text, out sum))
            {
                MessageBox.Show("\"Дистанция\" должна быть целым числом!");
                txtDistanceGuideKeywords.Focus();
            }
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

        private void cmbPersonGuideKeyword_SelectionChangeCommitted(object sender, EventArgs e)
        {
            selectedPersonGuideKeyword = (sender as ComboBox).SelectedValue;

            DBWebService.GetKeywords(ref keywords, (selectedPersonGuideKeyword as Persons).Id);

            if (keywords.Count != 0)
            {
                bindGuideKeywords = new BindingSource { DataSource = keywords.OrderBy(i => i.Id) };
                dgvGuideKeywords.DataSource = bindGuideKeywords;
            }
            else
            {
                dgvGuideKeywords.DataSource = keywords;
                MessageBox.Show("Данных не найдено");
            }
        }

        private void btnAddGuideSite_Click(object sender, EventArgs e)
        {
            if (DBWebService.AddSite(txtNameGuideSite.Text, txtUrlGuideSite.Text))
            {
                sites.Clear();
                FillListsSites();
                MessageBox.Show("Сайт успешно добавлен.");
            }
        }

        private void btnDeleteGuideSite_Click(object sender, EventArgs e)
        {
            var selectedSitesRows = dgvGuideSites.SelectedRows;

            if (selectedSitesRows.Count == 1)
            {
                if (DBWebService.DeleteSite((selectedSitesRows[0].DataBoundItem as Sites).Id.ToString()))
                {
                    FillListsSites();
                    MessageBox.Show("Операция успешно завершена.");
                }
            }
            else
            {
                bool error = false;
                for (int i = 0; i < selectedSitesRows.Count; i++)
                {
                    var selectedSite = selectedSitesRows[i].DataBoundItem;
                    if (!DBWebService.DeleteSite((selectedSite as Sites).Id.ToString()))
                    {
                        error = true;
                        break;
                    }
                }
                FillListsSites();
                if (!error)
                {
                    MessageBox.Show("Операция успешно завершена.");
                }
            }
        }
        private void dgvGuideSites_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            var selectedCells = (sender as DataGridView).SelectedCells;
            if (selectedCells.Count != 0)
            {
                int rowIndex = selectedCells[0].RowIndex;
                DataGridViewCell cellNumEditRow = (sender as DataGridView).Rows[rowIndex].Cells[0];

                if(DBWebService.EditSite(cellNumEditRow.Value.ToString(), selectedCells[0].Value.ToString()))
                {
                    FillListsSites();
                    MessageBox.Show("Имя сайта изменено.");
                }
            }
        }
        void FillListsSites()
        {
            DBWebService.GetSites(ref sites);
            bindGuideSites.DataSource = sites.OrderBy(n => n.Name);
            cmbSiteDaily.DataSource = sites.OrderBy(n => n.Name).ToList();
            cmbSiteGeneral.DataSource = sites.OrderBy(n => n.Name).ToList();
        }
        void FillListsPersons()
        {
            DBWebService.GetPersons(ref persons);
            bindGuidePersons.DataSource = persons.OrderBy(n => n.Name);
            cmbPersonDaily.DataSource = persons.OrderBy(n => n.Name).ToList();
            cmbPersonGuideKeyword.DataSource = persons.OrderBy(n => n.Name).ToList();
        }
        void FillListsKeywords()
        {
            DBWebService.GetKeywords(ref keywords, (selectedPersonGuideKeyword as Persons).Id);
            bindGuideKeywords.DataSource = keywords.OrderBy(i => i.Id);
        }

        void ShowMessageError(DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show(e.Exception.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void dgvGuideSites_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            ShowMessageError(e);
        }

        private void dgvGuidePersons_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            ShowMessageError(e);
        }

        private void dgvGuideKeywords_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            ShowMessageError(e);
        }

        private void btnAddGuidePerson_Click(object sender, EventArgs e)
        {
            if (DBWebService.AddPerson(txtNameGuidePerson.Text))
            {
                persons.Clear();
                FillListsPersons();
                MessageBox.Show("Личность успешно добавлена.");
            }
        }

        private void btnDeleteGuidePerson_Click(object sender, EventArgs e)
        {
            var selectedPersonsRows = dgvGuidePersons.SelectedRows;

            if (selectedPersonsRows.Count == 1)
            {
                if (DBWebService.DeletePerson((selectedPersonsRows[0].DataBoundItem as Persons).Id.ToString()))
                {
                    FillListsPersons();
                    MessageBox.Show("Операция успешно завершена.");
                }
            }
            else
            {
                bool error = false;
                for (int i = 0; i < selectedPersonsRows.Count; i++)
                {
                    var selectedPerson = selectedPersonsRows[i].DataBoundItem;
                    if(!DBWebService.DeletePerson((selectedPerson as Persons).Id.ToString()))
                    {
                        error = true;
                        break;
                    }
                }
                FillListsPersons();
                if (!error)
                {
                    MessageBox.Show("Операция успешно завершена.");
                }
            }
        }
        private void dgvGuidePersons_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            var selectedCells = (sender as DataGridView).SelectedCells;
            if (selectedCells.Count != 0)
            {
                int rowIndex = selectedCells[0].RowIndex;
                DataGridViewCell cellNumEditRow = (sender as DataGridView).Rows[rowIndex].Cells[0];

                if (DBWebService.EditPerson(cellNumEditRow.Value.ToString(), selectedCells[0].Value.ToString()))
                {
                    FillListsPersons();
                    MessageBox.Show("Имя личности изменено.");
                }
            }
        }
        private void btnAddGuideKeyword_Click(object sender, EventArgs e)
        {
            if(txtName1GuideKeywords.Text == "")
            {
                MessageBox.Show("1 ключевое слово должно быть заполнено.");
                txtName1GuideKeywords.Focus();
            }
            else
            {
                if (selectedPersonGuideKeyword != null)
                {
                    if (DBWebService.AddKeyword(txtName1GuideKeywords.Text, txtName2GuideKeywords.Text, txtDistanceGuideKeywords.Text, (selectedPersonGuideKeyword as Persons).Id.ToString()))
                    {
                        keywords.Clear();
                        FillListsKeywords();
                        MessageBox.Show("Ключевые слова добавлены.");
                    }
                }
                else
                {
                    MessageBox.Show("Вы не выбрали личность.");
                }
            }
        }

        private void btnDeleteGuideKeyword_Click(object sender, EventArgs e)
        {
            var selectedKeywordsRows = dgvGuideKeywords.SelectedRows;

            if (selectedKeywordsRows.Count == 1)
            {
                if (DBWebService.DeleteKeywords((selectedPersonGuideKeyword as Persons).Id.ToString(), (selectedKeywordsRows[0].DataBoundItem as Keywords).Id.ToString()))
                {
                    FillListsKeywords();
                    MessageBox.Show("Операция успешно завершена.");
                }
            }
            else
            {
                bool error = false;
                for (int i = 0; i < selectedKeywordsRows.Count; i++)
                {
                    var selectedKeyword = selectedKeywordsRows[i].DataBoundItem;
                    if (!DBWebService.DeleteKeywords((selectedPersonGuideKeyword as Persons).Id.ToString(), (selectedKeyword as Keywords).Id.ToString()))
                    {
                        error = true;
                        break;
                    }
                }
                FillListsKeywords();
                if (!error)
                {
                    MessageBox.Show("Операция успешно завершена.");
                }
            }
        }

        private void dgvGuideKeywords_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            var selectedCells = (sender as DataGridView).SelectedCells;
            if (selectedCells.Count != 0)
            {
                int rowIndex = selectedCells[0].RowIndex;
                DataGridViewCell cellNumEditRow = (sender as DataGridView).Rows[rowIndex].Cells[0];
                DataGridViewCell cellNameEditRow = (sender as DataGridView).Rows[rowIndex].Cells[1];
                DataGridViewCell cellName2EditRow = (sender as DataGridView).Rows[rowIndex].Cells[2];
                DataGridViewCell cellDistEditRow = (sender as DataGridView).Rows[rowIndex].Cells[3];

                if (DBWebService.EditKeyword(cellNameEditRow.Value.ToString(), cellName2EditRow.FormattedValue.ToString(),
                    cellDistEditRow.FormattedValue.ToString(), (selectedPersonGuideKeyword as Persons).Id.ToString(), cellNumEditRow.Value.ToString()))
                {
                    FillListsKeywords();
                    MessageBox.Show("Ключевое слово изменено.");
                }
            }
        }

        private void frmStatist_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmLogin.Close();
        }
    }
}
