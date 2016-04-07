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
            this.tbStatistics = new System.Windows.Forms.TabControl();
            this.tbGeneralStatistics = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.txtUpdateDate = new System.Windows.Forms.TextBox();
            this.dgvGeneralStatistics = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnApply = new System.Windows.Forms.Button();
            this.cmbSite = new System.Windows.Forms.ComboBox();
            this.lblSite = new System.Windows.Forms.Label();
            this.tbDailyStatistics = new System.Windows.Forms.TabPage();
            this.tbStatistics.SuspendLayout();
            this.tbGeneralStatistics.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGeneralStatistics)).BeginInit();
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
            this.tbStatistics.Size = new System.Drawing.Size(1211, 399);
            this.tbStatistics.TabIndex = 0;
            // 
            // tbGeneralStatistics
            // 
            this.tbGeneralStatistics.BackColor = System.Drawing.Color.Transparent;
            this.tbGeneralStatistics.Controls.Add(this.label1);
            this.tbGeneralStatistics.Controls.Add(this.txtUpdateDate);
            this.tbGeneralStatistics.Controls.Add(this.dgvGeneralStatistics);
            this.tbGeneralStatistics.Controls.Add(this.btnApply);
            this.tbGeneralStatistics.Controls.Add(this.cmbSite);
            this.tbGeneralStatistics.Controls.Add(this.lblSite);
            this.tbGeneralStatistics.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbGeneralStatistics.Location = new System.Drawing.Point(4, 25);
            this.tbGeneralStatistics.Name = "tbGeneralStatistics";
            this.tbGeneralStatistics.Padding = new System.Windows.Forms.Padding(3);
            this.tbGeneralStatistics.Size = new System.Drawing.Size(1203, 370);
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
            this.dgvGeneralStatistics.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGeneralStatistics.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
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
            // Column2
            // 
            this.Column2.DataPropertyName = "Rank";
            this.Column2.HeaderText = "Количество упоминаний";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(102, 71);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(100, 32);
            this.btnApply.TabIndex = 2;
            this.btnApply.Text = "Применить";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // cmbSite
            // 
            this.cmbSite.DisplayMember = "Name";
            this.cmbSite.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSite.FormattingEnabled = true;
            this.cmbSite.Location = new System.Drawing.Point(62, 25);
            this.cmbSite.Name = "cmbSite";
            this.cmbSite.Size = new System.Drawing.Size(186, 26);
            this.cmbSite.TabIndex = 1;
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
            this.tbDailyStatistics.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbDailyStatistics.ForeColor = System.Drawing.Color.Transparent;
            this.tbDailyStatistics.Location = new System.Drawing.Point(4, 25);
            this.tbDailyStatistics.Name = "tbDailyStatistics";
            this.tbDailyStatistics.Padding = new System.Windows.Forms.Padding(3);
            this.tbDailyStatistics.Size = new System.Drawing.Size(1203, 370);
            this.tbDailyStatistics.TabIndex = 1;
            this.tbDailyStatistics.Text = "Ежедневная статистика";
            // 
            // frmStatist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1249, 423);
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tbStatistics;
        private System.Windows.Forms.TabPage tbGeneralStatistics;
        private System.Windows.Forms.TabPage tbDailyStatistics;
        private System.Windows.Forms.Label lblSite;
        private System.Windows.Forms.ComboBox cmbSite;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUpdateDate;
        private System.Windows.Forms.DataGridView dgvGeneralStatistics;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
    }
}

