using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinancialCrm
{
    public partial class FrmLogin: Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            FrmSignUp frm = new FrmSignUp();
            frm.Show();
            this.Hide();

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text; 

            using (FinancialCrmDbContext db = new FinancialCrmDbContext())
            {
                var user = db.Users
                             .Where(u => u.Username == username && u.Password == password)
                             .FirstOrDefault();

                if (user != null)
                {
                    MessageBox.Show("Giriş başarılı!", "Başarı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    
                    FrmBanks frm = new FrmBanks();
                    frm.Show();
                    this.Hide(); 
                }
                else
                {
                    MessageBox.Show("Kullanıcı adı veya şifre hatalı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
