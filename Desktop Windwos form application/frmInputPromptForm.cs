#region Using Directives
using System;
using System.Windows.Forms; 
#endregion

namespace Desktop_Windwos_form_application
{
    public partial class frmInputPromptForm : Form
    {
        #region Using Variable
        private Button btnSubmit;
        private Label label1;
        private TextBox txtInput;
        public string InputText { get; private set; }
        #endregion

        #region Using Constructor

        public frmInputPromptForm()
        {
            InitializeComponent(); // Assuming you've added controls in the designer
        }
        #endregion



        #region Uisng Initalize
        private void InitializeComponent()
        {
            this.txtInput = new System.Windows.Forms.TextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(79, 71);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(161, 20);
            this.txtInput.TabIndex = 0;
            this.txtInput.TextChanged += new System.EventHandler(this.txtInput_TextChanged);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(126, 110);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 1;
            this.btnSubmit.Text = "Ok";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(237, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Enter the Phone Number or Loyalty Card Number";
            // 
            // frmInputPromptForm
            // 
            this.ClientSize = new System.Drawing.Size(322, 172);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.txtInput);
            this.Name = "frmInputPromptForm";
            this.Load += new System.EventHandler(this.frmInputPromptForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        #region Uisng Items
        private void buttonOK_Click(object sender, EventArgs e)
        {
            InputText = txtInput.Text; // Assuming you have a TextBox named textBoxInput
            DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }


        private void txtInput_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {

            string userInput = txtInput.Text;

            // Check if the input is null or empty
            if (string.IsNullOrWhiteSpace(userInput))
            {
                MessageBox.Show("Please enter a valid input.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check if the input is a valid integer
            if (!int.TryParse(userInput, out _))
            {
                MessageBox.Show("Please enter a valid Number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Optionally, clear the invalid input or take other actions
                txtInput.Clear();
                return;
            }


            InputText = txtInput.Text; // Assuming you have a TextBox named textBoxInput
            DialogResult = DialogResult.OK;
            Close();
        }

        private void frmInputPromptForm_Load(object sender, EventArgs e)
        {

        } 
        #endregion
    }
}