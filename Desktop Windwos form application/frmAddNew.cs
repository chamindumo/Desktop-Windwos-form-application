#region using Derective
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System;
using System.Windows.Forms;
using System.Text; 
#endregion

namespace Desktop_Windwos_form_application
{
    public class frmAddNew: Form
    {
        #region Using Variables
        public static int id = 12;
        private HttpClient _httpClient;
        public string imageNameData;
        private Label lbEmail;
        private Label lbMobileNumber;
        private Label lbRegion;
        private Label lbCity;
        private Label lbAddress;
        private Label lbLastName;
        private Label lbFirstName;
        private Label lbPassword;
        private Label lbUserName;
        private Label lbType;
        private Label lbAddImage;
        private Label lbIsVerified;
        private Button button1;
        private TextBox textBox1;
        private TextBox textBox9;
        private TextBox textBox10;
        private TextBox textBox11;
        private TextBox textBox12;
        private TextBox textBox13;
        private TextBox textBox14;
        private TextBox textBox15;
        private TextBox textBox16;
        private RadioButton radioButton1;
        private Button button2;
        private ComboBox comboBox1;
        private PictureBox pictureBox1;
        private Label lbHeadding;
        public int loggingTo;
        #endregion
        #region using constructor
        public frmAddNew(int logging)
        {
            _httpClient = new HttpClient();
            loggingTo = logging;
            InitializeComponent();
        }
        #endregion

        #region using initialize
        private void InitializeComponent()
        {
            this.lbEmail = new System.Windows.Forms.Label();
            this.lbMobileNumber = new System.Windows.Forms.Label();
            this.lbRegion = new System.Windows.Forms.Label();
            this.lbCity = new System.Windows.Forms.Label();
            this.lbAddress = new System.Windows.Forms.Label();
            this.lbLastName = new System.Windows.Forms.Label();
            this.lbFirstName = new System.Windows.Forms.Label();
            this.lbPassword = new System.Windows.Forms.Label();
            this.lbUserName = new System.Windows.Forms.Label();
            this.lbType = new System.Windows.Forms.Label();
            this.lbAddImage = new System.Windows.Forms.Label();
            this.lbIsVerified = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.textBox13 = new System.Windows.Forms.TextBox();
            this.textBox14 = new System.Windows.Forms.TextBox();
            this.textBox15 = new System.Windows.Forms.TextBox();
            this.textBox16 = new System.Windows.Forms.TextBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.button2 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbHeadding = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbEmail
            // 
            this.lbEmail.AutoSize = true;
            this.lbEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEmail.Location = new System.Drawing.Point(65, 95);
            this.lbEmail.Margin = new System.Windows.Forms.Padding(20);
            this.lbEmail.Name = "lbEmail";
            this.lbEmail.Size = new System.Drawing.Size(42, 17);
            this.lbEmail.TabIndex = 0;
            this.lbEmail.Text = "Email";
            this.lbEmail.Click += new System.EventHandler(this.lbEmail_Click);
            // 
            // lbMobileNumber
            // 
            this.lbMobileNumber.AutoSize = true;
            this.lbMobileNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMobileNumber.Location = new System.Drawing.Point(65, 304);
            this.lbMobileNumber.Margin = new System.Windows.Forms.Padding(20);
            this.lbMobileNumber.Name = "lbMobileNumber";
            this.lbMobileNumber.Size = new System.Drawing.Size(103, 17);
            this.lbMobileNumber.TabIndex = 1;
            this.lbMobileNumber.Text = "Mobile Number";
            this.lbMobileNumber.Click += new System.EventHandler(this.lbMobileNumber_Click);
            // 
            // lbRegion
            // 
            this.lbRegion.AutoSize = true;
            this.lbRegion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRegion.Location = new System.Drawing.Point(65, 281);
            this.lbRegion.Margin = new System.Windows.Forms.Padding(20);
            this.lbRegion.Name = "lbRegion";
            this.lbRegion.Size = new System.Drawing.Size(53, 17);
            this.lbRegion.TabIndex = 2;
            this.lbRegion.Text = "Region";
            this.lbRegion.Click += new System.EventHandler(this.lbRegion_Click);
            // 
            // lbCity
            // 
            this.lbCity.AutoSize = true;
            this.lbCity.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCity.Location = new System.Drawing.Point(65, 254);
            this.lbCity.Margin = new System.Windows.Forms.Padding(20);
            this.lbCity.Name = "lbCity";
            this.lbCity.Size = new System.Drawing.Size(31, 17);
            this.lbCity.TabIndex = 3;
            this.lbCity.Text = "City";
            this.lbCity.Click += new System.EventHandler(this.lbCity_Click);
            // 
            // lbAddress
            // 
            this.lbAddress.AutoSize = true;
            this.lbAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAddress.Location = new System.Drawing.Point(65, 228);
            this.lbAddress.Margin = new System.Windows.Forms.Padding(20);
            this.lbAddress.Name = "lbAddress";
            this.lbAddress.Size = new System.Drawing.Size(60, 17);
            this.lbAddress.TabIndex = 4;
            this.lbAddress.Text = "Address";
            this.lbAddress.Click += new System.EventHandler(this.lbAddress_Click);
            // 
            // lbLastName
            // 
            this.lbLastName.AutoSize = true;
            this.lbLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLastName.Location = new System.Drawing.Point(65, 194);
            this.lbLastName.Margin = new System.Windows.Forms.Padding(20);
            this.lbLastName.Name = "lbLastName";
            this.lbLastName.Size = new System.Drawing.Size(76, 17);
            this.lbLastName.TabIndex = 5;
            this.lbLastName.Text = "Last Name";
            this.lbLastName.Click += new System.EventHandler(this.lbLastName_Click);
            // 
            // lbFirstName
            // 
            this.lbFirstName.AutoSize = true;
            this.lbFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFirstName.Location = new System.Drawing.Point(65, 168);
            this.lbFirstName.Margin = new System.Windows.Forms.Padding(20);
            this.lbFirstName.Name = "lbFirstName";
            this.lbFirstName.Size = new System.Drawing.Size(76, 17);
            this.lbFirstName.TabIndex = 6;
            this.lbFirstName.Text = "First Name";
            this.lbFirstName.Click += new System.EventHandler(this.lbFirstName_Click);
            // 
            // lbPassword
            // 
            this.lbPassword.AutoSize = true;
            this.lbPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPassword.Location = new System.Drawing.Point(65, 143);
            this.lbPassword.Margin = new System.Windows.Forms.Padding(20);
            this.lbPassword.Name = "lbPassword";
            this.lbPassword.Size = new System.Drawing.Size(69, 17);
            this.lbPassword.TabIndex = 7;
            this.lbPassword.Text = "Password";
            this.lbPassword.Click += new System.EventHandler(this.lbPassword_Click);
            // 
            // lbUserName
            // 
            this.lbUserName.AutoSize = true;
            this.lbUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUserName.Location = new System.Drawing.Point(65, 117);
            this.lbUserName.Margin = new System.Windows.Forms.Padding(20);
            this.lbUserName.Name = "lbUserName";
            this.lbUserName.Size = new System.Drawing.Size(73, 17);
            this.lbUserName.TabIndex = 8;
            this.lbUserName.Text = "Username";
            this.lbUserName.Click += new System.EventHandler(this.lbUserName_Click);
            // 
            // lbType
            // 
            this.lbType.AutoSize = true;
            this.lbType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbType.Location = new System.Drawing.Point(65, 573);
            this.lbType.Margin = new System.Windows.Forms.Padding(20);
            this.lbType.Name = "lbType";
            this.lbType.Size = new System.Drawing.Size(40, 17);
            this.lbType.TabIndex = 10;
            this.lbType.Text = "Type";
            this.lbType.Click += new System.EventHandler(this.lbType_Click);
            // 
            // lbAddImage
            // 
            this.lbAddImage.AutoSize = true;
            this.lbAddImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAddImage.Location = new System.Drawing.Point(65, 357);
            this.lbAddImage.Margin = new System.Windows.Forms.Padding(20);
            this.lbAddImage.Name = "lbAddImage";
            this.lbAddImage.Size = new System.Drawing.Size(75, 17);
            this.lbAddImage.TabIndex = 11;
            this.lbAddImage.Text = "Add Image";
            this.lbAddImage.Click += new System.EventHandler(this.lbAddImage_Click);
            // 
            // lbIsVerified
            // 
            this.lbIsVerified.AutoSize = true;
            this.lbIsVerified.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbIsVerified.Location = new System.Drawing.Point(65, 331);
            this.lbIsVerified.Margin = new System.Windows.Forms.Padding(20);
            this.lbIsVerified.Name = "lbIsVerified";
            this.lbIsVerified.Size = new System.Drawing.Size(70, 17);
            this.lbIsVerified.TabIndex = 12;
            this.lbIsVerified.Text = "Is Verified";
            this.lbIsVerified.Click += new System.EventHandler(this.lbIsVerified_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(397, 605);
            this.button1.Margin = new System.Windows.Forms.Padding(20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 37);
            this.button1.TabIndex = 13;
            this.button1.Text = "Submit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(184, 92);
            this.textBox1.Margin = new System.Windows.Forms.Padding(20);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(252, 23);
            this.textBox1.TabIndex = 14;
            this.textBox1.TextChanged += new System.EventHandler(this.txtEmail_TextChanged);
            // 
            // textBox9
            // 
            this.textBox9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox9.Location = new System.Drawing.Point(184, 307);
            this.textBox9.Margin = new System.Windows.Forms.Padding(20);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(252, 23);
            this.textBox9.TabIndex = 22;
            this.textBox9.TextChanged += new System.EventHandler(this.txtMobileNumber_TextChanged);
            // 
            // textBox10
            // 
            this.textBox10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox10.Location = new System.Drawing.Point(184, 281);
            this.textBox10.Margin = new System.Windows.Forms.Padding(20);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(252, 23);
            this.textBox10.TabIndex = 23;
            this.textBox10.TextChanged += new System.EventHandler(this.txtRegion_TextChanged);
            // 
            // textBox11
            // 
            this.textBox11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox11.Location = new System.Drawing.Point(184, 254);
            this.textBox11.Margin = new System.Windows.Forms.Padding(20);
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(252, 23);
            this.textBox11.TabIndex = 24;
            this.textBox11.TextChanged += new System.EventHandler(this.txtCity_TextChanged);
            // 
            // textBox12
            // 
            this.textBox12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox12.Location = new System.Drawing.Point(184, 224);
            this.textBox12.Margin = new System.Windows.Forms.Padding(20);
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size(252, 23);
            this.textBox12.TabIndex = 25;
            this.textBox12.TextChanged += new System.EventHandler(this.txtAddress_TextChanged);
            // 
            // textBox13
            // 
            this.textBox13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox13.Location = new System.Drawing.Point(184, 191);
            this.textBox13.Margin = new System.Windows.Forms.Padding(20);
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new System.Drawing.Size(252, 23);
            this.textBox13.TabIndex = 26;
            this.textBox13.TextChanged += new System.EventHandler(this.txtLastName_TextChanged);
            // 
            // textBox14
            // 
            this.textBox14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox14.Location = new System.Drawing.Point(184, 165);
            this.textBox14.Margin = new System.Windows.Forms.Padding(20);
            this.textBox14.Name = "textBox14";
            this.textBox14.Size = new System.Drawing.Size(252, 23);
            this.textBox14.TabIndex = 27;
            this.textBox14.TextChanged += new System.EventHandler(this.txtFirstName_TextChanged);
            // 
            // textBox15
            // 
            this.textBox15.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox15.Location = new System.Drawing.Point(184, 140);
            this.textBox15.Margin = new System.Windows.Forms.Padding(20);
            this.textBox15.Name = "textBox15";
            this.textBox15.Size = new System.Drawing.Size(252, 23);
            this.textBox15.TabIndex = 28;
            this.textBox15.TextChanged += new System.EventHandler(this.txtPassword_TextChanged);
            // 
            // textBox16
            // 
            this.textBox16.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox16.Location = new System.Drawing.Point(184, 117);
            this.textBox16.Margin = new System.Windows.Forms.Padding(20);
            this.textBox16.Name = "textBox16";
            this.textBox16.Size = new System.Drawing.Size(252, 23);
            this.textBox16.TabIndex = 29;
            this.textBox16.TextChanged += new System.EventHandler(this.txtUsername_TextChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(184, 333);
            this.radioButton1.Margin = new System.Windows.Forms.Padding(20);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(14, 13);
            this.radioButton1.TabIndex = 30;
            this.radioButton1.TabStop = true;
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.IsVerifiedRadioButton1_CheckedChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(184, 352);
            this.button2.Margin = new System.Windows.Forms.Padding(20);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(82, 37);
            this.button2.TabIndex = 31;
            this.button2.Text = "Add Image";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btnAddImage_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "user",
            "admin"});
            this.comboBox1.Location = new System.Drawing.Point(184, 569);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(20);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 32;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.TypeComboBox_SelectedIndexChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(184, 398);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(20);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(252, 148);
            this.pictureBox1.TabIndex = 33;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.previewPictureBox_Click);
            // 
            // lbHeadding
            // 
            this.lbHeadding.AutoSize = true;
            this.lbHeadding.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHeadding.Location = new System.Drawing.Point(502, 27);
            this.lbHeadding.Margin = new System.Windows.Forms.Padding(20);
            this.lbHeadding.Name = "lbHeadding";
            this.lbHeadding.Size = new System.Drawing.Size(138, 25);
            this.lbHeadding.TabIndex = 34;
            this.lbHeadding.Text = "Add New User";
            this.lbHeadding.Click += new System.EventHandler(this.lbHeadding_Click);
            // 
            // frmAddNew
            // 
            this.ClientSize = new System.Drawing.Size(1193, 704);
            this.Controls.Add(this.lbHeadding);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.textBox16);
            this.Controls.Add(this.textBox15);
            this.Controls.Add(this.textBox14);
            this.Controls.Add(this.textBox13);
            this.Controls.Add(this.textBox12);
            this.Controls.Add(this.textBox11);
            this.Controls.Add(this.textBox10);
            this.Controls.Add(this.textBox9);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lbIsVerified);
            this.Controls.Add(this.lbAddImage);
            this.Controls.Add(this.lbType);
            this.Controls.Add(this.lbUserName);
            this.Controls.Add(this.lbPassword);
            this.Controls.Add(this.lbFirstName);
            this.Controls.Add(this.lbLastName);
            this.Controls.Add(this.lbAddress);
            this.Controls.Add(this.lbCity);
            this.Controls.Add(this.lbRegion);
            this.Controls.Add(this.lbMobileNumber);
            this.Controls.Add(this.lbEmail);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmAddNew";
            this.Text = "New Role";
            this.Load += new System.EventHandler(this.AddNew_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion


        #region Using Methode
        private async void btnAddImage_Click(object sender, System.EventArgs e)
        {
            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Title = "Select an Image";
                    openFileDialog.Filter = "Image Files (*.jpg; *.jpeg; *.png)|*.jpg; *.jpeg; *.png";

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string fileName = Path.GetFileName(openFileDialog.FileName);

                        // Pass the file stream and file name to the method handling image upload
                        using (Stream stream = File.OpenRead(openFileDialog.FileName))
                        {
                            await UploadImage(stream, fileName);

                            // Resize the image and assign it to the PictureBox

                        }
                    }
                    ResizeAndSetImage(openFileDialog.FileName);

                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur during file picking or upload
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void ResizeAndSetImage(string imagePath)
        {
            try
            {
                // Load the original image
                using (var originalImage = System.Drawing.Image.FromFile(imagePath))
                {
                    // Set the maximum width and height for the resized image
                    int maxWidth = 200; // Change this value to your desired maximum width
                    int maxHeight = 200; // Change this value to your desired maximum height

                    // Calculate the new size while maintaining the aspect ratio
                    int newWidth, newHeight;
                    if (originalImage.Width > originalImage.Height)
                    {
                        newWidth = maxWidth;
                        newHeight = (int)((double)originalImage.Height / originalImage.Width * maxWidth);
                    }
                    else
                    {
                        newWidth = (int)((double)originalImage.Width / originalImage.Height * maxHeight);
                        newHeight = maxHeight;
                    }

                    // Resize the image
                    var resizedImage = new Bitmap(originalImage, newWidth, newHeight);

                    // Assign the resized image to the PictureBox
                    pictureBox1.Image = resizedImage;
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur during image resizing
                MessageBox.Show($"Error resizing image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private async Task UploadImage(Stream stream, string fileName)
        {
            try
            {
                var content = new MultipartFormDataContent();
                content.Add(new StreamContent(stream), "postedFile", fileName);

                var response = await _httpClient.PostAsync("https://localhost:7141/SaveFile", content);
                response.EnsureSuccessStatusCode(); // Ensure the response is successful

                string imageName = await response.Content.ReadAsStringAsync();
                // 'imageName' now contains the name of the uploaded image

                imageNameData = imageName;

                // Proceed with using 'imageName' as needed in your application
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur during image upload
            }
        }


        private int GenerateItemId()
        {
            // Your logic to generate a unique item ID
            return new Random().Next(10000, 99999);
        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            id = GenerateItemId();

            UserDTO data = new UserDTO
            {
                Id = id,
                Email = textBox1.Text,
                Username = textBox16.Text,
                PasswordHash = textBox15.Text, // Note: Storing password hash needs to be handled securely
                FirstName = textBox14.Text,
                LastName = textBox13.Text,
                Address = textBox12.Text,
                City = textBox11.Text,
                Region = textBox10.Text,
                MobileNumber = textBox9.Text,
                IsVerified = radioButton1.Checked,
                ImageData = imageNameData,
                Type = comboBox1.SelectedItem as string
            };

            var json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            using (var client = new HttpClient())
            {
                var response = await client.PostAsync("https://localhost:7141/Register", content);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Data added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    id++;

                    frmMainPage mianPage = new frmMainPage(loggingTo);
                    mianPage.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Error adding data. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
        #endregion

        #region Using Items

        private void previewPictureBox_Click(object sender, EventArgs e)
        {

        }

        private void lbHeadding_Click(object sender, EventArgs e)
        {

        }

        private void lbEmail_Click(object sender, EventArgs e)
        {

        }

        private void lbUserName_Click(object sender, EventArgs e)
        {

        }

        private void lbPassword_Click(object sender, EventArgs e)
        {

        }

        private void lbFirstName_Click(object sender, EventArgs e)
        {

        }

        private void lbLastName_Click(object sender, EventArgs e)
        {

        }

        private void lbAddress_Click(object sender, EventArgs e)
        {

        }

        private void lbCity_Click(object sender, EventArgs e)
        {

        }

        private void lbRegion_Click(object sender, EventArgs e)
        {

        }

        private void lbMobileNumber_Click(object sender, EventArgs e)
        {

        }

        private void lbIsVerified_Click(object sender, EventArgs e)
        {

        }

        private void lbAddImage_Click(object sender, EventArgs e)
        {

        }

        private void lbType_Click(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtFirstName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtLastName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCity_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtRegion_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMobileNumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void TypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AddNew_Load(object sender, System.EventArgs e)
        {

        }

        private void IsVerifiedRadioButton1_CheckedChanged(object sender, System.EventArgs e)
        {

        } 
        #endregion
    }
}