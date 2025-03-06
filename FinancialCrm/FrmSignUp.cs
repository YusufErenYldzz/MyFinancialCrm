using FinancialCrm.Models;
using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace FinancialCrm
{
    public partial class FrmSignUp : Form
    {
        public FrmSignUp()
        {
            InitializeComponent();
        }

        FinancialCrmDbEntities1 db = new FinancialCrmDbEntities1();

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            string username = txtGetUserName.Text;
            string password = txtGetPassword.Text;

            if (username == "" || password == "")
            {
                MessageBox.Show("Lütfen tüm alanları doldurunuz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool userExist = db.Users.Any(u => u.Username == username);
            if (userExist)
            {
                MessageBox.Show("Bu kullanıcı adı zaten kullanılmaktadır!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Users newUser = new Users
            {
                Username = username,
                Password = SecurityHelper.HashPassword(password)
            };

            db.Users.Add(newUser);

            try
            {
                db.SaveChanges();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                foreach (var validationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        MessageBox.Show("Kayıt başarılı!", "Başarı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
            }
                FrmLogin frm = new FrmLogin();
            frm.Show();
            this.Hide();
        }

        public static class SecurityHelper
        {
            public static string HashPassword(string password)
            {
                using (SHA256 sha256 = SHA256.Create())
                {
                    byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                    StringBuilder builder = new StringBuilder();
                    foreach (byte b in bytes)
                        builder.Append(b.ToString("x2"));

                    return builder.ToString();
                }
            }
        }

        private void btnBackToPage_Click(object sender, EventArgs e)
        {
            FrmLogin frm = new FrmLogin();
            frm.Show();
            this.Hide();
        }
    }
}
