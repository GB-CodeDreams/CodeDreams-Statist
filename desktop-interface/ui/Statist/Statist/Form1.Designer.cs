namespace Statist
{
    partial class frmStatist
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.tbStatistics = new System.Windows.Forms.TabControl();
            this.tbGeneralStatistics = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.txtUpdateDate = new System.Windows.Forms.TextBox();
            this.dgvGeneralStatistics = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnApplyGeneral = new System.Windows.Forms.Button();
            this.cmbSiteGeneral = new System.Windows.Forms.ComboBox();
            this.lblSite = new System.Windows.Forms.Label();
            this.tbDailyStatistics = new System.Windows.Forms.TabPage();
            this.dgvDailyStatistics = new System.Windows.Forms.DataGridView();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpPeriodBefore = new System.Windows.Forms.DateTimePicker();
            this.dtpPeriodFrom = new System.Windows.Forms.DateTimePicker();
            this.cmbPersonDaily = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnApplyDaily = new System.Windows.Forms.Button();
            this.cmbSiteDaily = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chartDailyStatistics = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tbStatistics.SuspendLayout();
            this.tbGeneralStatistics.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGeneralStatistics)).BeginInit();
            this.tbDailyStatistics.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDailyStatistics)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartDailyStatistics)).BeginInit();
            this.SuspendLayout();
            // 
            // tbStatistics
            // 
            this.tbStatistics.Controls.Add(this.tbGeneralStatistics);
            this.tbStatistics.Controls.Add(this.tbDailyStatistics);
            this.tbStatistics.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbStatistics.Location = new System.Drawing.Point(12, 12);
            this.tbStatistics.Name = "tbStatistics";
            this.tbStatistics.SelectedIndex = 0;
            this.tbStatistics.Size = new System.Drawing.Size(1267, 399);
            this.tbStatistics.TabIndex = 0;
            // 
            // tbGeneralStatistics
            // 
            this.tbGeneralStatistics.BackColor = System.Drawing.Color.Transparent;
            this.tbGeneralStatistics.Controls.Add(this.chartDailyStatistics);
            this.tbGeneralStatistics.Controls.Add(this.label1);
            this.tbGeneralStatistics.Controls.Add(this.txtUpdateDate);
            this.tbGeneralStatistics.Controls.Add(this.dgvGeneralStatistics);
            this.tbGeneralStatistics.Controls.Add(this.btnApplyGeneral);
            this.tbGeneralStatistics.Controls.Add(this.cmbSiteGeneral);
            this.tbGeneralStatistics.Controls.Add(this.lblSite);
            this.tbGeneralStatistics.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbGeneralStatistics.Location = new System.Drawing.Point(4, 25);
            this.tbGeneralStatistics.Name = "tbGeneralStatistics";
            this.tbGeneralStatistics.Padding = new System.Windows.Forms.Padding(3);
            this.tbGeneralStatistics.Size = new System.Drawing.Size(1259, 370);
            this.tbGeneralStatistics.TabIndex = 0;
            this.tbGeneralStatistics.Text = "Общая статистика";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(276, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 18);
            this.label1.TabIndex = 5;
            this.label1.Text = "Дата обновления";
            // 
            // txtUpdateDate
            // 
            this.txtUpdateDate.Location = new System.Drawing.Point(413, 25);
            this.txtUpdateDate.Name = "txtUpdateDate";
            this.txtUpdateDate.ReadOnly = true;
            this.txtUpdateDate.Size = new System.Drawing.Size(162, 24);
            this.txtUpdateDate.TabIndex = 4;
            // 
            // dgvGeneralStatistics
            // 
            this.dgvGeneralStatistics.AllowUserToAddRows = false;
            this.dgvGeneralStatistics.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGeneralStatistics.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column5,
            this.Column2});
            this.dgvGeneralStatistics.Location = new System.Drawing.Point(279, 71);
            this.dgvGeneralStatistics.Name = "dgvGeneralStatistics";
            this.dgvGeneralStatistics.ReadOnly = true;
            this.dgvGeneralStatistics.Size = new System.Drawing.Size(296, 283);
            this.dgvGeneralStatistics.TabIndex = 3;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Name";
            this.Column1.HeaderText = "Имя";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 150;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "LastScanDate";
            this.Column5.HeaderText = "Дата обновления";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Visible = false;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Rank";
            this.Column2.HeaderText = "Количество упоминаний";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // btnApplyGeneral
            // 
            this.btnApplyGeneral.Location = new System.Drawing.Point(102, 71);
            this.btnApplyGeneral.Name = "btnApplyGeneral";
            this.btnApplyGeneral.Size = new System.Drawing.Size(100, 32);
            this.btnApplyGeneral.TabIndex = 2;
            this.btnApplyGeneral.Text = "Применить";
            this.btnApplyGeneral.UseVisualStyleBackColor = true;
            this.btnApplyGeneral.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // cmbSiteGeneral
            // 
            this.cmbSiteGeneral.DisplayMember = "Name";
            this.cmbSiteGeneral.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSiteGeneral.FormattingEnabled = true;
            this.cmbSiteGeneral.Location = new System.Drawing.Point(62, 25);
            this.cmbSiteGeneral.Name = "cmbSiteGeneral";
            this.cmbSiteGeneral.Size = new System.Drawing.Size(186, 26);
            this.cmbSiteGeneral.TabIndex = 1;
            // 
            // lblSite
            // 
            this.lblSite.AutoSize = true;
            this.lblSite.Location = new System.Drawing.Point(14, 25);
            this.lblSite.Name = "lblSite";
            this.lblSite.Size = new System.Drawing.Size(42, 18);
            this.lblSite.TabIndex = 0;
            this.lblSite.Text = "Сайт";
            // 
            // tbDailyStatistics
            // 
            this.tbDailyStatistics.BackColor = System.Drawing.Color.Transparent;
            this.tbDailyStatistics.Controls.Add(this.dgvDailyStatistics);
            this.tbDailyStatistics.Controls.Add(this.label6);
            this.tbDailyStatistics.Controls.Add(this.label5);
            this.tbDailyStatistics.Controls.Add(this.label4);
            this.tbDailyStatistics.Controls.Add(this.dtpPeriodBefore);
            this.tbDailyStatistics.Controls.Add(this.dtpPeriodFrom);
            this.tbDailyStatistics.Controls.Add(this.cmbPersonDaily);
            this.tbDailyStatistics.Controls.Add(this.label3);
            this.tbDailyStatistics.Controls.Add(this.btnApplyDaily);
            this.tbDailyStatistics.Controls.Add(this.cmbSiteDaily);
            this.tbDailyStatistics.Controls.Add(this.label2);
            this.tbDailyStatistics.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbDailyStatistics.ForeColor = System.Drawing.Color.Black;
            this.tbDailyStatistics.Location = new System.Drawing.Point(4, 25);
            this.tbDailyStatistics.Name = "tbDailyStatistics";
            this.tbDailyStatistics.Padding = new System.Windows.Forms.Padding(3);
            this.tbDailyStatistics.Size = new System.Drawing.Size(626, 370);
            this.tbDailyStatistics.TabIndex = 1;
            this.tbDailyStatistics.Text = "Ежедневная статистика";
            // 
            // dgvDailyStatistics
            // 
            this.dgvDailyStatistics.AllowUserToAddRows = false;
            this.dgvDailyStatistics.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDailyStatistics.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column3,
            this.Column4});
            this.dgvDailyStatistics.Location = new System.Drawing.Point(258, 16);
            this.dgvDailyStatistics.Name = "dgvDailyStatistics";
            this.dgvDailyStatistics.ReadOnly = true;
            this.dgvDailyStatistics.Size = new System.Drawing.Size(347, 336);
            this.dgvDailyStatistics.TabIndex = 13;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "LastScanDate";
            this.Column3.HeaderText = "Дата";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 200;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "Rank";
            this.Column4.HeaderText = "Количество упоминаний";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(66, 166);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 18);
            this.label6.TabIndex = 12;
            this.label6.Text = "до";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(76, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(16, 18);
            this.label5.TabIndex = 11;
            this.label5.Text = "с";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(7, 123);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 18);
            this.label4.TabIndex = 10;
            this.label4.Text = "Период:";
            // 
            // dtpPeriodBefore
            // 
            this.dtpPeriodBefore.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpPeriodBefore.Location = new System.Drawing.Point(110, 161);
            this.dtpPeriodBefore.Name = "dtpPeriodBefore";
            this.dtpPeriodBefore.Size = new System.Drawing.Size(127, 24);
            this.dtpPeriodBefore.TabIndex = 9;
            // 
            // dtpPeriodFrom
            // 
            this.dtpPeriodFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpPeriodFrom.Location = new System.Drawing.Point(110, 118);
            this.dtpPeriodFrom.Name = "dtpPeriodFrom";
            this.dtpPeriodFrom.Size = new System.Drawing.Size(127, 24);
            this.dtpPeriodFrom.TabIndex = 8;
            this.dtpPeriodFrom.Value = new System.DateTime(2016, 4, 1, 0, 0, 0, 0);
            // 
            // cmbPersonDaily
            // 
            this.cmbPersonDaily.DisplayMember = "Name";
            this.cmbPersonDaily.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPersonDaily.FormattingEnabled = true;
            this.cmbPersonDaily.Location = new System.Drawing.Point(109, 64);
            this.cmbPersonDaily.Name = "cmbPersonDaily";
            this.cmbPersonDaily.Size = new System.Drawing.Size(128, 26);
            this.cmbPersonDaily.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(14, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 18);
            this.label3.TabIndex = 6;
            this.label3.Text = "Личность";
            // 
            // btnApplyDaily
            // 
            this.btnApplyDaily.ForeColor = System.Drawing.Color.Black;
            this.btnApplyDaily.Location = new System.Drawing.Point(136, 204);
            this.btnApplyDaily.Name = "btnApplyDaily";
            this.btnApplyDaily.Size = new System.Drawing.Size(100, 32);
            this.btnApplyDaily.TabIndex = 5;
            this.btnApplyDaily.Text = "Применить";
            this.btnApplyDaily.UseVisualStyleBackColor = true;
            this.btnApplyDaily.Click += new System.EventHandler(this.btnApplyDaily_Click);
            // 
            // cmbSiteDaily
            // 
            this.cmbSiteDaily.DisplayMember = "Name";
            this.cmbSiteDaily.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSiteDaily.FormattingEnabled = true;
            this.cmbSiteDaily.Location = new System.Drawing.Point(109, 16);
            this.cmbSiteDaily.Name = "cmbSiteDaily";
            this.cmbSiteDaily.Size = new System.Drawing.Size(127, 26);
            this.cmbSiteDaily.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(47, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "Сайт";
            // 
            // chartDailyStatistics
            // 
            chartArea1.Name = "ChartArea1";
            this.chartDailyStatistics.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartDailyStatistics.Legends.Add(legend1);
            this.chartDailyStatistics.Location = new System.Drawing.Point(603, 25);
            this.chartDailyStatistics.Name = "chartDailyStatistics";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Количество";
            series1.XValueMember = "Name";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
            series1.YValueMembers = "Rank";
            series1.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            this.chartDailyStatistics.Series.Add(series1);
            this.chartDailyStatistics.Size = new System.Drawing.Size(640, 329);
            this.chartDailyStatistics.TabIndex = 6;
            this.chartDailyStatistics.Text = "chart1";
            // 
            // frmStatist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1303, 423);
            this.Controls.Add(this.tbStatistics);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmStatist";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Statist";
            this.tbStatistics.ResumeLayout(false);
            this.tbGeneralStatistics.ResumeLayout(false);
            this.tbGeneralStatistics.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGeneralStatistics)).EndInit();
            this.tbDailyStatistics.ResumeLayout(false);
            this.tbDailyStatistics.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDailyStatistics)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartDailyStatistics)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tbStatistics;
        private System.Windows.Forms.TabPage tbGeneralStatistics;
        private System.Windows.Forms.TabPage tbDailyStatistics;
        private System.Windows.Forms.Label lblSite;
        private System.Windows.Forms.ComboBox cmbSiteGeneral;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUpdateDate;
        private System.Windows.Forms.DataGridView dgvGeneralStatistics;
        private System.Windows.Forms.Button btnApplyGeneral;
        private System.Windows.Forms.DateTimePicker dtpPeriodFrom;
        private System.Windows.Forms.ComboBox cmbPersonDaily;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnApplyDaily;
        private System.Windows.Forms.ComboBox cmbSiteDaily;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpPeriodBefore;
        private System.Windows.Forms.DataGridView dgvDailyStatistics;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartDailyStatistics;
    }
}

