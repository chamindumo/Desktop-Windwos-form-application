#region Using Directives


using Newtonsoft.Json;
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
    public class frmEditProductForm: Form
    {
        #region Using Variables
        private Label lbHeadding;
        private Label lbEditProductId;
        private Label lbEditProductImage;
        private Label lbEditProductIsAvalable;
        private Label lbEditProductName;
        private Label lbEditProductDescription;
        private TextBox txtProductId;
        private TextBox txtDescription;
        private TextBox txtProductName;
        private PictureBox previewPictureBox1;
        private Button btnAddImage;
        private DateTimePicker EnterDateTimePicker;
        private Button btnSubmit;
        private Label lbEditProductExpiryDate;
        private HttpClient _httpClient;
        public string imageNameData;
        private TextBox txtEditBy;
        private Label label1;
        private CheckBox ckBoxisValidChecked;
        public string userName;
        #endregion
        #region Using Constructor
        public frmEditProductForm(int productId, string name, string description, bool isAvailable, DateTime expiryDate, string imageData,string username)
        {
            InitializeComponent();
            _httpClient = new HttpClient();
            txtProductId.Text = productId.ToString();
            txtProductName.Text = name;
            txtDescription.Text = description;
            ckBoxisValidChecked.Checked = isAvailable;
            EnterDateTimePicker.Value = expiryDate;
            previewPictureBox1.Text = imageData;
            txtProductId.ReadOnly = true;
            userName = username;
            Bitmap iconAddImage = new Bitmap("C://Users/Chamindu/Downloads/icons8-image-48.png"); // Replace "icon.png" with the actual file path


            int newWidth = 23; // Set your desired width
            int newHeight = 23; // Set your desired height

            Bitmap resizedImage = new Bitmap(iconAddImage, new Size(newWidth, newHeight));


            // Set the icon for the button
            btnAddImage.Image = resizedImage;

        }

        #endregion
        #region Using Initalize
        private void InitializeComponent()
        {
            this.lbHeadding = new System.Windows.Forms.Label();
            this.lbEditProductId = new System.Windows.Forms.Label();
            this.lbEditProductImage = new System.Windows.Forms.Label();
            this.lbEditProductIsAvalable = new System.Windows.Forms.Label();
            this.lbEditProductName = new System.Windows.Forms.Label();
            this.lbEditProductDescription = new System.Windows.Forms.Label();
            this.lbEditProductExpiryDate = new System.Windows.Forms.Label();
            this.txtProductId = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.previewPictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnAddImage = new System.Windows.Forms.Button();
            this.EnterDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.txtEditBy = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ckBoxisValidChecked = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.previewPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbHeadding
            // 
            this.lbHeadding.AutoSize = true;
            this.lbHeadding.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHeadding.Location = new System.Drawing.Point(225, 9);
            this.lbHeadding.Name = "lbHeadding";
            this.lbHeadding.Size = new System.Drawing.Size(129, 25);
            this.lbHeadding.TabIndex = 0;
            this.lbHeadding.Text = "Edit Product";
            this.lbHeadding.Click += new System.EventHandler(this.lbHeadding_Click);
            // 
            // lbEditProductId
            // 
            this.lbEditProductId.AutoSize = true;
            this.lbEditProductId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEditProductId.Location = new System.Drawing.Point(65, 110);
            this.lbEditProductId.Name = "lbEditProductId";
            this.lbEditProductId.Size = new System.Drawing.Size(72, 17);
            this.lbEditProductId.TabIndex = 1;
            this.lbEditProductId.Text = "Product Id";
            this.lbEditProductId.Click += new System.EventHandler(this.lbProductId);
            // 
            // lbEditProductImage
            // 
            this.lbEditProductImage.AutoSize = true;
            this.lbEditProductImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEditProductImage.Location = new System.Drawing.Point(65, 275);
            this.lbEditProductImage.Name = "lbEditProductImage";
            this.lbEditProductImage.Size = new System.Drawing.Size(99, 17);
            this.lbEditProductImage.TabIndex = 2;
            this.lbEditProductImage.Text = "Product Image";
            this.lbEditProductImage.Click += new System.EventHandler(this.lbProductImage);
            // 
            // lbEditProductIsAvalable
            // 
            this.lbEditProductIsAvalable.AutoSize = true;
            this.lbEditProductIsAvalable.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEditProductIsAvalable.Location = new System.Drawing.Point(65, 204);
            this.lbEditProductIsAvalable.Name = "lbEditProductIsAvalable";
            this.lbEditProductIsAvalable.Size = new System.Drawing.Size(132, 17);
            this.lbEditProductIsAvalable.TabIndex = 3;
            this.lbEditProductIsAvalable.Text = "Product is Available";
            this.lbEditProductIsAvalable.Click += new System.EventHandler(this.lbProductIsAvalable);
            // 
            // lbEditProductName
            // 
            this.lbEditProductName.AutoSize = true;
            this.lbEditProductName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEditProductName.Location = new System.Drawing.Point(65, 143);
            this.lbEditProductName.Name = "lbEditProductName";
            this.lbEditProductName.Size = new System.Drawing.Size(98, 17);
            this.lbEditProductName.TabIndex = 4;
            this.lbEditProductName.Text = "Product Name";
            this.lbEditProductName.Click += new System.EventHandler(this.lbProductName);
            // 
            // lbEditProductDescription
            // 
            this.lbEditProductDescription.AutoSize = true;
            this.lbEditProductDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEditProductDescription.Location = new System.Drawing.Point(65, 174);
            this.lbEditProductDescription.Name = "lbEditProductDescription";
            this.lbEditProductDescription.Size = new System.Drawing.Size(130, 17);
            this.lbEditProductDescription.TabIndex = 5;
            this.lbEditProductDescription.Text = "Product description";
            this.lbEditProductDescription.Click += new System.EventHandler(this.lbProductDescription);
            // 
            // lbEditProductExpiryDate
            // 
            this.lbEditProductExpiryDate.AutoSize = true;
            this.lbEditProductExpiryDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEditProductExpiryDate.Location = new System.Drawing.Point(65, 236);
            this.lbEditProductExpiryDate.Name = "lbEditProductExpiryDate";
            this.lbEditProductExpiryDate.Size = new System.Drawing.Size(136, 17);
            this.lbEditProductExpiryDate.TabIndex = 8;
            this.lbEditProductExpiryDate.Text = "Product Added Date";
            this.lbEditProductExpiryDate.Click += new System.EventHandler(this.lbProductExpiryDate);
            // 
            // txtProductId
            // 
            this.txtProductId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductId.Location = new System.Drawing.Point(230, 106);
            this.txtProductId.Name = "txtProductId";
            this.txtProductId.Size = new System.Drawing.Size(252, 23);
            this.txtProductId.TabIndex = 9;
            this.txtProductId.TextChanged += new System.EventHandler(this.txtProductId_TextChanged);
            // 
            // txtDescription
            // 
            this.txtDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.Location = new System.Drawing.Point(230, 173);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(252, 23);
            this.txtDescription.TabIndex = 12;
            this.txtDescription.TextChanged += new System.EventHandler(this.txtProductDescription_TextChanged);
            // 
            // txtProductName
            // 
            this.txtProductName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductName.Location = new System.Drawing.Point(230, 135);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(252, 23);
            this.txtProductName.TabIndex = 14;
            this.txtProductName.TextChanged += new System.EventHandler(this.txtProductName_TextChanged);
            // 
            // previewPictureBox1
            // 
            this.previewPictureBox1.Location = new System.Drawing.Point(230, 335);
            this.previewPictureBox1.Name = "previewPictureBox1";
            this.previewPictureBox1.Size = new System.Drawing.Size(230, 148);
            this.previewPictureBox1.TabIndex = 16;
            this.previewPictureBox1.TabStop = false;
            this.previewPictureBox1.Click += new System.EventHandler(this.previewPictureBox_Click);
            // 
            // btnAddImage
            // 
            this.btnAddImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddImage.Location = new System.Drawing.Point(230, 275);
            this.btnAddImage.Name = "btnAddImage";
            this.btnAddImage.Size = new System.Drawing.Size(56, 37);
            this.btnAddImage.TabIndex = 17;
            this.btnAddImage.UseVisualStyleBackColor = true;
            this.btnAddImage.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // EnterDateTimePicker
            // 
            this.EnterDateTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EnterDateTimePicker.Location = new System.Drawing.Point(230, 236);
            this.EnterDateTimePicker.Name = "EnterDateTimePicker";
            this.EnterDateTimePicker.Size = new System.Drawing.Size(252, 23);
            this.EnterDateTimePicker.TabIndex = 18;
            this.EnterDateTimePicker.ValueChanged += new System.EventHandler(this.enterDateTimePicker_ValueChanged);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(264, 584);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(111, 48);
            this.btnSubmit.TabIndex = 19;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // txtEditBy
            // 
            this.txtEditBy.Location = new System.Drawing.Point(221, 515);
            this.txtEditBy.Name = "txtEditBy";
            this.txtEditBy.Size = new System.Drawing.Size(261, 20);
            this.txtEditBy.TabIndex = 20;
            this.txtEditBy.TextChanged += new System.EventHandler(this.txtEditBy_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(65, 518);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 17);
            this.label1.TabIndex = 21;
            this.label1.Text = "Edit by";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // ckBoxisValidChecked
            // 
            this.ckBoxisValidChecked.AutoSize = true;
            this.ckBoxisValidChecked.Location = new System.Drawing.Point(230, 206);
            this.ckBoxisValidChecked.Name = "ckBoxisValidChecked";
            this.ckBoxisValidChecked.Size = new System.Drawing.Size(15, 14);
            this.ckBoxisValidChecked.TabIndex = 22;
            this.ckBoxisValidChecked.UseVisualStyleBackColor = true;
            this.ckBoxisValidChecked.CheckedChanged += new System.EventHandler(this.ckBoxisValidChecked_CheckedChanged);
            // 
            // frmEditProductForm
            // 
            this.ClientSize = new System.Drawing.Size(569, 647);
            this.Controls.Add(this.ckBoxisValidChecked);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtEditBy);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.EnterDateTimePicker);
            this.Controls.Add(this.btnAddImage);
            this.Controls.Add(this.previewPictureBox1);
            this.Controls.Add(this.txtProductName);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtProductId);
            this.Controls.Add(this.lbEditProductExpiryDate);
            this.Controls.Add(this.lbEditProductDescription);
            this.Controls.Add(this.lbEditProductName);
            this.Controls.Add(this.lbEditProductIsAvalable);
            this.Controls.Add(this.lbEditProductImage);
            this.Controls.Add(this.lbEditProductId);
            this.Controls.Add(this.lbHeadding);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmEditProductForm";
            this.Text = "Edit Product";
            this.Load += new System.EventHandler(this.frmEditProductForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.previewPictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        #region Using Items
        private async void btnSubmit_Click(object sender, EventArgs e)
        {

            if (!int.TryParse(txtProductId.Text, out _))
            {
                MessageBox.Show("Please enter a valid numeric Product ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtProductName.Text))
            {
                MessageBox.Show("Please enter a valid Product Name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (int.TryParse(txtProductName.Text, out _))
            {
                MessageBox.Show("Product Name cannot be a numeric value.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validation for Product Description (Optional: Adjust the length based on your requirements)
            if (txtDescription.Text.Length > 255)
            {
                MessageBox.Show("Product Description should be less than 255 characters.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validate that an image has been selected
            if (string.IsNullOrEmpty(imageNameData))
            {
                MessageBox.Show("Please select an image.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            // Gather data from the form controls
            int productId = Convert.ToInt32(txtProductId.Text);
            string name = txtProductName.Text;
            string description = txtDescription.Text;
            bool isAvailable = ckBoxisValidChecked.Checked;
            DateTime expiryDate = EnterDateTimePicker.Value;
            // Assuming you have the image data as a base64 string
            string imageData1 = imageNameData; // Implement this function

            // Prepare the data to be sent to the server (You might need to adjust this based on your server API)
            var data = new
            {
                id = productId,
                names = name,
                descriptions = description,
                isAvalable = isAvailable,
                expirDate = expiryDate,
                imageData = imageData1,
                lastModifiedPerson = txtEditBy.Text,
                lastModifiedDate = DateTime.Now.ToString("yyyy-MM-dd")
            };






            // Serialize the data to JSON
            string jsonData = JsonConvert.SerializeObject(data);

            // Assuming you have an instance of HttpClient named _httpClient
            using (var content = new StringContent(jsonData, Encoding.UTF8, "application/json"))
            {
                // Send the PUT request to update the product
                HttpResponseMessage response = await _httpClient.PutAsync($"https://localhost:7141/product/{productId}", content);

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
        }

        private async void btnAdd_Click(object sender, System.EventArgs e)
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
                MessageBox.Show("Error adding data. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }




        private void lbProductId(object sender, EventArgs e)
        {

        }

        private void lbHeadding_Click(object sender, EventArgs e)
        {

        }

        private void lbProductName(object sender, EventArgs e)
        {

        }

        private void lbProductPrice(object sender, EventArgs e)
        {

        }

        private void lbProductDescription(object sender, EventArgs e)
        {

        }

        private void lbProductIsAvalable(object sender, EventArgs e)
        {

        }

        private void lbProductExpiryDate(object sender, EventArgs e)
        {

        }

        private void lbProductImage(object sender, EventArgs e)
        {

        }

        private void frmEditProductForm_Load(object sender, EventArgs e)
        {

        }

        private void txtProductId_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtProductName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtProductDescription_TextChanged(object sender, EventArgs e)
        {

        }

        private void isAvalableRadioButton_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void enterDateTimePicker_ValueChanged(object sender, EventArgs e)
        {

        }

        private void previewPictureBox_Click(object sender, EventArgs e)
        {

        }

        private void txtEditBy_TextChanged(object sender, EventArgs e)
        {

        }

        private void ckBoxisValidChecked_CheckedChanged(object sender, EventArgs e)
        {

        }
        #endregion
        #region Using Method
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
                    previewPictureBox1.Image = resizedImage;
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur during image resizing
                MessageBox.Show($"Error resizing image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        #endregion

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}