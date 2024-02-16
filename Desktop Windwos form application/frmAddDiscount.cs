#region using Directives

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Windows.Forms;
using TextBox = System.Windows.Forms.TextBox; 
#endregion

namespace Desktop_Windwos_form_application
{
    public class frmAddDiscount: Form
    {
        #region using variables

        private HttpClient client = new HttpClient();
        private Label label1;
        private Label label2;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private TextBox txtProductId;
        private TextBox txtDiscountNumber;
        private TextBox txtProductName;
        private System.Windows.Forms.ComboBox cmbPaymentMethode;
        private int loggingTo;
        private Dictionary<string, int> bankDictionary = new Dictionary<string, int>();
        private DateTimePicker startDateTimePicker;
        private DateTimePicker endDateTimePicker;
        private RadioButton isValidRadioButton;
        private Dictionary<string, decimal> productPromotion = new Dictionary<string, decimal>();
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button button2;
        public string bankName = "";
        public string Namepro = "";
        private TextBox txtLastlyModifiedperson;
        private Label lblLastlyAddedPerson;
        public string Id;
        public string userName;

        #endregion

        #region using constructor
        public frmAddDiscount(int logging, string productId, string productname)
        {
            Namepro = productname;
            Id = productId;
            loggingTo = logging;
            InitializeComponent();
            FetchBankNames();
            txtProductId.Text = Id;
            txtProductName.Text = Namepro;
        }
        #endregion

        #region using initalize

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtProductId = new System.Windows.Forms.TextBox();
            this.txtDiscountNumber = new System.Windows.Forms.TextBox();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.cmbPaymentMethode = new System.Windows.Forms.ComboBox();
            this.startDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.endDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.isValidRadioButton = new System.Windows.Forms.RadioButton();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.txtLastlyModifiedperson = new System.Windows.Forms.TextBox();
            this.lblLastlyAddedPerson = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(210, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Add Discount";
            this.label1.Click += new System.EventHandler(this.lbHeadding_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(58, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Product ID:";
            this.label2.Click += new System.EventHandler(this.lbProductId_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(58, 326);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Is Valid";
            this.label4.Click += new System.EventHandler(this.lbIsValid_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(58, 287);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "End Date:";
            this.label5.Click += new System.EventHandler(this.lbEnd_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(58, 245);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 17);
            this.label6.TabIndex = 5;
            this.label6.Text = "Start Date:";
            this.label6.Click += new System.EventHandler(this.lbStartDate_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(58, 206);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(121, 17);
            this.label7.TabIndex = 6;
            this.label7.Text = "Discount Number:";
            this.label7.Click += new System.EventHandler(this.lbDiscountNumber_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(58, 173);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(114, 17);
            this.label8.TabIndex = 7;
            this.label8.Text = "Payment Method";
            this.label8.Click += new System.EventHandler(this.lbPaymentMethod_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(58, 136);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(102, 17);
            this.label9.TabIndex = 8;
            this.label9.Text = "Product Name:";
            this.label9.Click += new System.EventHandler(this.lbProductName_Click);
            // 
            // txtProductId
            // 
            this.txtProductId.Location = new System.Drawing.Point(198, 99);
            this.txtProductId.Name = "txtProductId";
            this.txtProductId.Size = new System.Drawing.Size(199, 20);
            this.txtProductId.TabIndex = 9;
            this.txtProductId.TextChanged += new System.EventHandler(this.txtproductId_TextChanged);
            // 
            // txtDiscountNumber
            // 
            this.txtDiscountNumber.Location = new System.Drawing.Point(198, 205);
            this.txtDiscountNumber.Name = "txtDiscountNumber";
            this.txtDiscountNumber.Size = new System.Drawing.Size(199, 20);
            this.txtDiscountNumber.TabIndex = 14;
            this.txtDiscountNumber.TextChanged += new System.EventHandler(this.textBox6_TextChanged);
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(198, 136);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(199, 20);
            this.txtProductName.TabIndex = 15;
            this.txtProductName.TextChanged += new System.EventHandler(this.txtProductName_TextChanged);
            // 
            // cmbPaymentMethode
            // 
            this.cmbPaymentMethode.FormattingEnabled = true;
            this.cmbPaymentMethode.Location = new System.Drawing.Point(198, 173);
            this.cmbPaymentMethode.Name = "cmbPaymentMethode";
            this.cmbPaymentMethode.Size = new System.Drawing.Size(199, 21);
            this.cmbPaymentMethode.TabIndex = 16;
            this.cmbPaymentMethode.SelectedIndexChanged += new System.EventHandler(this.cmbPaymentMethode_SelectedIndexChanged_1);
            // 
            // startDateTimePicker
            // 
            this.startDateTimePicker.Location = new System.Drawing.Point(198, 241);
            this.startDateTimePicker.Name = "startDateTimePicker";
            this.startDateTimePicker.Size = new System.Drawing.Size(199, 20);
            this.startDateTimePicker.TabIndex = 17;
            this.startDateTimePicker.ValueChanged += new System.EventHandler(this.dtpStartDate_ValueChanged);
            // 
            // endDateTimePicker
            // 
            this.endDateTimePicker.Location = new System.Drawing.Point(198, 283);
            this.endDateTimePicker.Name = "endDateTimePicker";
            this.endDateTimePicker.Size = new System.Drawing.Size(199, 20);
            this.endDateTimePicker.TabIndex = 18;
            this.endDateTimePicker.ValueChanged += new System.EventHandler(this.dtpEndDate_ValueChanged);
            // 
            // isValidRadioButton
            // 
            this.isValidRadioButton.AutoSize = true;
            this.isValidRadioButton.Location = new System.Drawing.Point(198, 328);
            this.isValidRadioButton.Name = "isValidRadioButton";
            this.isValidRadioButton.Size = new System.Drawing.Size(14, 13);
            this.isValidRadioButton.TabIndex = 19;
            this.isValidRadioButton.TabStop = true;
            this.isValidRadioButton.UseVisualStyleBackColor = true;
            this.isValidRadioButton.CheckedChanged += new System.EventHandler(this.rbIsValid_CheckedChanged);
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.Location = new System.Drawing.Point(156, 433);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(114, 40);
            this.btnSubmit.TabIndex = 20;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(61, 15);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(50, 33);
            this.button2.TabIndex = 21;
            this.button2.Text = "<-";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtLastlyModifiedperson
            // 
            this.txtLastlyModifiedperson.Location = new System.Drawing.Point(198, 372);
            this.txtLastlyModifiedperson.Name = "txtLastlyModifiedperson";
            this.txtLastlyModifiedperson.Size = new System.Drawing.Size(199, 20);
            this.txtLastlyModifiedperson.TabIndex = 22;
            this.txtLastlyModifiedperson.TextChanged += new System.EventHandler(this.txtLastlyModifiedperson_TextChanged);
            // 
            // lblLastlyAddedPerson
            // 
            this.lblLastlyAddedPerson.AutoSize = true;
            this.lblLastlyAddedPerson.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastlyAddedPerson.Location = new System.Drawing.Point(58, 372);
            this.lblLastlyAddedPerson.Name = "lblLastlyAddedPerson";
            this.lblLastlyAddedPerson.Size = new System.Drawing.Size(122, 17);
            this.lblLastlyAddedPerson.TabIndex = 23;
            this.lblLastlyAddedPerson.Text = "Lastly Edit Person";
            // 
            // frmAddDiscount
            // 
            this.ClientSize = new System.Drawing.Size(563, 479);
            this.Controls.Add(this.lblLastlyAddedPerson);
            this.Controls.Add(this.txtLastlyModifiedperson);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.isValidRadioButton);
            this.Controls.Add(this.endDateTimePicker);
            this.Controls.Add(this.startDateTimePicker);
            this.Controls.Add(this.cmbPaymentMethode);
            this.Controls.Add(this.txtProductName);
            this.Controls.Add(this.txtDiscountNumber);
            this.Controls.Add(this.txtProductId);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmAddDiscount";
            this.Text = "Add Discount";
            this.Load += new System.EventHandler(this.frmAddDiscount_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion




        #region using methode
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

     



        private int GenerateItemId()
        {
            // Your logic to generate a unique item ID
            return new Random().Next(10000, 99999);
        }


        private void ClearInputFields()
        {
            txtProductId.Clear();
            txtProductName.Clear();
            txtDiscountNumber.Clear();
            startDateTimePicker.Value = DateTime.Now; // Set to current date and time
            endDateTimePicker.Value = DateTime.Now; // Set to current date and time
            isValidRadioButton.Checked = false; // Set to initial state
            cmbPaymentMethode.SelectedIndex = -1; // Clear the selected item in the combo box
        }

        #endregion

        #region using items
        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                // Parse input values
                int productId = int.Parse(txtProductId.Text);
                string productName = txtProductName.Text;
                decimal discountNumber = decimal.Parse(txtDiscountNumber.Text);
                DateTime startDate = startDateTimePicker.Value;
                DateTime endDate = endDateTimePicker.Value;
                bool isValid = isValidRadioButton.Checked;

                string bankName = "ALL"; // Default value

                // Validate product ID
                if (productId <= 0)
                {
                    MessageBox.Show("Please enter a valid product ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Validate product name
                if (string.IsNullOrEmpty(productName))
                {
                    MessageBox.Show("Please enter a valid product name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Validate discount number
                if (discountNumber <= 0)
                {
                    MessageBox.Show("Please enter a valid discount number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

               
                // Validate that a payment method is selected
                if (cmbPaymentMethode.SelectedItem != null)
                {
                    bankName = cmbPaymentMethode.SelectedItem.ToString();
                }

                // Create a model to hold the data
                var discountData = new
                {
                    DiscountId = GenerateItemId(),
                    ProductId = productId,
                    ProductName = productName,
                    DiscountNumber = discountNumber,
                    StartDate = startDate,
                    EndDate = endDate,
                    PaymentMethod = bankName,
                    IsValid = isValid,
                    LastModifiedBy = txtLastlyModifiedperson.Text,
                    LastModifiedDate = DateTime.Now.ToString("yyyy-MM-dd")
                };

                // Serialize the discount data to JSON
                var json = JsonConvert.SerializeObject(discountData);

                // Create the HttpClient
                using (var client = new HttpClient())
                {
                    // Create the HTTP content with JSON
                    var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                    // Post the JSON data to the specified endpoint
                    HttpResponseMessage response = await client.PostAsync("https://localhost:7141/discounts", content);

                    // Check if the response is successful
                    if (response.IsSuccessStatusCode)
                    {
                        // Clear the input fields
                        ClearInputFields();

                        // Show a success message
                        MessageBox.Show("Data added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        // Show an error message
                        MessageBox.Show("Error adding data. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter valid numeric values for product ID and discount number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void button2_Click(object sender, EventArgs e)
        {
            frmMainPage mianPage = new frmMainPage(loggingTo, "admin");
            mianPage.Show();
            this.Hide();
        }


        private async void cmbPaymentMethode_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string selectedBankName = cmbPaymentMethode.SelectedItem?.ToString();



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


        private void lbProductId_Click(object sender, EventArgs e)
        {

        }

        private void lbProductName_Click(object sender, EventArgs e)
        {

        }

        private void lbPaymentMethod_Click(object sender, EventArgs e)
        {

        }

        private void lbDiscountNumber_Click(object sender, EventArgs e)
        {

        }

        private void lbStartDate_Click(object sender, EventArgs e)
        {

        }

        private void lbEnd_Click(object sender, EventArgs e)
        {

        }

        private void lbIsValid_Click(object sender, EventArgs e)
        {

        }

        private void lbHeadding_Click(object sender, EventArgs e)
        {

        }

        private void frmAddDiscount_Load(object sender, EventArgs e)
        {

        }


        private void txtproductId_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtProductName_TextChanged(object sender, EventArgs e)
        {

        }

        private void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dtpEndDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void rbIsValid_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, System.EventArgs e)
        {

        }
        private void txtLastlyModifiedperson_TextChanged(object sender, EventArgs e)
        {

        }

        #endregion


    }
}