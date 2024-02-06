#region Using Directives
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;
using ComboBox = System.Windows.Forms.ComboBox;
using TextBox = System.Windows.Forms.TextBox; 
#endregion

namespace Desktop_Windwos_form_application
{
    public class frmEditDiscount: Form
    {
        #region Using Varables
        private Dictionary<string, int> bankDictionary = new Dictionary<string, int>();
        private HttpClient client = new HttpClient();
        private int promotionId;
        private string payMethod;
        private decimal discountNumber;
        private DateTime startDate;
        private DateTime endDate;
        private string productName;
        private Label lbHeadding;
        private Label lbProductId;
        private Label lbProductName;
        private Label lbDiscountId;
        private Label lbPaymentMethod;
        private Label lbStartDate;
        private Label lbDiscountNumber;
        private Label lbIsValid;
        private Label lbEndDate;
        private TextBox txtProductId;
        private TextBox txtDiscountNumber;
        private TextBox txtProductName;
        private TextBox txtDiscountId;
        private RadioButton isValidRadioButton;
        private DateTimePicker startDateTimePicker;
        private DateTimePicker endDateTimePicker2;
        private ComboBox paymentMethodComboBox;
        private bool isValid;
        public string bankName = "";
        private System.Windows.Forms.Button btnSubmit;
        private int discountid;
        #endregion



        #region Using Constructor
        public frmEditDiscount(int discountId, int productId, decimal discountNumber, DateTime startDate, DateTime endDate, bool isValid, string paymentMethod, string productname)
        {
            InitializeComponent();
            FetchBankNames();

            this.discountid = discountId;
            txtProductId.Text = productId.ToString();
            paymentMethodComboBox.SelectedItem = paymentMethod;
            txtDiscountId.Text = discountNumber.ToString();
            txtProductName.Text = productname.ToString();
            txtDiscountNumber.Text = discountNumber.ToString();
            startDateTimePicker.Value = startDate;
            endDateTimePicker2.Value = endDate;
            isValidRadioButton.Checked = isValid;



        }
        #endregion

        #region Using Initalize
        private void InitializeComponent()
        {
            this.lbHeadding = new System.Windows.Forms.Label();
            this.lbProductId = new System.Windows.Forms.Label();
            this.lbProductName = new System.Windows.Forms.Label();
            this.lbDiscountId = new System.Windows.Forms.Label();
            this.lbPaymentMethod = new System.Windows.Forms.Label();
            this.lbStartDate = new System.Windows.Forms.Label();
            this.lbDiscountNumber = new System.Windows.Forms.Label();
            this.lbIsValid = new System.Windows.Forms.Label();
            this.lbEndDate = new System.Windows.Forms.Label();
            this.txtProductId = new System.Windows.Forms.TextBox();
            this.txtDiscountNumber = new System.Windows.Forms.TextBox();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.txtDiscountId = new System.Windows.Forms.TextBox();
            this.isValidRadioButton = new System.Windows.Forms.RadioButton();
            this.startDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.endDateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.paymentMethodComboBox = new System.Windows.Forms.ComboBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbHeadding
            // 
            this.lbHeadding.AutoSize = true;
            this.lbHeadding.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHeadding.Location = new System.Drawing.Point(260, 24);
            this.lbHeadding.Name = "lbHeadding";
            this.lbHeadding.Size = new System.Drawing.Size(126, 25);
            this.lbHeadding.TabIndex = 0;
            this.lbHeadding.Text = "Edit Discount";
            this.lbHeadding.Click += new System.EventHandler(this.lbHeadding_Click);
            // 
            // lbProductId
            // 
            this.lbProductId.AutoSize = true;
            this.lbProductId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbProductId.Location = new System.Drawing.Point(91, 95);
            this.lbProductId.Name = "lbProductId";
            this.lbProductId.Size = new System.Drawing.Size(76, 17);
            this.lbProductId.TabIndex = 1;
            this.lbProductId.Text = "Product Id:";
            this.lbProductId.Click += new System.EventHandler(this.lbProductId_Click);
            // 
            // lbProductName
            // 
            this.lbProductName.AutoSize = true;
            this.lbProductName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbProductName.Location = new System.Drawing.Point(91, 157);
            this.lbProductName.Name = "lbProductName";
            this.lbProductName.Size = new System.Drawing.Size(102, 17);
            this.lbProductName.TabIndex = 2;
            this.lbProductName.Text = "Product Name:";
            this.lbProductName.Click += new System.EventHandler(this.lbProductName_Click);
            // 
            // lbDiscountId
            // 
            this.lbDiscountId.AutoSize = true;
            this.lbDiscountId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDiscountId.Location = new System.Drawing.Point(91, 129);
            this.lbDiscountId.Name = "lbDiscountId";
            this.lbDiscountId.Size = new System.Drawing.Size(82, 17);
            this.lbDiscountId.TabIndex = 3;
            this.lbDiscountId.Text = "Discount Id:";
            this.lbDiscountId.Click += new System.EventHandler(this.lbDiscountId_Click);
            // 
            // lbPaymentMethod
            // 
            this.lbPaymentMethod.AutoSize = true;
            this.lbPaymentMethod.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPaymentMethod.Location = new System.Drawing.Point(91, 186);
            this.lbPaymentMethod.Name = "lbPaymentMethod";
            this.lbPaymentMethod.Size = new System.Drawing.Size(118, 17);
            this.lbPaymentMethod.TabIndex = 4;
            this.lbPaymentMethod.Text = "Payment Method:";
            this.lbPaymentMethod.Click += new System.EventHandler(this.lbPaymentMethod_Click);
            // 
            // lbStartDate
            // 
            this.lbStartDate.AutoSize = true;
            this.lbStartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbStartDate.Location = new System.Drawing.Point(91, 245);
            this.lbStartDate.Name = "lbStartDate";
            this.lbStartDate.Size = new System.Drawing.Size(76, 17);
            this.lbStartDate.TabIndex = 5;
            this.lbStartDate.Text = "Start Date:";
            this.lbStartDate.Click += new System.EventHandler(this.lbStartDate_Click);
            // 
            // lbDiscountNumber
            // 
            this.lbDiscountNumber.AutoSize = true;
            this.lbDiscountNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDiscountNumber.Location = new System.Drawing.Point(91, 217);
            this.lbDiscountNumber.Name = "lbDiscountNumber";
            this.lbDiscountNumber.Size = new System.Drawing.Size(121, 17);
            this.lbDiscountNumber.TabIndex = 6;
            this.lbDiscountNumber.Text = "Discount Number:";
            this.lbDiscountNumber.Click += new System.EventHandler(this.lbdiscountNumber_Click);
            // 
            // lbIsValid
            // 
            this.lbIsValid.AutoSize = true;
            this.lbIsValid.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbIsValid.Location = new System.Drawing.Point(91, 305);
            this.lbIsValid.Name = "lbIsValid";
            this.lbIsValid.Size = new System.Drawing.Size(57, 17);
            this.lbIsValid.TabIndex = 7;
            this.lbIsValid.Text = "Is Valid:";
            this.lbIsValid.Click += new System.EventHandler(this.lbIsValid_Click);
            // 
            // lbEndDate
            // 
            this.lbEndDate.AutoSize = true;
            this.lbEndDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEndDate.Location = new System.Drawing.Point(91, 277);
            this.lbEndDate.Name = "lbEndDate";
            this.lbEndDate.Size = new System.Drawing.Size(71, 17);
            this.lbEndDate.TabIndex = 8;
            this.lbEndDate.Text = "End Date:";
            this.lbEndDate.Click += new System.EventHandler(this.lbEndDate_Click);
            // 
            // txtProductId
            // 
            this.txtProductId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductId.Location = new System.Drawing.Point(235, 92);
            this.txtProductId.Name = "txtProductId";
            this.txtProductId.Size = new System.Drawing.Size(249, 23);
            this.txtProductId.TabIndex = 9;
            this.txtProductId.TextChanged += new System.EventHandler(this.txtProductId_TextChanged);
            // 
            // txtDiscountNumber
            // 
            this.txtDiscountNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiscountNumber.Location = new System.Drawing.Point(235, 214);
            this.txtDiscountNumber.Name = "txtDiscountNumber";
            this.txtDiscountNumber.Size = new System.Drawing.Size(249, 23);
            this.txtDiscountNumber.TabIndex = 12;
            this.txtDiscountNumber.TextChanged += new System.EventHandler(this.txtDiscountNumber_TextChanged);
            // 
            // txtProductName
            // 
            this.txtProductName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductName.Location = new System.Drawing.Point(235, 155);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(249, 23);
            this.txtProductName.TabIndex = 13;
            this.txtProductName.TextChanged += new System.EventHandler(this.txtProductName_TextChanged);
            // 
            // txtDiscountId
            // 
            this.txtDiscountId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiscountId.Location = new System.Drawing.Point(235, 126);
            this.txtDiscountId.Name = "txtDiscountId";
            this.txtDiscountId.Size = new System.Drawing.Size(249, 23);
            this.txtDiscountId.TabIndex = 14;
            this.txtDiscountId.TextChanged += new System.EventHandler(this.txtDiscountId_TextChanged);
            // 
            // isValidRadioButton
            // 
            this.isValidRadioButton.AutoSize = true;
            this.isValidRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.isValidRadioButton.Location = new System.Drawing.Point(235, 303);
            this.isValidRadioButton.Name = "isValidRadioButton";
            this.isValidRadioButton.Size = new System.Drawing.Size(14, 13);
            this.isValidRadioButton.TabIndex = 15;
            this.isValidRadioButton.TabStop = true;
            this.isValidRadioButton.UseVisualStyleBackColor = true;
            this.isValidRadioButton.CheckedChanged += new System.EventHandler(this.isValidRadioButton_CheckedChanged);
            // 
            // startDateTimePicker
            // 
            this.startDateTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startDateTimePicker.Location = new System.Drawing.Point(235, 245);
            this.startDateTimePicker.Name = "startDateTimePicker";
            this.startDateTimePicker.Size = new System.Drawing.Size(249, 23);
            this.startDateTimePicker.TabIndex = 16;
            this.startDateTimePicker.ValueChanged += new System.EventHandler(this.startDateTimePicker_ValueChanged);
            // 
            // endDateTimePicker2
            // 
            this.endDateTimePicker2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.endDateTimePicker2.Location = new System.Drawing.Point(235, 274);
            this.endDateTimePicker2.Name = "endDateTimePicker2";
            this.endDateTimePicker2.Size = new System.Drawing.Size(249, 23);
            this.endDateTimePicker2.TabIndex = 17;
            this.endDateTimePicker2.ValueChanged += new System.EventHandler(this.endDateTimePicker_ValueChanged);
            // 
            // paymentMethodComboBox
            // 
            this.paymentMethodComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paymentMethodComboBox.FormattingEnabled = true;
            this.paymentMethodComboBox.Location = new System.Drawing.Point(235, 186);
            this.paymentMethodComboBox.Name = "paymentMethodComboBox";
            this.paymentMethodComboBox.Size = new System.Drawing.Size(249, 24);
            this.paymentMethodComboBox.TabIndex = 18;
            this.paymentMethodComboBox.SelectedIndexChanged += new System.EventHandler(this.paymentMethodeComboBox_SelectedIndexChanged);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(265, 380);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(109, 40);
            this.btnSubmit.TabIndex = 19;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // frmEditDiscount
            // 
            this.ClientSize = new System.Drawing.Size(593, 445);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.paymentMethodComboBox);
            this.Controls.Add(this.endDateTimePicker2);
            this.Controls.Add(this.startDateTimePicker);
            this.Controls.Add(this.isValidRadioButton);
            this.Controls.Add(this.txtDiscountId);
            this.Controls.Add(this.txtProductName);
            this.Controls.Add(this.txtDiscountNumber);
            this.Controls.Add(this.txtProductId);
            this.Controls.Add(this.lbEndDate);
            this.Controls.Add(this.lbIsValid);
            this.Controls.Add(this.lbDiscountNumber);
            this.Controls.Add(this.lbStartDate);
            this.Controls.Add(this.lbPaymentMethod);
            this.Controls.Add(this.lbDiscountId);
            this.Controls.Add(this.lbProductName);
            this.Controls.Add(this.lbProductId);
            this.Controls.Add(this.lbHeadding);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmEditDiscount";
            this.Text = "Edit Discount";
            this.Load += new System.EventHandler(this.frmEditDiscount_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion



        #region Using Method
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
                    paymentMethodComboBox.DataSource = bankNames;
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




        
        private async void SubmitDataToEndpoint()
        {
            try
            {
                // Assuming you are using HttpClient to send a request to your API endpoint
                var httpClient = new HttpClient();
                var content = new StringContent(JsonConvert.SerializeObject(new
                {
                    ProductId = promotionId,
                    DiscountId = discountid,
                    PaymentMethod = payMethod,
                    DiscountNumber = discountNumber,
                    ProductName = productName,
                    StartDate = startDate,
                    EndDate = endDate,
                    IsValid = isValid
                }), Encoding.UTF8, "application/json");

                var response = await httpClient.PutAsync("https://localhost:7141/discounts/" + discountid, content);

                // Check the response status and handle accordingly
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Data submitted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }
                else
                {
                    MessageBox.Show("Error adding data. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding data. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Using Items

        private async void paymentMethodeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedBankName = paymentMethodComboBox.SelectedItem?.ToString();



            // Optionally, you can use the selected bank name to get the corresponding bank ID from the dictionary
            if (selectedBankName != null && bankDictionary.TryGetValue(selectedBankName, out int selectedBankId))
            {
                // Use the selected bank ID as needed
                Console.WriteLine($"Selected Bank ID: {selectedBankId}");
            }

            if (selectedBankName == null)
            {
                bankName = "ALL";
            }
            else
            {
                bankName = selectedBankName;
            }
        }



        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtProductId.Text, out _))
            {
                MessageBox.Show("Please enter a valid numeric Promotion ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validation for Discount ID
            if (!decimal.TryParse(txtDiscountId.Text, out _))
            {
                MessageBox.Show("Please enter a valid numeric Discount ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validation for Product Name
            if (string.IsNullOrWhiteSpace(txtProductName.Text))
            {
                MessageBox.Show("Please enter a valid Product Name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validation for Discount Number
            if (!decimal.TryParse(txtDiscountNumber.Text, out _))
            {
                MessageBox.Show("Please enter a valid numeric Discount Number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        

            promotionId = int.Parse(txtProductId.Text);
            payMethod = paymentMethodComboBox.SelectedItem?.ToString();
            discountNumber = decimal.Parse(txtDiscountId.Text);
            productName = txtProductName.Text;
            startDate = startDateTimePicker.Value;
            endDate = endDateTimePicker2.Value;
            isValid = isValidRadioButton.Checked;

            // Assuming you have a class or method to handle the submission to the specified endpoint
            SubmitDataToEndpoint();
        }



        private void lbHeadding_Click(object sender, EventArgs e)
        {

        }

        private void lbProductId_Click(object sender, EventArgs e)
        {

        }

        private void lbDiscountId_Click(object sender, EventArgs e)
        {

        }

        private void lbProductName_Click(object sender, EventArgs e)
        {

        }

        private void lbPaymentMethod_Click(object sender, EventArgs e)
        {

        }

        private void lbdiscountNumber_Click(object sender, EventArgs e)
        {

        }

        private void lbEndDate_Click(object sender, EventArgs e)
        {

        }

        private void lbIsValid_Click(object sender, EventArgs e)
        {

        }

        private void frmEditDiscount_Load(object sender, EventArgs e)
        {

        }

        private void lbStartDate_Click(object sender, System.EventArgs e)
        {

        }

        private void txtProductId_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDiscountId_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtProductName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDiscountNumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void startDateTimePicker_ValueChanged(object sender, EventArgs e)
        {

        }

        private void endDateTimePicker_ValueChanged(object sender, EventArgs e)
        {

        }

        private void isValidRadioButton_CheckedChanged(object sender, EventArgs e)
        {

        } 
        #endregion
    }
}