#region Using Directives
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System;
using System.Windows.Forms; 
#endregion

namespace Desktop_Windwos_form_application
{
    public class frmAddBank: Form
    {
        #region using private
        private Button btnBackNutton;
        private Label lbHedding;
        private Label lbBankId;
        private Label lbBankName;
        private TextBox txtBankId;
        private TextBox txtBookName;
        private Button A;
        public int loggingTo;
        #endregion
        #region using constructor
        public frmAddBank(int logging)
        {
            InitializeComponent();
            loggingTo = logging;
        }

        #endregion
        #region using initialize
        private void InitializeComponent()
        {
            this.btnBackNutton = new System.Windows.Forms.Button();
            this.lbHedding = new System.Windows.Forms.Label();
            this.lbBankId = new System.Windows.Forms.Label();
            this.lbBankName = new System.Windows.Forms.Label();
            this.txtBankId = new System.Windows.Forms.TextBox();
            this.txtBookName = new System.Windows.Forms.TextBox();
            this.A = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnBackNutton
            // 
            this.btnBackNutton.Location = new System.Drawing.Point(103, 31);
            this.btnBackNutton.Name = "btnBackNutton";
            this.btnBackNutton.Size = new System.Drawing.Size(54, 35);
            this.btnBackNutton.TabIndex = 0;
            this.btnBackNutton.Text = "<-";
            this.btnBackNutton.UseVisualStyleBackColor = true;
            this.btnBackNutton.Click += new System.EventHandler(this.btnBack);
            // 
            // lbHedding
            // 
            this.lbHedding.AutoSize = true;
            this.lbHedding.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHedding.Location = new System.Drawing.Point(466, 41);
            this.lbHedding.Name = "lbHedding";
            this.lbHedding.Size = new System.Drawing.Size(98, 25);
            this.lbHedding.TabIndex = 1;
            this.lbHedding.Text = "Add Bank";
            this.lbHedding.Click += new System.EventHandler(this.lbHeadding_Click);
            // 
            // lbBankId
            // 
            this.lbBankId.AutoSize = true;
            this.lbBankId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbBankId.Location = new System.Drawing.Point(100, 161);
            this.lbBankId.Name = "lbBankId";
            this.lbBankId.Size = new System.Drawing.Size(57, 17);
            this.lbBankId.TabIndex = 2;
            this.lbBankId.Text = "Bank ID";
            this.lbBankId.Click += new System.EventHandler(this.lbBankId_Click);
            // 
            // lbBankName
            // 
            this.lbBankName.AutoSize = true;
            this.lbBankName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbBankName.Location = new System.Drawing.Point(100, 199);
            this.lbBankName.Name = "lbBankName";
            this.lbBankName.Size = new System.Drawing.Size(81, 17);
            this.lbBankName.TabIndex = 3;
            this.lbBankName.Text = "Bank Name";
            this.lbBankName.Click += new System.EventHandler(this.lbBankName_Click);
            // 
            // txtBankId
            // 
            this.txtBankId.Location = new System.Drawing.Point(227, 161);
            this.txtBankId.Name = "txtBankId";
            this.txtBankId.Size = new System.Drawing.Size(221, 20);
            this.txtBankId.TabIndex = 4;
            this.txtBankId.TextChanged += new System.EventHandler(this.txtBookId_TextChanged);
            // 
            // txtBookName
            // 
            this.txtBookName.Location = new System.Drawing.Point(227, 199);
            this.txtBookName.Name = "txtBookName";
            this.txtBookName.Size = new System.Drawing.Size(221, 20);
            this.txtBookName.TabIndex = 5;
            this.txtBookName.TextChanged += new System.EventHandler(this.txtBookName_TextChanged);
            // 
            // A
            // 
            this.A.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.A.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.A.Location = new System.Drawing.Point(443, 366);
            this.A.Name = "A";
            this.A.Size = new System.Drawing.Size(174, 44);
            this.A.TabIndex = 6;
            this.A.Text = "Submit";
            this.A.UseVisualStyleBackColor = false;
            this.A.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // frmAddBank
            // 
            this.ClientSize = new System.Drawing.Size(1023, 516);
            this.Controls.Add(this.A);
            this.Controls.Add(this.txtBookName);
            this.Controls.Add(this.txtBankId);
            this.Controls.Add(this.lbBankName);
            this.Controls.Add(this.lbBankId);
            this.Controls.Add(this.lbHedding);
            this.Controls.Add(this.btnBackNutton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmAddBank";
            this.Text = "Add Bank";
            this.Load += new System.EventHandler(this.AddBank_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        #region using items
        private void AddBank_Load(object sender, System.EventArgs e)
        {

        }

        private void txtBookId_TextChanged(object sender, System.EventArgs e)
        {

        }

        private void txtBookName_TextChanged(object sender, System.EventArgs e)
        {

        }

        private void lbHeadding_Click(object sender, EventArgs e)
        {

        }

        private void lbBankId_Click(object sender, EventArgs e)
        {

        }

        private void lbBankName_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region using methode
        private async void btnSubmit_Click(object sender, System.EventArgs e)
        {
            string BankName = txtBookName.Text; // Get the bank name from the Entry field
            if (int.TryParse(txtBankId.Text, out int BankId))
            {
                try
                {
                    var httpClient = new HttpClient();
                    var url = "https://localhost:7141/api/banks";

                    var bankDetails = new
                    {
                        bankId = BankId,
                        bankName = BankName
                    };

                    var jsonBankDetails = JsonConvert.SerializeObject(bankDetails);
                    var content = new StringContent(jsonBankDetails, Encoding.UTF8, "application/json");

                    var response = await httpClient.PostAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        // Clear the input fields
                        txtBankId.Clear();
                        txtBookName.Clear();

                        // Show a success message
                        MessageBox.Show("Bank details added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        // Failed to add bank details
                        MessageBox.Show("Failed to add bank details. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    // Handle exceptions here
                }
            }
            else
            {
            }
            if (!string.IsNullOrEmpty(BankName))
            {


            }
            else
            {
            }
        }



        private void btnBack(object sender, EventArgs e)
        {
            frmMainPage mianPage = new frmMainPage(loggingTo);
            mianPage.Show();
            this.Hide();
        } 
        #endregion


    }
}