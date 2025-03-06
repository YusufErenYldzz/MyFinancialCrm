using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinancialCrm.Models;

namespace FinancialCrm
{
    public partial class FrmSpendings : Form
    {
        public FrmSpendings()
        {
            InitializeComponent();
        }
        FinancialCrmDbEntities1 db = new FinancialCrmDbEntities1();
        private void FrmBilling_Load(object sender, EventArgs e)
        {
            var values = db.Spendings.ToList();
            dataGridView1.DataSource = values;

            btnBillingForm.BackColor = Color.White;
            btnBillingForm.ForeColor = Color.Black;
            btnBillingForm.Enabled = false;
        }

        private void btnBillList_Click(object sender, EventArgs e)
        {
            var values = db.Spendings.ToList();
            dataGridView1.DataSource = values;
        }

        private void btnCreateBill_Click(object sender, EventArgs e)
        {
            string title = txtSpendingTitle.Text;
            decimal amount = decimal.Parse(txtSpendingAmount.Text);

            // Kullanıcının girdiği tarihi al
            DateTime period;
            if (DateTime.TryParse(txtSpendingDate.Text, out period))
            {
                Spendings spendings = new Spendings();
                spendings.SpendingTitle = title;
                spendings.SpendingAmount = amount;
                spendings.SpendingDate = period; // Kullanıcının girdiği tarih atanıyor

                db.Spendings.Add(spendings);
                db.SaveChanges();

                MessageBox.Show("Ödeme Başarılı Bir Şekilde Sisteme Eklendi", "Faturalar & Ödemeler", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // DataGridView'i güncelle
                var values = db.Spendings.ToList();
                dataGridView1.DataSource = values;
            }
            else
            {
                MessageBox.Show("Geçerli bir tarih formatı giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnRemoveBill_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtBillId.Text);
            var removeValues = db.Bills.Find(id);
            db.Bills.Remove(removeValues);
            db.SaveChanges();
            MessageBox.Show("Ödeme Başarılı Bir Şekilde Sistemden Silindi", "Faturalar & Ödemeler", MessageBoxButtons.OK, MessageBoxIcon.Information);

            var values = db.Bills.ToList();
            dataGridView1.DataSource = values;
        }

        private void btnUpdateBill_Click(object sender, EventArgs e)
        {

            string title = txtSpendingTitle.Text;
            decimal amount = decimal.Parse(txtSpendingAmount.Text);
            string period = txtSpendingDate.Text;
            int id = int.Parse(txtBillId.Text);

            var updateValues = db.Bills.Find(id);
            updateValues.BillTitle = title;
            updateValues.BillAmount = amount;
            updateValues.BillPeriod = period;
            db.SaveChanges();
            MessageBox.Show("Ödeme Başarılı Bir Şekilde Güncellendi", "Faturalar & Ödemeler", MessageBoxButtons.OK, MessageBoxIcon.Information);

            var values = db.Bills.ToList();
            dataGridView1.DataSource = values;
        }

        private void btnBanksForm_Click(object sender, EventArgs e)
        {
            FrmBanks frm = new FrmBanks();
            frm.Show();
            this.Hide();

        }

        private void btnDashboardForm_Click(object sender, EventArgs e)
        {
            FrmDashboard frm = new FrmDashboard();
            frm.Show();
            this.Hide();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btnCategoryForm_Click(object sender, EventArgs e)
        {
            FrmCategory frm = new FrmCategory();
            frm.Show();
            this.Hide();

        }

        private void btnBillForm_Click(object sender, EventArgs e)
        {
            FrmBills frm = new FrmBills();
            frm.Show();
            this.Hide();
        }

        private void btnBillingForm_Click(object sender, EventArgs e)
        {
            FrmSpendings frm = new FrmSpendings();
            frm.Show();
            this.Hide();
        }

        private void btnBankProcess_Click(object sender, EventArgs e)
        {
            FrmBankProcess frm = new FrmBankProcess();
            frm.Show();
            this.Hide();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            FrmSettings frm = new FrmSettings();
            frm.Show();
            this.Hide();
        }
    }
}
