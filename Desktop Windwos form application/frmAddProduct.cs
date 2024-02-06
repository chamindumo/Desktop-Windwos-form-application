#region Using Directives
using System;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; 
#endregion

namespace Desktop_Windwos_form_application
{
    public class frmAddProduct: Form
    {
        #region Using variables
        private HttpClient _httpClient;
        public string imageNameData;
        private Label lbProductId;
        private Label lbAddImage;
        private Label lbEnterDate;
        private Label lbIsAvalable;
        private Label lbDescription;
        private Label lbProductName;
        private Button btnImage;
        private Button btnAddProduct;
        private Button btnRest;
        private Button btnCancel;
        private TextBox txtProductId;
        private TextBox txtDescription;
        private TextBox txtProductName;
        private PictureBox ImagePreviewPictureBox;
        private DateTimePicker EnterDateDateTimePicker;
        private RadioButton isAvalableRadioButton;
        private OpenFileDialog openFileDialog1;
        private Button button5;
        private Label lbHeadding;
        public int loggingTo = 0;
        #endregion
        #region Using Constructor
        public frmAddProduct(int logging)
        {
            InitializeComponent();
            loggingTo = logging;
            _httpClient = new HttpClient();
        }
        #endregion

        #region Using Initalize
        private void InitializeComponent()
        {
            this.lbHeadding = new System.Windows.Forms.Label();
            this.lbProductId = new System.Windows.Forms.Label();
            this.lbAddImage = new System.Windows.Forms.Label();
            this.lbEnterDate = new System.Windows.Forms.Label();
            this.lbIsAvalable = new System.Windows.Forms.Label();
            this.lbDescription = new System.Windows.Forms.Label();
            this.lbProductName = new System.Windows.Forms.Label();
            this.btnImage = new System.Windows.Forms.Button();
            this.btnAddProduct = new System.Windows.Forms.Button();
            this.btnRest = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtProductId = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.ImagePreviewPictureBox = new System.Windows.Forms.PictureBox();
            this.EnterDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.isAvalableRadioButton = new System.Windows.Forms.RadioButton();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button5 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ImagePreviewPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // lbHeadding
            // 
            this.lbHeadding.AutoSize = true;
            this.lbHeadding.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHeadding.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lbHeadding.Location = new System.Drawing.Point(191, 13);
            this.lbHeadding.Name = "lbHeadding";
            this.lbHeadding.Size = new System.Drawing.Size(120, 25);
            this.lbHeadding.TabIndex = 0;
            this.lbHeadding.Text = "Add Product";
            this.lbHeadding.Click += new System.EventHandler(this.lbHeadding_Click);
            // 
            // lbProductId
            // 
            this.lbProductId.AutoSize = true;
            this.lbProductId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbProductId.Location = new System.Drawing.Point(38, 99);
            this.lbProductId.Name = "lbProductId";
            this.lbProductId.Size = new System.Drawing.Size(72, 17);
            this.lbProductId.TabIndex = 1;
            this.lbProductId.Text = "Product Id";
            this.lbProductId.Click += new System.EventHandler(this.lbProductId_Click);
            // 
            // lbAddImage
            // 
            this.lbAddImage.AutoSize = true;
            this.lbAddImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAddImage.Location = new System.Drawing.Point(38, 261);
            this.lbAddImage.Name = "lbAddImage";
            this.lbAddImage.Size = new System.Drawing.Size(75, 17);
            this.lbAddImage.TabIndex = 6;
            this.lbAddImage.Text = "Add Image";
            this.lbAddImage.Click += new System.EventHandler(this.lbAddImage_Click);
            // 
            // lbEnterDate
            // 
            this.lbEnterDate.AutoSize = true;
            this.lbEnterDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEnterDate.Location = new System.Drawing.Point(38, 225);
            this.lbEnterDate.Name = "lbEnterDate";
            this.lbEnterDate.Size = new System.Drawing.Size(76, 17);
            this.lbEnterDate.TabIndex = 7;
            this.lbEnterDate.Text = "Enter Date";
            this.lbEnterDate.Click += new System.EventHandler(this.lbEnterdate_Click);
            // 
            // lbIsAvalable
            // 
            this.lbIsAvalable.AutoSize = true;
            this.lbIsAvalable.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbIsAvalable.Location = new System.Drawing.Point(38, 193);
            this.lbIsAvalable.Name = "lbIsAvalable";
            this.lbIsAvalable.Size = new System.Drawing.Size(79, 17);
            this.lbIsAvalable.TabIndex = 8;
            this.lbIsAvalable.Text = "Is Available";
            this.lbIsAvalable.Click += new System.EventHandler(this.lbIsAvalable_Click);
            // 
            // lbDescription
            // 
            this.lbDescription.AutoSize = true;
            this.lbDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDescription.Location = new System.Drawing.Point(38, 165);
            this.lbDescription.Name = "lbDescription";
            this.lbDescription.Size = new System.Drawing.Size(79, 17);
            this.lbDescription.TabIndex = 9;
            this.lbDescription.Text = "Description";
            this.lbDescription.Click += new System.EventHandler(this.lbDescription_Click);
            // 
            // lbProductName
            // 
            this.lbProductName.AutoSize = true;
            this.lbProductName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbProductName.Location = new System.Drawing.Point(38, 133);
            this.lbProductName.Name = "lbProductName";
            this.lbProductName.Size = new System.Drawing.Size(98, 17);
            this.lbProductName.TabIndex = 11;
            this.lbProductName.Text = "Product Name";
            this.lbProductName.Click += new System.EventHandler(this.lbProductName_Click);
            // 
            // btnImage
            // 
            this.btnImage.Location = new System.Drawing.Point(169, 255);
            this.btnImage.Name = "btnImage";
            this.btnImage.Size = new System.Drawing.Size(85, 40);
            this.btnImage.TabIndex = 12;
            this.btnImage.Text = "Add Image";
            this.btnImage.UseVisualStyleBackColor = true;
            this.btnImage.Click += new System.EventHandler(this.btnAddImage);
            // 
            // btnAddProduct
            // 
            this.btnAddProduct.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.btnAddProduct.Location = new System.Drawing.Point(90, 546);
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.Size = new System.Drawing.Size(111, 35);
            this.btnAddProduct.TabIndex = 13;
            this.btnAddProduct.Text = "Add Product";
            this.btnAddProduct.UseVisualStyleBackColor = false;
            this.btnAddProduct.Click += new System.EventHandler(this.btnAddProduct_Click);
            // 
            // btnRest
            // 
            this.btnRest.Location = new System.Drawing.Point(219, 546);
            this.btnRest.Name = "btnRest";
            this.btnRest.Size = new System.Drawing.Size(111, 35);
            this.btnRest.TabIndex = 14;
            this.btnRest.Text = "Reset";
            this.btnRest.UseVisualStyleBackColor = true;
            this.btnRest.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(350, 546);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(111, 35);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtProductId
            // 
            this.txtProductId.Location = new System.Drawing.Point(169, 99);
            this.txtProductId.Name = "txtProductId";
            this.txtProductId.Size = new System.Drawing.Size(224, 20);
            this.txtProductId.TabIndex = 16;
            this.txtProductId.TextChanged += new System.EventHandler(this.txtProductId_TextChanged);
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(169, 165);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(395, 20);
            this.txtDescription.TabIndex = 20;
            this.txtDescription.TextChanged += new System.EventHandler(this.txtDescription_TextChanged);
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(169, 130);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(224, 20);
            this.txtProductName.TabIndex = 22;
            this.txtProductName.TextChanged += new System.EventHandler(this.txtProductName_TextChanged);
            // 
            // ImagePreviewPictureBox
            // 
            this.ImagePreviewPictureBox.Location = new System.Drawing.Point(153, 301);
            this.ImagePreviewPictureBox.Name = "ImagePreviewPictureBox";
            this.ImagePreviewPictureBox.Size = new System.Drawing.Size(269, 191);
            this.ImagePreviewPictureBox.TabIndex = 23;
            this.ImagePreviewPictureBox.TabStop = false;
            this.ImagePreviewPictureBox.Click += new System.EventHandler(this.ImagePreviewPictureBox_Click);
            // 
            // EnterDateDateTimePicker
            // 
            this.EnterDateDateTimePicker.Location = new System.Drawing.Point(169, 225);
            this.EnterDateDateTimePicker.Name = "EnterDateDateTimePicker";
            this.EnterDateDateTimePicker.Size = new System.Drawing.Size(224, 20);
            this.EnterDateDateTimePicker.TabIndex = 24;
            this.EnterDateDateTimePicker.ValueChanged += new System.EventHandler(this.EnterDateTimePicker_ValueChanged);
            // 
            // isAvalableRadioButton
            // 
            this.isAvalableRadioButton.AutoSize = true;
            this.isAvalableRadioButton.Location = new System.Drawing.Point(169, 193);
            this.isAvalableRadioButton.Name = "isAvalableRadioButton";
            this.isAvalableRadioButton.Size = new System.Drawing.Size(14, 13);
            this.isAvalableRadioButton.TabIndex = 25;
            this.isAvalableRadioButton.TabStop = true;
            this.isAvalableRadioButton.UseVisualStyleBackColor = true;
            this.isAvalableRadioButton.CheckedChanged += new System.EventHandler(this.IsAvalableRadioButton_CheckedChanged);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(41, 12);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(48, 32);
            this.button5.TabIndex = 27;
            this.button5.Text = "<-\r\n";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // frmAddProduct
            // 
            this.ClientSize = new System.Drawing.Size(604, 629);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.isAvalableRadioButton);
            this.Controls.Add(this.EnterDateDateTimePicker);
            this.Controls.Add(this.ImagePreviewPictureBox);
            this.Controls.Add(this.txtProductName);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtProductId);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnRest);
            this.Controls.Add(this.btnAddProduct);
            this.Controls.Add(this.btnImage);
            this.Controls.Add(this.lbProductName);
            this.Controls.Add(this.lbDescription);
            this.Controls.Add(this.lbIsAvalable);
            this.Controls.Add(this.lbEnterDate);
            this.Controls.Add(this.lbAddImage);
            this.Controls.Add(this.lbProductId);
            this.Controls.Add(this.lbHeadding);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmAddProduct";
            this.Text = "Add Product";
            this.Load += new System.EventHandler(this.AddProduct_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ImagePreviewPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion



        #region Using Method
       


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
                    ImagePreviewPictureBox.Image = resizedImage;
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





        #endregion


        #region Using Items
        private void btnReset_Click(object sender, EventArgs e)
        {
            txtProductId.Clear();
            txtProductName.Clear();
            txtDescription.Clear();
            isAvalableRadioButton.Checked = false; // Set to initial state
            EnterDateDateTimePicker.Value = DateTime.Now;

        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            frmMainPage mianPage = new frmMainPage(loggingTo);
            mianPage.Show();
            this.Hide();
        }

        private async void btnAddProduct_Click(object sender, System.EventArgs e)
        {

            if (!int.TryParse(txtProductId.Text, out int Id) || Id <= 0)
            {
                MessageBox.Show("Please enter a valid positive integer for Product ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validate Product Name
            if (string.IsNullOrEmpty(txtProductName.Text))
            {
                MessageBox.Show("Please enter a valid product name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validate Description
            if (txtDescription.Text.Length < 15)
            {
                MessageBox.Show("Please enter a description with a minimum length of 15 characters.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            // Validate Is Available

          

            // Validate Image Data
            if (imageNameData == null)
            {
                MessageBox.Show("Please add an image.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (int.TryParse(txtProductId.Text, out int productId) )
            {
                var requestData = new
                {
                    id = productId,
                    names = txtProductName.Text,
                    descriptions = txtDescription.Text,
                    isAvalable = isAvalableRadioButton.Checked, // Get the boolean value
                    expirDate = EnterDateDateTimePicker.Value,
                    imageData = imageNameData

                };
                var json = Newtonsoft.Json.JsonConvert.SerializeObject(requestData);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                // Make POST request to the API endpoint
                HttpResponseMessage response = await _httpClient.PostAsync("https://localhost:7141/Add/product", content);

                if (response.IsSuccessStatusCode)
                {
                    // Reset the fields after successful data addition
                    txtProductId.Clear();
                    txtProductName.Clear();
                    txtDescription.Clear();
                    isAvalableRadioButton.Checked = false; // Set to initial state
                    EnterDateDateTimePicker.Value = DateTime.Now; // Set to current date and time

                    // Optionally, provide feedback to the user or navigate back to the previous page
                    MessageBox.Show("Data added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Navigation.PopAsync();
                }
                else
                {
                    MessageBox.Show("Error adding data. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


                // Optionally, navigate back to the previous page or perform other navigation actions
                // Navigation.PopAsync();
            }
            else
            {
                MessageBox.Show($"Erro", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }



        private void button5_Click(object sender, System.EventArgs e)
        {

            frmMainPage mianPage = new frmMainPage(loggingTo);
            mianPage.Show();
            this.Hide();
        }



        private async void btnAddImage(object sender, System.EventArgs e)
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


        private void lbEnterdate_Click(object sender, EventArgs e)
        {

        }

        private void lbProductId_Click(object sender, EventArgs e)
        {

        }

        private void lbHeadding_Click(object sender, EventArgs e)
        {

        }

        private void ImagePreviewPictureBox_Click(object sender, EventArgs e)
        {

        }

        private void lbPrice_Click(object sender, EventArgs e)
        {

        }

        private void lbDescription_Click(object sender, EventArgs e)
        {

        }

        private void lbAddImage_Click(object sender, EventArgs e)
        {

        }


        private void lbProductName_Click(object sender, System.EventArgs e)
        {

        }

        private void lbIsAvalable_Click(object sender, System.EventArgs e)
        {

        }

        private void label6_Click(object sender, System.EventArgs e)
        {

        }

        private void AddProduct_Load(object sender, System.EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, System.EventArgs e)
        {

        }

        private void txtProductId_TextChanged(object sender, System.EventArgs e)
        {

        }

        private void txtProductName_TextChanged(object sender, System.EventArgs e)
        {

        }

        private void txtPrice_TextChanged(object sender, System.EventArgs e)
        {

        }

        private void txtDescription_TextChanged(object sender, System.EventArgs e)
        {

        }

        private void IsAvalableRadioButton_CheckedChanged(object sender, System.EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, System.EventArgs e)
        {

        }

        private void EnterDateTimePicker_ValueChanged(object sender, System.EventArgs e)
        {

        } 
        #endregion
    }
}