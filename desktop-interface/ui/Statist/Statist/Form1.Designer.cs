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
            this.tbDailyStatistics = new System.Windows.Forms.TabPage();
            this.lblSite = new System.Windows.Forms.Label();
            this.cmbSite = new System.Windows.Forms.ComboBox();
            this.btnApply = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbStatistics.SuspendLayout();
            this.tbGeneralStatistics.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
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
            this.tbGeneralStatistics.Controls.Add(this.textBox1);
            this.tbGeneralStatistics.Controls.Add(this.dataGridView1);
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
            // tbDailyStatistics
            // 
            this.tbDailyStatistics.BackColor = System.Drawing.Color.Transparent;
            this.tbDailyStatistics.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbDailyStatistics.ForeColor = System.Drawing.Color.Transparent;
            this.tbDailyStatistics.Location = new System.Drawing.Point(4, 25);
            this.tbDailyStatistics.Name = "tbDailyStatistics";
            this.tbDailyStatistics.Padding = new System.Windows.Forms.Padding(3);
            this.tbDailyStatistics.Size = new System.Drawing.Size(888, 407);
            this.tbDailyStatistics.TabIndex = 1;
            this.tbDailyStatistics.Text = "Ежедневная статистика";
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
            // cmbSite
            // 
            this.cmbSite.FormattingEnabled = true;
            this.cmbSite.Location = new System.Drawing.Point(62, 25);
            this.cmbSite.Name = "cmbSite";
            this.cmbSite.Size = new System.Drawing.Size(186, 26);
            this.cmbSite.TabIndex = 1;
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(102, 71);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(100, 32);
            this.btnApply.TabIndex = 2;
            this.btnApply.Text = "Применить";
            this.btnApply.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dataGridView1.Location = new System.Drawing.Point(279, 71);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(296, 283);
            this.dataGridView1.TabIndex = 3;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(413, 25);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(135, 24);
            this.textBox1.TabIndex = 4;
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
            // Column1
            // 
            this.Column1.DataPropertyName = "name";
            this.Column1.HeaderText = "Имя";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 150;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "rank";
            this.Column2.HeaderText = "Количество упоминаний";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tbStatistics;
        private System.Windows.Forms.TabPage tbGeneralStatistics;
        private System.Windows.Forms.TabPage tbDailyStatistics;
        private System.Windows.Forms.Label lblSite;
        private System.Windows.Forms.ComboBox cmbSite;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
    }
}

