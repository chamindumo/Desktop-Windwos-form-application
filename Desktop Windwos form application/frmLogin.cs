#region Using Directives

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Windows.Forms;

#endregion
namespace Desktop_Windwos_form_application
{
    public partial class frmLogin : Form
    {
        #region Using Variable
        public string TextBox1Value { get; set; }
        public string TextBox2Value { get; set; }
        private bool loginInProgress = false;
        private HttpClient _httpClient;
        #endregion

        #region Using Constructor
        public frmLogin()
        {
            InitializeComponent();
            _httpClient = new HttpClient();
            txtPassword.PasswordChar = '●';

        }
        #endregion

        #region Using Items
        private async void btnLogin_Click(object sender, EventArgs e)
        {
            loginInProgress = true;


            string username = TextBox1Value;
            string password = TextBox2Value;

            Dictionary<string, string> credentials = new Dictionary<string, string>
            {
                { "username", username },
                { "password", password }
            };

            // Convert credentials to JSON
            string json = JsonConvert.SerializeObject(credentials);
            // Assuming the URL structure is as follows, replace it with your actual endpoint
            HttpContent content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync($"https://localhost:7141/Users/{username}/{password}", content);

            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                Dictionary<string, string> userData = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonResponse);
                int logging = 1;
                string userType;
                if (userData.TryGetValue("type", out userType))
                {
                    if (userType == "user")
                    {

                        // Navigate to UserPage
                        frmUserPageForm userPage = new frmUserPageForm(username);
                        userPage.Show();
                        this.Hide();
                    }
                    else if (userType == "admin")
                    {

                        frmMainPage mianPage = new frmMainPage(logging);
                        mianPage.Show();
                        this.Hide();
                    }
                }
            }
            else
            {
                loginInProgress = false;

                // Handle unsuccessful response (invalid credentials or server error)
                MessageBox.Show("Invalid Username or password input.\nPlease enter the correct one", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            TextBox1Value = txtUsername.Text;

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            TextBox2Value = txtPassword.Text;

        }

        private void LogingForm1_Load(object sender, EventArgs e)
        {

        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (loginInProgress = true)
            {
                // Perform actions related to the status strip item click during the login process
                MessageBox.Show("Status strip item clicked during login.");
            }
        } 
        #endregion
    }
}
