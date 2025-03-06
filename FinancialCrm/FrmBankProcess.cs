using FinancialCrm.Models;
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
    public partial class FrmBankProcess : Form
    {
        public FrmBankProcess()
        {
            InitializeComponent();
        }

        FinancialCrmDbEntities1 db = new FinancialCrmDbEntities1();

        private void FrmBankProcess_Load(object sender, EventArgs e)
        {
            pnlGetMoney.Visible = false;
            pnlMoneyTransfer.Visible = false;

            var values = db.Banks.ToList();
            cmbBankAccount1.DataSource = values;
            cmbBankAccount1.DisplayMember = "BankTitle";
            cmbBankAccount1.ValueMember = "BankId";
            cmbBankAccount1.SelectedIndex = 0;
            cmbBankAccount2.DataSource = values;
            cmbBankAccount2.DisplayMember = "BankTitle";
            cmbBankAccount2.ValueMember = "BankId";
            cmbBankAccount2.SelectedIndex = 0;

            btnBankProcessForm.BackColor = Color.White;
            btnBankProcessForm.ForeColor = Color.Black;
            btnBankProcessForm.Enabled = false;
        }

        private void btnMoneyT_Click(object sender, EventArgs e)
        {
            pnlMoneyTransfer.Visible = true;
            pnlGetMoney.Visible = false;
            btnMoneyT.Visible = false;
            btnGetM.Visible = false;
        }

        private void btnGetM_Click(object sender, EventArgs e)
        {
            pnlGetMoney.Visible = true;
            pnlMoneyTransfer.Visible = false;
            btnMoneyT.Visible = false;
            btnGetM.Visible = false;
        }

        private void btnBackToPage1_Click(object sender, EventArgs e)
        {
            pnlGetMoney.Visible = false;
            pnlMoneyTransfer.Visible = false;
            btnMoneyT.Visible = true;
            btnGetM.Visible = true;
        }

        private void btnBackToPage2_Click(object sender, EventArgs e)
        {
            pnlGetMoney.Visible = false;
            pnlMoneyTransfer.Visible = false;
            btnMoneyT.Visible = true;
            btnGetM.Visible = true;
        }

        private void btnMoneyTransfer_Click(object sender, EventArgs e)
        {

            int bankId = int.Parse(cmbBankAccount1.SelectedValue.ToString());
            var banka = db.Banks.FirstOrDefault(b => b.BankId == bankId);

            if (banka != null)
            {
                decimal amount = decimal.Parse(txtAmount1.Text);

                // Yeterli bakiye kontrolü
                if (banka.BankBalance >= amount)
                {
                    // Bakiyeyi azalt
                    banka.BankBalance -= amount;

                    BankProcesses bankProcesses = new BankProcesses();
                    bankProcesses.BankId = bankId;
                    bankProcesses.Amount = amount;
                    bankProcesses.Description = txtDescription1.Text;
                    bankProcesses.ProcessDate = DateTime.Now;
                    bankProcesses.ProcessType = "Giden Para Transferi";
                    bankProcesses.PersonInfo = txtPersonInfo1.Text;

                    db.BankProcesses.Add(bankProcesses);
                    db.SaveChanges();

                    MessageBox.Show("Para Transferi Başarılı Bir Şekilde Gerçekleştirildi",
                                    "Banka İşlemleri",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Yetersiz Bakiye!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void btnGetMoney_Click(object sender, EventArgs e)
        {

            int bankId = int.Parse(cmbBankAccount2.SelectedValue.ToString());
            var banka = db.Banks.FirstOrDefault(b => b.BankId == bankId);

            if (banka != null)
            {
                decimal amount = decimal.Parse(txtAmount2.Text);

                // Bakiyeyi artır
                banka.BankBalance += amount;

                BankProcesses bankProcesses = new BankProcesses();
                bankProcesses.BankId = bankId;
                bankProcesses.Amount = amount;
                bankProcesses.Description = txtDescription2.Text;
                bankProcesses.ProcessDate = DateTime.Now;
                bankProcesses.ProcessType = "Gelen Para Transferi";
                bankProcesses.PersonInfo = txtPersonInfo2.Text;

                db.BankProcesses.Add(bankProcesses);
                db.SaveChanges();

                MessageBox.Show("Para Alma İşlemi Başarılı Bir Şekilde Gerçekleştirildi",
                                "Banka İşlemleri",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
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
    }
}
