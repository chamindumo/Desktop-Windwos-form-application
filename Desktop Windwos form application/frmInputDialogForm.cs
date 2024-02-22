#region Using Directives
using System.Windows.Forms;
using System;

#endregion
namespace Desktop_Windwos_form_application
{
    public partial class frmInputDialogForm : Form
    {
        #region Using Variable
        private Button btnSubmit;
        private Label lbHeadding;
        private TextBox txtVerificationCode;
        public string VerificationCode { get; private set; }
        #endregion

        #region Using Constructor
        public frmInputDialogForm()
        {
            InitializeComponent();
        }
        #endregion


        #region Using Initalize
        private void InitializeComponent()
        {
            this.btnSubmit = new System.Windows.Forms.Button();
            this.lbHeadding = new System.Windows.Forms.Label();
            this.txtVerificationCode = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(105, 106);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(101, 39);
            this.btnSubmit.TabIndex = 0;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // lbHeadding
            // 
            this.lbHeadding.AutoSize = true;
            this.lbHeadding.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHeadding.Location = new System.Drawing.Point(85, 23);
            this.lbHeadding.Name = "lbHeadding";
            this.lbHeadding.Size = new System.Drawing.Size(164, 17);
            this.lbHeadding.TabIndex = 1;
            this.lbHeadding.Text = "Enter the Token Number";
            this.lbHeadding.Click += new System.EventHandler(this.lbHeadding_Click);
            // 
            // txtVerificationCode
            // 
            this.txtVerificationCode.Location = new System.Drawing.Point(66, 62);
            this.txtVerificationCode.Name = "txtVerificationCode";
            this.txtVerificationCode.Size = new System.Drawing.Size(199, 20);
            this.txtVerificationCode.TabIndex = 2;
            this.txtVerificationCode.TextChanged += new System.EventHandler(this.txterificationCode_TextChanged);
            // 
            // frmInputDialogForm
            // 
            this.ClientSize = new System.Drawing.Size(342, 166);
            this.Controls.Add(this.txtVerificationCode);
            this.Controls.Add(this.lbHeadding);
            this.Controls.Add(this.btnSubmit);
            this.Name = "frmInputDialogForm";
            this.Load += new System.EventHandler(this.frmInputDialogForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        #region Uisng Items
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            VerificationCode = txtVerificationCode.Text;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void lbHeadding_Click(object sender, EventArgs e)
        {

        }

        private void txterificationCode_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmInputDialogForm_Load(object sender, EventArgs e)
        {

        } 
        #endregion
    }

}