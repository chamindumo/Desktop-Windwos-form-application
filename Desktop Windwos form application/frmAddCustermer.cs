#region Using Directives

using System.Net.Http;
using System;
using System.Windows.Forms;
using System.Text;
using System.Net.Mail;
using System.Net;
using FirebaseAdmin.Auth;
using FirebaseAdmin;
using Firebase.Auth.Providers;
using Microsoft.Web.WebView2.WinForms;
using System.Linq;

#endregion

namespace Desktop_Windwos_form_application
{




    public class frmAddCustermer: Form
    {

        #region using private variables
        private HttpClient _httpClient;
        private Label lbName;
        private Label lbLoyaltyCardNumber;
        private Label lbAddress;
        private Label lbPhoneNumber;
        private TextBox txtName;
        private TextBox txtLoyelticard;
        private TextBox txtAddress;
        private TextBox txtPhoneNumber;
        private TextBox txtEmail;
        private Label label2;
        private Button btnSubmit;
        private Label lbEmail;
        private FirebaseApp app;
        private FirebaseAuth auth;
        private FirebaseAuthProvider _authProvider;
        private string _verificationId;
        private const string TwilioAccountSid = "AC280aa864dda71af9658694efdbc13f99";
        private const string TwilioAuthToken = "7195e1f8ffa7e6fe54a7ae8111d265ba";
        private const string TwilioPhoneNumber = "your-twilio-phone-number";
        private WebView2 webView;
        #endregion

        #region using constructor
        public frmAddCustermer()
        {
            InitializeComponent();
            _httpClient = new HttpClient();


        }
        #endregion




        #region using initialize
        private void InitializeComponent()
        {
            this.webView = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.lbName = new System.Windows.Forms.Label();
            this.lbLoyaltyCardNumber = new System.Windows.Forms.Label();
            this.lbAddress = new System.Windows.Forms.Label();
            this.lbPhoneNumber = new System.Windows.Forms.Label();
            this.lbEmail = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtLoyelticard = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtPhoneNumber = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.webView)).BeginInit();
            this.SuspendLayout();
            // 
            // webView
            // 
            this.webView.AllowExternalDrop = true;
            this.webView.CreationProperties = null;
            this.webView.DefaultBackgroundColor = System.Drawing.Color.White;
            this.webView.Location = new System.Drawing.Point(0, 0);
            this.webView.Name = "webView";
            this.webView.Size = new System.Drawing.Size(0, 0);
            this.webView.TabIndex = 0;
            this.webView.ZoomFactor = 1D;
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbName.Location = new System.Drawing.Point(50, 102);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(45, 17);
            this.lbName.TabIndex = 0;
            this.lbName.Text = "Name";
            this.lbName.Click += new System.EventHandler(this.lbName_Click);
            // 
            // lbLoyaltyCardNumber
            // 
            this.lbLoyaltyCardNumber.AutoSize = true;
            this.lbLoyaltyCardNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLoyaltyCardNumber.Location = new System.Drawing.Point(50, 220);
            this.lbLoyaltyCardNumber.Name = "lbLoyaltyCardNumber";
            this.lbLoyaltyCardNumber.Size = new System.Drawing.Size(141, 17);
            this.lbLoyaltyCardNumber.TabIndex = 4;
            this.lbLoyaltyCardNumber.Text = "Loyalty Card Number";
            this.lbLoyaltyCardNumber.Click += new System.EventHandler(this.lbLoyeltyCardNumber_Click);
            // 
            // lbAddress
            // 
            this.lbAddress.AutoSize = true;
            this.lbAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAddress.Location = new System.Drawing.Point(50, 194);
            this.lbAddress.Name = "lbAddress";
            this.lbAddress.Size = new System.Drawing.Size(60, 17);
            this.lbAddress.TabIndex = 5;
            this.lbAddress.Text = "Address";
            this.lbAddress.Click += new System.EventHandler(this.lbAddress_Click);
            // 
            // lbPhoneNumber
            // 
            this.lbPhoneNumber.AutoSize = true;
            this.lbPhoneNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPhoneNumber.Location = new System.Drawing.Point(50, 161);
            this.lbPhoneNumber.Name = "lbPhoneNumber";
            this.lbPhoneNumber.Size = new System.Drawing.Size(103, 17);
            this.lbPhoneNumber.TabIndex = 10;
            this.lbPhoneNumber.Text = "Phone Number";
            this.lbPhoneNumber.Click += new System.EventHandler(this.lbPhoneNumber_Click);
            // 
            // lbEmail
            // 
            this.lbEmail.AutoSize = true;
            this.lbEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEmail.Location = new System.Drawing.Point(50, 128);
            this.lbEmail.Name = "lbEmail";
            this.lbEmail.Size = new System.Drawing.Size(42, 17);
            this.lbEmail.TabIndex = 11;
            this.lbEmail.Text = "Email";
            this.lbEmail.Click += new System.EventHandler(this.lbEmail_Click);
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(203, 93);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(269, 23);
            this.txtName.TabIndex = 12;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // txtLoyelticard
            // 
            this.txtLoyelticard.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLoyelticard.Location = new System.Drawing.Point(203, 217);
            this.txtLoyelticard.Name = "txtLoyelticard";
            this.txtLoyelticard.Size = new System.Drawing.Size(269, 23);
            this.txtLoyelticard.TabIndex = 13;
            this.txtLoyelticard.TextChanged += new System.EventHandler(this.txtLoyeltiCard_TextChanged);
            // 
            // txtAddress
            // 
            this.txtAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddress.Location = new System.Drawing.Point(203, 187);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(269, 23);
            this.txtAddress.TabIndex = 14;
            this.txtAddress.TextChanged += new System.EventHandler(this.txtAddress_TextChanged);
            // 
            // txtPhoneNumber
            // 
            this.txtPhoneNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhoneNumber.Location = new System.Drawing.Point(203, 154);
            this.txtPhoneNumber.Name = "txtPhoneNumber";
            this.txtPhoneNumber.Size = new System.Drawing.Size(269, 23);
            this.txtPhoneNumber.TabIndex = 15;
            this.txtPhoneNumber.TextChanged += new System.EventHandler(this.txtPhoneNumber_TextChanged);
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(203, 122);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(269, 23);
            this.txtEmail.TabIndex = 16;
            this.txtEmail.TextChanged += new System.EventHandler(this.txtEmail_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(256, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 25);
            this.label2.TabIndex = 17;
            this.label2.Text = "Add Custermer";
            this.label2.Click += new System.EventHandler(this.lbHeadding_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(252, 276);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(99, 38);
            this.btnSubmit.TabIndex = 18;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // frmAddCustermer
            // 
            this.ClientSize = new System.Drawing.Size(541, 353);
            this.Controls.Add(this.webView);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtPhoneNumber);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.txtLoyelticard);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lbEmail);
            this.Controls.Add(this.lbPhoneNumber);
            this.Controls.Add(this.lbAddress);
            this.Controls.Add(this.lbLoyaltyCardNumber);
            this.Controls.Add(this.lbName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmAddCustermer";
            this.Text = "Add Custermer";
            this.Load += new System.EventHandler(this.frmAddCustermer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.webView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        #region Using items
        private void txtName_TextChanged(object sender, System.EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, System.EventArgs e)
        {

        }

        private void txtPhoneNumber_TextChanged(object sender, System.EventArgs e)
        {

        }

        private void txtAddress_TextChanged(object sender, System.EventArgs e)
        {

        }

        private void txtLoyeltiCard_TextChanged(object sender, System.EventArgs e)
        {

        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void webBrowser1_DocumentCompleted_1(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private async void button2_Click(object sender, EventArgs e)
        {


            // Load the HTML content into WebView2

        }

        private void webView21_Click(object sender, EventArgs e)
        {
        }

        private void lbHeadding_Click(object sender, EventArgs e)
        {

        }

        private void lbName_Click(object sender, EventArgs e)
        {

        }

        private void lbEmail_Click(object sender, EventArgs e)
        {

        }

        private void lbPhoneNumber_Click(object sender, EventArgs e)
        {

        }

        private void lbAddress_Click(object sender, EventArgs e)
        {

        }

        private void lbLoyeltyCardNumber_Click(object sender, EventArgs e)
        {

        }

        private void frmAddCustermer_Load(object sender, EventArgs e)
        {

        }



        private async void btnSubmit_Click(object sender, System.EventArgs e)
        {
            var name = txtName.Text;
            var email = txtEmail.Text;
            var phoneNumber = txtPhoneNumber.Text;
            var address = txtAddress.Text;
            var loyaltyCardNumber = txtLoyelticard.Text;
            int starPoints = 0;


            if (ValidateCustomerInfo(name, email, phoneNumber, address, loyaltyCardNumber))
            {
                Random random = new Random();
                int verificationCode = random.Next(100000, 999999);




                if (SendVerificationEmail(email, verificationCode))
                {

                    // Send the verification code to the user via email
                    string enteredCode = PromptForVerificationCode();

                    // Check if the entered code is correct
                    if (!string.IsNullOrEmpty(enteredCode) && enteredCode.Equals(verificationCode.ToString()))
                    {
                        // User entered the correct verification code
                        MessageBox.Show("Verification successful! Data added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Incorrect verification code. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Error sending verification email. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                // Use the captured values (name, email, phoneNumber, address, loyaltyCardNumber, starPoints) as needed
                // For example, you might create an object of your class and assign these values to its properties
                CustermerDTO obj = new CustermerDTO
                {
                    Name = name,
                    Email = email,
                    PhoneNumber = phoneNumber,
                    Address = address,
                    LoyaltyCardNumber = loyaltyCardNumber,
                    StarPoints = starPoints
                };
                var json = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                // Set the content type

                using (var client = new HttpClient())
                {
                    var response = await client.PostAsync("https://localhost:7141/api/customers", content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Data added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();

                    }
                    else
                    {
                        MessageBox.Show("Error adding data. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
            else
            {
                MessageBox.Show("Error sending verification email. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        #endregion



        #region using methodes
        private bool SendVerificationEmail(string toEmail, int verificationCode)
        {
            try
            {
                string smtpServer = "smtp.gmail.com";
                int smtpPort = 587; // Update with your SMTP server port
                string smtpUsername = "chamindumoramudali99@gmail.com"; // Update with your SMTP server username
                string smtpPassword = "faxnmyhocirfjxqx"; // Update with your SMTP server password

                // Create an SMTP client
                SmtpClient smtpClient = new SmtpClient(smtpServer, smtpPort);
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(smtpUsername, smtpPassword);
                smtpClient.EnableSsl = true;

                // Create the email message
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress("chamindumoramudali99@gmail.com"); // Update with your email address
                mailMessage.To.Add(toEmail);
                mailMessage.Subject = "Verification Code";
                mailMessage.Body = $"Your verification code is: {verificationCode}";

                // Send the email
                smtpClient.Send(mailMessage);

                return true;
            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed
                return false;
            }
        }
        // Function to prompt the user for the verification code using a separate form
        private string PromptForVerificationCode()
        {
            using (frmInputDialogForm inputForm = new frmInputDialogForm())
            {
                DialogResult result = inputForm.ShowDialog();

                if (result == DialogResult.OK)
                {
                    return inputForm.VerificationCode;
                }
                else
                {
                    return string.Empty;
                }
            }
        }


        private bool ValidateCustomerInfo(string name, string email, string phoneNumber, string address, string loyaltyCardNumber)
        {
            // Validate Name
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Please enter a valid name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Check if the name contains any integers
            if (name.Any(char.IsDigit))
            {
                MessageBox.Show("Name cannot contain integers. Please enter a valid name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Validate Email
            if (string.IsNullOrEmpty(email) || !IsValidEmail(email))
            {
                MessageBox.Show("Please enter a valid email address.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Validate Phone Number (you can customize the phone number validation based on your requirements)
            if (string.IsNullOrEmpty(phoneNumber) || !IsValidPhoneNumber(phoneNumber))
            {
                MessageBox.Show("Please enter a valid phone number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Validate Address (you can customize the address validation based on your requirements)
            if (string.IsNullOrEmpty(address))
            {
                MessageBox.Show("Please enter a valid address.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Validate Loyalty Card Number (you can customize the loyalty card number validation based on your requirements)
            if (string.IsNullOrEmpty(loyaltyCardNumber))
            {
                MessageBox.Show("Please enter a valid loyalty card number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private bool IsValidEmail(string email)
        {
            // Add your email validation logic here
            // For a simple example, checking if the email contains '@' and '.'
            return email.Contains('@') && email.Contains('.');
        }

        private bool IsValidPhoneNumber(string phoneNumber)
        {
            // Add your phone number validation logic here
            // For a simple example, checking if the phone number contains only digits
            return phoneNumber.All(char.IsDigit);
        }




        #endregion


    }
}