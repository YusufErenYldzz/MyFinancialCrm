using FinancialCrm.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace FinancialCrm
{
    public partial class FrmSettings : Form
    {
        public FrmSettings()
        {
            InitializeComponent();
        }

        FinancialCrmDbEntities1 db = new FinancialCrmDbEntities1();

        private void btnUpdatePassword_Click(object sender, EventArgs e)
        {

            string oldPassword = txtOldPassword.Text;
            string newPassword = txtNewPassword.Text;

            if (ChangePassword(oldPassword, newPassword))
            {
                MessageBox.Show("Şifre başarıyla değiştirildi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Eski şifre yanlış veya hata oluştu!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public bool ChangePassword(string oldPassword, string newPassword)
        {
            using (var context = new FinancialCrmDbContext())
            {
                var user = context.Users.FirstOrDefault(u => u.Password == oldPassword);

                if (user == null)
                    return false; // Eski şifre yanlış veya kullanıcı yok

                user.Password = newPassword;
                context.SaveChanges();
                return true;
            }
        }

        private void btnCategoryForm_Click(object sender, EventArgs e)
        {
            FrmCategory frm = new FrmCategory();
            frm.Show();
            this.Hide();
        }

        private void btnBanksForm_Click(object sender, EventArgs e)
        {
            FrmBanks frm = new FrmBanks();
            frm.Show();
            this.Hide();
        }

        private void btnBillsForm_Click(object sender, EventArgs e)
        {
            FrmBills frm = new FrmBills();
            frm.Show();
            this.Hide();
        }

        private void btnBillForm_Click(object sender, EventArgs e)
        {
            FrmSpendings frm = new FrmSpendings();
            frm.Show();
            this.Hide();
        }

        private void btnBankProcessForm_Click(object sender, EventArgs e)
        {
            FrmBankProcess frm = new FrmBankProcess();
            frm.Show();
            this.Hide();
        }

        private void btnDashboardForm_Click(object sender, EventArgs e)
        {
            FrmDashboard frm = new FrmDashboard();
            frm.Show();
            this.Hide();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            FrmSettings frm = new FrmSettings();
            frm.Show();
            this.Hide();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Close();        
        }

        private void FrmSettings_Load(object sender, EventArgs e)
        {
            btnSettings.BackColor = Color.White;
            btnSettings.ForeColor = Color.Black;
            btnSettings.Enabled = false;
        }
    }
}
