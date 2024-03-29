﻿#region Using Directives
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Windows.Forms; 
#endregion

namespace Desktop_Windwos_form_application
{
    public class frmAddPromotions : Form
    {
        #region Using variables
        private HttpClient client = new HttpClient();
        private Label lbHeadding;
        private Label lbPaymentMethode;
        private Label lbIsValid;
        private Label lbEndDate;
        private Label lbStartDate;
        private Label lbDiscount;
        private Button btnSubmit;
        private TextBox txtDiscountNumber;
        private DateTimePicker startDateTimePicker;
        private DateTimePicker endDateTimePicker;
        private Dictionary<string, int> bankDictionary = new Dictionary<string, int>();
        private Button button2;
        private ComboBox cmbPaymentMethode;
        private TextBox txtLastlyModifiedBy;
        private Label lblLastlyModified;
        public int loggingTo;
        private CheckBox chBoxValidate;
        public string userName;

        #endregion
        #region Using Constructor
        public frmAddPromotions(string username,int logging)
        {
            userName = username;
            loggingTo = logging;
            InitializeComponent();
            FetchBankNames();
        }
        #endregion

        #region Using Initalize
        private void InitializeComponent()
        {
            this.lbHeadding = new System.Windows.Forms.Label();
            this.lbPaymentMethode = new System.Windows.Forms.Label();
            this.lbIsValid = new System.Windows.Forms.Label();
            this.lbEndDate = new System.Windows.Forms.Label();
            this.lbStartDate = new System.Windows.Forms.Label();
            this.lbDiscount = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.txtDiscountNumber = new System.Windows.Forms.TextBox();
            this.startDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.endDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.button2 = new System.Windows.Forms.Button();
            this.cmbPaymentMethode = new System.Windows.Forms.ComboBox();
            this.txtLastlyModifiedBy = new System.Windows.Forms.TextBox();
            this.lblLastlyModified = new System.Windows.Forms.Label();
            this.chBoxValidate = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lbHeadding
            // 
            this.lbHeadding.AutoSize = true;
            this.lbHeadding.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHeadding.Location = new System.Drawing.Point(201, 18);
            this.lbHeadding.Name = "lbHeadding";
            this.lbHeadding.Size = new System.Drawing.Size(141, 25);
            this.lbHeadding.TabIndex = 0;
            this.lbHeadding.Text = "Add Promotion";
            this.lbHeadding.Click += new System.EventHandler(this.lbHeadding_Click);
            // 
            // lbPaymentMethode
            // 
            this.lbPaymentMethode.AutoSize = true;
            this.lbPaymentMethode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPaymentMethode.Location = new System.Drawing.Point(46, 81);
            this.lbPaymentMethode.Name = "lbPaymentMethode";
            this.lbPaymentMethode.Size = new System.Drawing.Size(118, 17);
            this.lbPaymentMethode.TabIndex = 1;
            this.lbPaymentMethode.Text = "Payment Method:";
            this.lbPaymentMethode.Click += new System.EventHandler(this.lbPaymentMethod_Click);
            // 
            // lbIsValid
            // 
            this.lbIsValid.AutoSize = true;
            this.lbIsValid.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbIsValid.Location = new System.Drawing.Point(46, 220);
            this.lbIsValid.Name = "lbIsValid";
            this.lbIsValid.Size = new System.Drawing.Size(57, 17);
            this.lbIsValid.TabIndex = 4;
            this.lbIsValid.Text = "Is Valid:";
            this.lbIsValid.Click += new System.EventHandler(this.lbIsValid_Click);
            // 
            // lbEndDate
            // 
            this.lbEndDate.AutoSize = true;
            this.lbEndDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEndDate.Location = new System.Drawing.Point(46, 183);
            this.lbEndDate.Name = "lbEndDate";
            this.lbEndDate.Size = new System.Drawing.Size(71, 17);
            this.lbEndDate.TabIndex = 5;
            this.lbEndDate.Text = "End Date:";
            this.lbEndDate.Click += new System.EventHandler(this.lbEnd_Click);
            // 
            // lbStartDate
            // 
            this.lbStartDate.AutoSize = true;
            this.lbStartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbStartDate.Location = new System.Drawing.Point(46, 154);
            this.lbStartDate.Name = "lbStartDate";
            this.lbStartDate.Size = new System.Drawing.Size(76, 17);
            this.lbStartDate.TabIndex = 6;
            this.lbStartDate.Text = "Start Date:";
            this.lbStartDate.Click += new System.EventHandler(this.lbStart_Click);
            // 
            // lbDiscount
            // 
            this.lbDiscount.AutoSize = true;
            this.lbDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDiscount.Location = new System.Drawing.Point(46, 118);
            this.lbDiscount.Name = "lbDiscount";
            this.lbDiscount.Size = new System.Drawing.Size(121, 17);
            this.lbDiscount.TabIndex = 7;
            this.lbDiscount.Text = "Discount Number:";
            this.lbDiscount.Click += new System.EventHandler(this.lbDiscountNumber_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(206, 294);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(109, 43);
            this.btnSubmit.TabIndex = 8;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // txtDiscountNumber
            // 
            this.txtDiscountNumber.Location = new System.Drawing.Point(206, 118);
            this.txtDiscountNumber.Name = "txtDiscountNumber";
            this.txtDiscountNumber.Size = new System.Drawing.Size(200, 20);
            this.txtDiscountNumber.TabIndex = 14;
            this.txtDiscountNumber.TextChanged += new System.EventHandler(this.txtDiscountNumber_TextChanged);
            // 
            // startDateTimePicker
            // 
            this.startDateTimePicker.Location = new System.Drawing.Point(206, 154);
            this.startDateTimePicker.Name = "startDateTimePicker";
            this.startDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.startDateTimePicker.TabIndex = 16;
            this.startDateTimePicker.ValueChanged += new System.EventHandler(this.startDateTimePicker_ValueChanged);
            // 
            // endDateTimePicker
            // 
            this.endDateTimePicker.Location = new System.Drawing.Point(206, 183);
            this.endDateTimePicker.Name = "endDateTimePicker";
            this.endDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.endDateTimePicker.TabIndex = 17;
            this.endDateTimePicker.ValueChanged += new System.EventHandler(this.endDateTimePicker2_ValueChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(47, 13);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(42, 30);
            this.button2.TabIndex = 18;
            this.button2.Text = "<-";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btnBack);
            // 
            // cmbPaymentMethode
            // 
            this.cmbPaymentMethode.FormattingEnabled = true;
            this.cmbPaymentMethode.Location = new System.Drawing.Point(206, 85);
            this.cmbPaymentMethode.Name = "cmbPaymentMethode";
            this.cmbPaymentMethode.Size = new System.Drawing.Size(200, 21);
            this.cmbPaymentMethode.TabIndex = 19;
            this.cmbPaymentMethode.SelectedIndexChanged += new System.EventHandler(this.cmbPaymentMethode_SelectedIndexChanged);
            // 
            // txtLastlyModifiedBy
            // 
            this.txtLastlyModifiedBy.Location = new System.Drawing.Point(206, 252);
            this.txtLastlyModifiedBy.Name = "txtLastlyModifiedBy";
            this.txtLastlyModifiedBy.Size = new System.Drawing.Size(196, 20);
            this.txtLastlyModifiedBy.TabIndex = 20;
            this.txtLastlyModifiedBy.TextChanged += new System.EventHandler(this.txtLastlyModifiedBy_TextChanged);
            // 
            // lblLastlyModified
            // 
            this.lblLastlyModified.AutoSize = true;
            this.lblLastlyModified.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastlyModified.Location = new System.Drawing.Point(46, 253);
            this.lblLastlyModified.Name = "lblLastlyModified";
            this.lblLastlyModified.Size = new System.Drawing.Size(106, 17);
            this.lblLastlyModified.TabIndex = 21;
            this.lblLastlyModified.Text = "Lastly Modified:";
            // 
            // chBoxValidate
            // 
            this.chBoxValidate.AutoSize = true;
            this.chBoxValidate.Location = new System.Drawing.Point(206, 223);
            this.chBoxValidate.Name = "chBoxValidate";
            this.chBoxValidate.Size = new System.Drawing.Size(15, 14);
            this.chBoxValidate.TabIndex = 22;
            this.chBoxValidate.UseVisualStyleBackColor = true;
            this.chBoxValidate.CheckedChanged += new System.EventHandler(this.chBoxValidate_CheckedChanged);
            // 
            // frmAddPromotions
            // 
            this.ClientSize = new System.Drawing.Size(491, 376);
            this.Controls.Add(this.chBoxValidate);
            this.Controls.Add(this.lblLastlyModified);
            this.Controls.Add(this.txtLastlyModifiedBy);
            this.Controls.Add(this.cmbPaymentMethode);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.endDateTimePicker);
            this.Controls.Add(this.startDateTimePicker);
            this.Controls.Add(this.txtDiscountNumber);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.lbDiscount);
            this.Controls.Add(this.lbStartDate);
            this.Controls.Add(this.lbEndDate);
            this.Controls.Add(this.lbIsValid);
            this.Controls.Add(this.lbPaymentMethode);
            this.Controls.Add(this.lbHeadding);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmAddPromotions";
            this.Text = "Add Promotion ";
            this.Load += new System.EventHandler(this.frmAddPromotions_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion



        #region Using Method
       

        private int GenerateBillNumber()
        {
            // Your logic to generate a unique bill number
            return new Random().Next(1000, 9999);
        }


        private async void FetchBankNames()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("https://localhost:7141/api/banks");

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    var bankObjects = JsonConvert.DeserializeObject<List<BankModelDTO>>(content);

                    // Extract bank names from bankObjects
                    var bankNames = bankObjects.Select(bank => bank.BankName).ToList();
                    // Bind the bank names to the Picker control
                    cmbPaymentMethode.DataSource = bankNames;
                    foreach (var bank in bankObjects)
                    {
                        bankDictionary[bank.BankName] = bank.BankId; // Assuming BankId is the property representing the ID
                    }
                }
                else
                {
                    // Handle the case where the response is unsuccessful
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
            }
        }

        private async void SubmitFormToAPI(int billNumber, string paymentMethod, decimal discountNumber, DateTime startDate, DateTime endDate, bool isValid, string lastlyModified)
        {

            var formData = new
            {
                PromotionId = billNumber,
                PayMethod = paymentMethod,
                DiscountNumber = discountNumber,
                StartDate = startDate,
                EndDate = endDate,
                IsValid = isValid,
                LastModifiedBy = lastlyModified,
                LastModifiedDate = DateTime.Now.ToString("yyyy-MM-dd")


            };

            var jsonData = JsonConvert.SerializeObject(formData);


            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var client = new HttpClient();
            var response = await client.PostAsync("https://localhost:7141/promotions", content);
            if (response.IsSuccessStatusCode)
            {
                // Display a success message
                MessageBox.Show($"Bill Number: {billNumber}\nPayment Method: {paymentMethod}\nDiscount Number: {discountNumber}\nStart Date: {startDate}\nEnd Date: {endDate}\nIsValid: {isValid}\nData added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Clear the input fields
                cmbPaymentMethode.SelectedIndex = -1;
                txtDiscountNumber.Clear();
                startDateTimePicker.Value = DateTime.Now; // Set to current date and time
                endDateTimePicker.Value = DateTime.Now; // Set to current date and time
                chBoxValidate.Checked = false; // Set to initial state
                MessageBox.Show("Data added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                // Display an error message
                MessageBox.Show("Error adding data. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        #endregion


        #region Using Item


        private void btnBack(object sender, EventArgs e)
        {
            frmMainPage mianPage = new frmMainPage(loggingTo,userName);
            mianPage.Show();
            this.Hide();
        }


        private void btnSubmit_Click(object sender, System.EventArgs e)
        {

            if (!decimal.TryParse(txtDiscountNumber.Text, out decimal discount) || discount < 0)
            {
                MessageBox.Show("Please enter a valid non-negative discount number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            // Retrieve values from the form
            int billNumber = GenerateBillNumber(); // You can generate this based on your logic
            string paymentMethod = cmbPaymentMethode.SelectedItem as string;
            decimal discountNumber = decimal.Parse(txtDiscountNumber.Text); // Assuming discount number is an integer
            DateTime startDate = startDateTimePicker.Value;
            DateTime endDate = endDateTimePicker.Value;
            bool isValid = chBoxValidate.Checked;
            string lastmodified = txtLastlyModifiedBy.Text;
            // Perform actions with the retrieved values (e.g., send them to an API, process them, etc.)
            // For example:
            SubmitFormToAPI(billNumber, paymentMethod, discountNumber, startDate, endDate, isValid, lastmodified);

        }


        private void lbDiscountNumber_Click(object sender, System.EventArgs e)
        {

        }

        private void txtPaymentMethode_TextChanged(object sender, System.EventArgs e)
        {

        }

        private void txtDiscountNumber_TextChanged(object sender, System.EventArgs e)
        {

        }

        private void startDateTimePicker_ValueChanged(object sender, System.EventArgs e)
        {

        }

        private void endDateTimePicker2_ValueChanged(object sender, System.EventArgs e)
        {

        }

        private void isValidradioButton_CheckedChanged(object sender, System.EventArgs e)
        {

        }


        private void lbHeadding_Click(object sender, EventArgs e)
        {

        }

        private void lbPaymentMethod_Click(object sender, EventArgs e)
        {

        }

        private void lbStart_Click(object sender, EventArgs e)
        {

        }

        private void lbEnd_Click(object sender, EventArgs e)
        {

        }

        private void lbIsValid_Click(object sender, EventArgs e)
        {

        }

        private void frmAddPromotions_Load(object sender, EventArgs e)
        {

        }

        private void cmbPaymentMethode_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtLastlyModifiedBy_TextChanged(object sender, EventArgs e)
        {

        }


        #endregion

        private void chBoxValidate_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}