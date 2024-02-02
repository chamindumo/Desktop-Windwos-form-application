using System;
using System.Windows.Forms;

namespace Desktop_Windwos_form_application
{
    public partial class frmInputPromptForm : Form
    {
        private Button btnSubmit;
        private Label label1;
        private TextBox txtInput;

        public string InputText { get; private set; }

        public frmInputPromptForm()
        {
            InitializeComponent(); // Assuming you've added controls in the designer
        }

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

        private void InitializeComponent()
        {
            this.txtInput = new System.Windows.Forms.TextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(76, 112);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(161, 20);
            this.txtInput.TabIndex = 0;
            this.txtInput.TextChanged += new System.EventHandler(this.txtInput_TextChanged);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(108, 201);
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
            this.ClientSize = new System.Drawing.Size(304, 261);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.txtInput);
            this.Name = "frmInputPromptForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void txtInput_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            InputText = txtInput.Text; // Assuming you have a TextBox named textBoxInput
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}