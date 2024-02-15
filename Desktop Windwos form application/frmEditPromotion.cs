#region Using Directives
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Windows.Forms; 
#endregion

namespace Desktop_Windwos_form_application
{
    public class frmEditPromotion: Form
    {
        #region Uisng Variables
        private Label lbHeadding;
        private Label lbPaymentMethod;
        private Label lbDiscountNumber;
        private Label lbStartDate;
        private Label lbEndDate;
        private TextBox txtPaymentMethode;
        private TextBox txtDiscountNumber;
        private DateTimePicker startDateTimePicker;
        private DateTimePicker endDateTimePicker;
        private RadioButton isValidRadioButton;
        private Button btnSubmit;
        private Label lbisValid;
        private TextBox txtLastlyModified;
        private Label lblLastlyModified;
        public int billNumber;
        #endregion

        #region Using Constructor

        public frmEditPromotion(string promotionid, string payMethod, decimal discountNumber, DateTime startDate, DateTime endDate, bool isValid)
        {
            if (int.TryParse(promotionid, out int parsedBillNumber))
            {
                billNumber = parsedBillNumber;
            }            // Your existing initialization code
            InitializeComponent();
            // Add initialization for additional data
            txtPaymentMethode.Text = payMethod;
            txtDiscountNumber.Text = discountNumber.ToString();
            startDateTimePicker.Value = startDate;
            endDateTimePicker.Value = endDate;
            isValidRadioButton.Checked = isValid;
        }
        #endregion

        #region Using Initialize

        private void InitializeComponent()
        {
            this.lbHeadding = new System.Windows.Forms.Label();
            this.lbPaymentMethod = new System.Windows.Forms.Label();
            this.lbDiscountNumber = new System.Windows.Forms.Label();
            this.lbStartDate = new System.Windows.Forms.Label();
            this.lbEndDate = new System.Windows.Forms.Label();
            this.lbisValid = new System.Windows.Forms.Label();
            this.txtPaymentMethode = new System.Windows.Forms.TextBox();
            this.txtDiscountNumber = new System.Windows.Forms.TextBox();
            this.startDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.endDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.isValidRadioButton = new System.Windows.Forms.RadioButton();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.txtLastlyModified = new System.Windows.Forms.TextBox();
            this.lblLastlyModified = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbHeadding
            // 
            this.lbHeadding.AutoSize = true;
            this.lbHeadding.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHeadding.Location = new System.Drawing.Point(290, 9);
            this.lbHeadding.Name = "lbHeadding";
            this.lbHeadding.Size = new System.Drawing.Size(136, 25);
            this.lbHeadding.TabIndex = 0;
            this.lbHeadding.Text = "Edit promotion";
            this.lbHeadding.Click += new System.EventHandler(this.lbHeadding_Click);
            // 
            // lbPaymentMethod
            // 
            this.lbPaymentMethod.AutoSize = true;
            this.lbPaymentMethod.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPaymentMethod.Location = new System.Drawing.Point(53, 61);
            this.lbPaymentMethod.Name = "lbPaymentMethod";
            this.lbPaymentMethod.Size = new System.Drawing.Size(118, 17);
            this.lbPaymentMethod.TabIndex = 1;
            this.lbPaymentMethod.Text = "Payment Method:";
            this.lbPaymentMethod.Click += new System.EventHandler(this.lbPaymentMethode_Click);
            // 
            // lbDiscountNumber
            // 
            this.lbDiscountNumber.AutoSize = true;
            this.lbDiscountNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDiscountNumber.Location = new System.Drawing.Point(53, 99);
            this.lbDiscountNumber.Name = "lbDiscountNumber";
            this.lbDiscountNumber.Size = new System.Drawing.Size(121, 17);
            this.lbDiscountNumber.TabIndex = 2;
            this.lbDiscountNumber.Text = "Discount Number:";
            this.lbDiscountNumber.Click += new System.EventHandler(this.lbDiscountNumber_Click);
            // 
            // lbStartDate
            // 
            this.lbStartDate.AutoSize = true;
            this.lbStartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbStartDate.Location = new System.Drawing.Point(53, 138);
            this.lbStartDate.Name = "lbStartDate";
            this.lbStartDate.Size = new System.Drawing.Size(76, 17);
            this.lbStartDate.TabIndex = 3;
            this.lbStartDate.Text = "Start Date ";
            this.lbStartDate.Click += new System.EventHandler(this.lbStartDate_Click);
            // 
            // lbEndDate
            // 
            this.lbEndDate.AutoSize = true;
            this.lbEndDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEndDate.Location = new System.Drawing.Point(53, 177);
            this.lbEndDate.Name = "lbEndDate";
            this.lbEndDate.Size = new System.Drawing.Size(67, 17);
            this.lbEndDate.TabIndex = 4;
            this.lbEndDate.Text = "End Date";
            this.lbEndDate.Click += new System.EventHandler(this.lbEnddate_Click);
            // 
            // lbisValid
            // 
            this.lbisValid.AutoSize = true;
            this.lbisValid.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbisValid.Location = new System.Drawing.Point(53, 215);
            this.lbisValid.Name = "lbisValid";
            this.lbisValid.Size = new System.Drawing.Size(57, 17);
            this.lbisValid.TabIndex = 6;
            this.lbisValid.Text = "Is Valid:";
            this.lbisValid.Click += new System.EventHandler(this.lbIsValid_Click);
            // 
            // txtPaymentMethode
            // 
            this.txtPaymentMethode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPaymentMethode.Location = new System.Drawing.Point(238, 59);
            this.txtPaymentMethode.Name = "txtPaymentMethode";
            this.txtPaymentMethode.Size = new System.Drawing.Size(249, 23);
            this.txtPaymentMethode.TabIndex = 7;
            this.txtPaymentMethode.TextChanged += new System.EventHandler(this.txtPaymentMethode_TextChanged);
            // 
            // txtDiscountNumber
            // 
            this.txtDiscountNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiscountNumber.Location = new System.Drawing.Point(238, 93);
            this.txtDiscountNumber.Name = "txtDiscountNumber";
            this.txtDiscountNumber.ReadOnly = true;
            this.txtDiscountNumber.Size = new System.Drawing.Size(249, 23);
            this.txtDiscountNumber.TabIndex = 12;
            this.txtDiscountNumber.TextChanged += new System.EventHandler(this.txtDiscountNumber_TextChanged);
            // 
            // startDateTimePicker
            // 
            this.startDateTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startDateTimePicker.Location = new System.Drawing.Point(238, 139);
            this.startDateTimePicker.Name = "startDateTimePicker";
            this.startDateTimePicker.Size = new System.Drawing.Size(249, 23);
            this.startDateTimePicker.TabIndex = 13;
            this.startDateTimePicker.ValueChanged += new System.EventHandler(this.startDateTimePicker_ValueChanged);
            // 
            // endDateTimePicker
            // 
            this.endDateTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.endDateTimePicker.Location = new System.Drawing.Point(238, 178);
            this.endDateTimePicker.Name = "endDateTimePicker";
            this.endDateTimePicker.Size = new System.Drawing.Size(249, 23);
            this.endDateTimePicker.TabIndex = 14;
            this.endDateTimePicker.ValueChanged += new System.EventHandler(this.endDateTimePicker2_ValueChanged);
            // 
            // isValidRadioButton
            // 
            this.isValidRadioButton.AutoSize = true;
            this.isValidRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.isValidRadioButton.Location = new System.Drawing.Point(238, 225);
            this.isValidRadioButton.Name = "isValidRadioButton";
            this.isValidRadioButton.Size = new System.Drawing.Size(14, 13);
            this.isValidRadioButton.TabIndex = 15;
            this.isValidRadioButton.TabStop = true;
            this.isValidRadioButton.UseVisualStyleBackColor = true;
            this.isValidRadioButton.CheckedChanged += new System.EventHandler(this.isAvalableRadioButton_CheckedChanged);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.Location = new System.Drawing.Point(295, 314);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(85, 33);
            this.btnSubmit.TabIndex = 16;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // txtLastlyModified
            // 
            this.txtLastlyModified.Location = new System.Drawing.Point(238, 255);
            this.txtLastlyModified.Name = "txtLastlyModified";
            this.txtLastlyModified.Size = new System.Drawing.Size(249, 20);
            this.txtLastlyModified.TabIndex = 17;
            this.txtLastlyModified.TextChanged += new System.EventHandler(this.txtLastlyModified_TextChanged);
            // 
            // lblLastlyModified
            // 
            this.lblLastlyModified.AutoSize = true;
            this.lblLastlyModified.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastlyModified.Location = new System.Drawing.Point(52, 256);
            this.lblLastlyModified.Name = "lblLastlyModified";
            this.lblLastlyModified.Size = new System.Drawing.Size(102, 17);
            this.lblLastlyModified.TabIndex = 18;
            this.lblLastlyModified.Text = "Lastly Modified";
            // 
            // frmEditPromotion
            // 
            this.ClientSize = new System.Drawing.Size(675, 414);
            this.Controls.Add(this.lblLastlyModified);
            this.Controls.Add(this.txtLastlyModified);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.isValidRadioButton);
            this.Controls.Add(this.endDateTimePicker);
            this.Controls.Add(this.startDateTimePicker);
            this.Controls.Add(this.txtDiscountNumber);
            this.Controls.Add(this.txtPaymentMethode);
            this.Controls.Add(this.lbisValid);
            this.Controls.Add(this.lbEndDate);
            this.Controls.Add(this.lbStartDate);
            this.Controls.Add(this.lbDiscountNumber);
            this.Controls.Add(this.lbPaymentMethod);
            this.Controls.Add(this.lbHeadding);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmEditPromotion";
            this.Text = "Edit Promotion";
            this.Load += new System.EventHandler(this.frmEditPromotion_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        #region Using Items

        private void txtPaymentMethode_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDiscountNumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void startDateTimePicker_ValueChanged(object sender, EventArgs e)
        {

        }

        private void endDateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void isAvalableRadioButton_CheckedChanged(object sender, EventArgs e)
        {

        }





        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPaymentMethode.Text))
            {
                MessageBox.Show("Please enter a valid Payment Method.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validate Discount Number
            if (!decimal.TryParse(txtDiscountNumber.Text, out _))
            {
                MessageBox.Show("Please enter a valid numeric Discount Number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            string paymentMethod = txtPaymentMethode.Text;
            decimal discountNumber = decimal.Parse(txtDiscountNumber.Text);
            DateTime startDate = startDateTimePicker.Value;
            DateTime endDate = endDateTimePicker.Value;
            bool isValid = isValidRadioButton.Checked;
            string lastlyModified = txtLastlyModified.Text;
            // Create an object to send to the API
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

            // Convert the object to JSON
            var jsonData = JsonConvert.SerializeObject(formData);
            var client = new HttpClient();
            var endpoint = $"https://localhost:7141/promotions/{billNumber}";
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PutAsync(endpoint, content);

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Data submitted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error adding data. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lbHeadding_Click(object sender, EventArgs e)
        {

        }

        private void lbPaymentMethode_Click(object sender, EventArgs e)
        {

        }

        private void lbDiscountNumber_Click(object sender, EventArgs e)
        {

        }

        private void lbStartDate_Click(object sender, EventArgs e)
        {

        }

        private void lbEnddate_Click(object sender, EventArgs e)
        {

        }

        private void lbIsValid_Click(object sender, EventArgs e)
        {

        }

        private void frmEditPromotion_Load(object sender, EventArgs e)
        {

        }
        private void txtLastlyModified_TextChanged(object sender, EventArgs e)
        {

        }
        #endregion


    }
}