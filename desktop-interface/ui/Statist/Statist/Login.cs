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
    public partial class frmLogin : Form
    {
        
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Authorization();
        }

        private void txtPassword_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyData == Keys.Enter)
            {
                Authorization();
            }
        }
        void Authorization()
        {
            if (DBWebService.Authorization(txtLogin.Text, txtPassword.Text))
            {
                frmStatist frmStatist = new frmStatist(this);
                this.Visible = false;
                frmStatist.ShowDialog();
            }
            else
            {
                txtLogin.Focus();
            }
        }
    }
}
