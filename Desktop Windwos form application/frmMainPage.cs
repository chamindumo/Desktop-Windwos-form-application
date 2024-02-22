#region Using Directives

using Desktop_application;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms; 
#endregion

namespace Desktop_Windwos_form_application
{
    public class frmMainPage: Form
    {
        #region Uisng Variables
        public int loggingTo = 0;
        private static int pageNumber = 1; // Current page number
        private int itemsPerPage = 25; // Number of items per page
        private int totalProductsCount; // Total count of products
        List<Dictionary<string, string>> tableData = new List<Dictionary<string, string>>();
        private int maxPage;
        private MenuStrip File;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem editToolStripMenuItem;
        private Panel Sidepanel;
        private Button btnLogin;
        private Button btnPurchase;
        private Button btnNewUser;
        private Button btnBank;
        private Button btnDiscount;
        private Button btnPromotions;
        private Button btnProducts;
        private Button button1;
        private Button button2;
        private TextBox txtPageNum;
        private Button btnAddNewProduct;
        private Button btnAddNewPromotion;
        private Button btnAddNewBank;
        private BindingSource bindingSource1;
        private IContainer components;
        private DataGridView productDataGridView;
        private DataGridView promotionDataGridView;
        private DataGridView discountDataGridView;
        private DataGridView bankDataGridView;
        private BindingSource bindingSource2;
        private BindingSource bindingSource3;
        private BindingSource bindingSource4;
        private ToolStripMenuItem helpToolStripMenuItem;
        private Label lblUser;
        private Panel panel1;
        private Button btnMenu;
        private Label lblPromotion;
        private Label lblDiscount;
        private Label lblBank;
        private Label lblNewUser;
        private Label LblPurchace;
        private Label lblProduct;
        public string userName;
        #endregion
        #region Using Constructor
        public frmMainPage(int logging, string username)
        {
            InitializeComponent();
            loggingTo = logging;
            userName = username;
            lblUser.Text = userName;
            Bitmap iconProduct = new Bitmap("C://Users/Chamindu/source/repos/Desktop Windwos form application/Desktop Windwos form application/Icons/icons8-products-16.png"); // Replace "icon.png" with the actual file path
            Bitmap iconpromotion = new Bitmap("C://Users/Chamindu/source/repos/Desktop Windwos form application/Desktop Windwos form application/Icons/icons8-promotion-48.png"); // Replace "icon.png" with the actual file path
            Bitmap iconDiscount = new Bitmap("C://Users/Chamindu/source/repos/Desktop Windwos form application/Desktop Windwos form application/Icons/icons8-huge-sale-64.png"); // Replace "icon.png" with the actual file path
            Bitmap iconBank = new Bitmap("C://Users/Chamindu/source/repos/Desktop Windwos form application/Desktop Windwos form application/Icons/icons8-bank-48.png"); // Replace "icon.png" with the actual file path
            Bitmap iconNewUser = new Bitmap("C://Users/Chamindu/source/repos/Desktop Windwos form application/Desktop Windwos form application/Icons/icons8-add-user-male-48.png"); // Replace "icon.png" with the actual file path
            Bitmap iconPurchas = new Bitmap("C://Users/Chamindu/source/repos/Desktop Windwos form application/Desktop Windwos form application/Icons/icons8-purchase-for-euro-48.png"); // Replace "icon.png" with the actual file path
            Bitmap iconLogOut = new Bitmap("C://Users/Chamindu/source/repos/Desktop Windwos form application/Desktop Windwos form application/Icons/icons8-log-out-48.png"); // Replace "icon.png" with the actual file path
            Bitmap iconMenu = new Bitmap("C://Users/Chamindu/source/repos/Desktop Windwos form application/Desktop Windwos form application/Icons/icons8-menu-48.png"); // Replace "icon.png" with the actual file path

            int newWidth = 23; // Set your desired width
            int newHeight = 23; // Set your desired height
      
            Bitmap resizedProduct = new Bitmap(iconProduct, new Size(newWidth, newHeight));
            Bitmap resizedPrmotion = new Bitmap(iconpromotion, new Size(newWidth, newHeight));
            Bitmap resizedDiscount = new Bitmap(iconDiscount, new Size(newWidth, newHeight));
            Bitmap resizedBank = new Bitmap(iconBank, new Size(newWidth, newHeight));
            Bitmap resizedNewUser = new Bitmap(iconNewUser, new Size(newWidth, newHeight));
            Bitmap Purchas = new Bitmap(iconPurchas, new Size(newWidth, newHeight));
            Bitmap LogOut = new Bitmap(iconLogOut, new Size(newWidth, newHeight));
            Bitmap Menu = new Bitmap(iconMenu, new Size(newWidth, newHeight));









            // Set the icon for the button

            btnProducts.Image = resizedProduct;



            btnPromotions.Image = resizedPrmotion;
            btnDiscount.Image = resizedDiscount;
            btnBank.Image = resizedBank;
            btnNewUser.Image = resizedNewUser;
            btnPurchase.Image = Purchas;
            btnLogin.Image = LogOut;
            btnMenu.Image = Menu;
        }
        #endregion
        #region Using Initalize
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.File = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Sidepanel = new System.Windows.Forms.Panel();
            this.lblPromotion = new System.Windows.Forms.Label();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.lblBank = new System.Windows.Forms.Label();
            this.lblNewUser = new System.Windows.Forms.Label();
            this.LblPurchace = new System.Windows.Forms.Label();
            this.lblProduct = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnPurchase = new System.Windows.Forms.Button();
            this.btnNewUser = new System.Windows.Forms.Button();
            this.btnBank = new System.Windows.Forms.Button();
            this.btnDiscount = new System.Windows.Forms.Button();
            this.btnPromotions = new System.Windows.Forms.Button();
            this.btnProducts = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.txtPageNum = new System.Windows.Forms.TextBox();
            this.btnAddNewProduct = new System.Windows.Forms.Button();
            this.btnAddNewPromotion = new System.Windows.Forms.Button();
            this.btnAddNewBank = new System.Windows.Forms.Button();
            this.productDataGridView = new System.Windows.Forms.DataGridView();
            this.promotionDataGridView = new System.Windows.Forms.DataGridView();
            this.discountDataGridView = new System.Windows.Forms.DataGridView();
            this.bankDataGridView = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnMenu = new System.Windows.Forms.Button();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSource3 = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSource4 = new System.Windows.Forms.BindingSource(this.components);
            this.File.SuspendLayout();
            this.Sidepanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.productDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.promotionDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.discountDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bankDataGridView)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource4)).BeginInit();
            this.SuspendLayout();
            // 
            // File
            // 
            this.File.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.File.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.File.Location = new System.Drawing.Point(0, 0);
            this.File.Name = "File";
            this.File.Size = new System.Drawing.Size(1319, 24);
            this.File.TabIndex = 1;
            this.File.Text = "menuStrip2";
            this.File.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.File_ItemClicked);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            this.fileToolStripMenuItem.Click += new System.EventHandler(this.fileToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // Sidepanel
            // 
            this.Sidepanel.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.Sidepanel.Controls.Add(this.lblPromotion);
            this.Sidepanel.Controls.Add(this.lblDiscount);
            this.Sidepanel.Controls.Add(this.lblBank);
            this.Sidepanel.Controls.Add(this.lblNewUser);
            this.Sidepanel.Controls.Add(this.LblPurchace);
            this.Sidepanel.Controls.Add(this.lblProduct);
            this.Sidepanel.Controls.Add(this.lblUser);
            this.Sidepanel.Controls.Add(this.btnLogin);
            this.Sidepanel.Controls.Add(this.btnPurchase);
            this.Sidepanel.Controls.Add(this.btnNewUser);
            this.Sidepanel.Controls.Add(this.btnBank);
            this.Sidepanel.Controls.Add(this.btnDiscount);
            this.Sidepanel.Controls.Add(this.btnPromotions);
            this.Sidepanel.Controls.Add(this.btnProducts);
            this.Sidepanel.Location = new System.Drawing.Point(0, 78);
            this.Sidepanel.Name = "Sidepanel";
            this.Sidepanel.Size = new System.Drawing.Size(84, 679);
            this.Sidepanel.TabIndex = 3;
            this.Sidepanel.Visible = false;
            this.Sidepanel.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // lblPromotion
            // 
            this.lblPromotion.AutoSize = true;
            this.lblPromotion.Location = new System.Drawing.Point(5, 175);
            this.lblPromotion.Name = "lblPromotion";
            this.lblPromotion.Size = new System.Drawing.Size(72, 17);
            this.lblPromotion.TabIndex = 17;
            this.lblPromotion.Text = "Promotion";
            // 
            // lblDiscount
            // 
            this.lblDiscount.AutoSize = true;
            this.lblDiscount.Location = new System.Drawing.Point(9, 246);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(63, 17);
            this.lblDiscount.TabIndex = 16;
            this.lblDiscount.Text = "Discount";
            // 
            // lblBank
            // 
            this.lblBank.AutoSize = true;
            this.lblBank.Location = new System.Drawing.Point(20, 318);
            this.lblBank.Name = "lblBank";
            this.lblBank.Size = new System.Drawing.Size(40, 17);
            this.lblBank.TabIndex = 15;
            this.lblBank.Text = "Bank";
            // 
            // lblNewUser
            // 
            this.lblNewUser.AutoSize = true;
            this.lblNewUser.Location = new System.Drawing.Point(5, 384);
            this.lblNewUser.Name = "lblNewUser";
            this.lblNewUser.Size = new System.Drawing.Size(69, 17);
            this.lblNewUser.TabIndex = 14;
            this.lblNewUser.Text = "New User";
            // 
            // LblPurchace
            // 
            this.LblPurchace.AutoSize = true;
            this.LblPurchace.Location = new System.Drawing.Point(6, 454);
            this.LblPurchace.Name = "LblPurchace";
            this.LblPurchace.Size = new System.Drawing.Size(68, 17);
            this.LblPurchace.TabIndex = 13;
            this.LblPurchace.Text = "Purchase";
            // 
            // lblProduct
            // 
            this.lblProduct.AutoSize = true;
            this.lblProduct.Location = new System.Drawing.Point(10, 104);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new System.Drawing.Size(57, 17);
            this.lblProduct.TabIndex = 12;
            this.lblProduct.Text = "Product";
            // 
            // lblUser
            // 
            this.lblUser.AccessibleDescription = "";
            this.lblUser.AutoSize = true;
            this.lblUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser.Location = new System.Drawing.Point(12, 17);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(52, 18);
            this.lblUser.TabIndex = 11;
            this.lblUser.Text = "label1";
            this.lblUser.Click += new System.EventHandler(this.lblUser_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(12, 479);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(52, 36);
            this.btnLogin.TabIndex = 10;
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogging_Click);
            // 
            // btnPurchase
            // 
            this.btnPurchase.Location = new System.Drawing.Point(12, 415);
            this.btnPurchase.Name = "btnPurchase";
            this.btnPurchase.Size = new System.Drawing.Size(52, 36);
            this.btnPurchase.TabIndex = 9;
            this.btnPurchase.UseVisualStyleBackColor = true;
            this.btnPurchase.Click += new System.EventHandler(this.btnPurchase_Click);
            // 
            // btnNewUser
            // 
            this.btnNewUser.Location = new System.Drawing.Point(12, 345);
            this.btnNewUser.Name = "btnNewUser";
            this.btnNewUser.Size = new System.Drawing.Size(52, 36);
            this.btnNewUser.TabIndex = 8;
            this.btnNewUser.UseVisualStyleBackColor = true;
            this.btnNewUser.Click += new System.EventHandler(this.btnNewUser_Click);
            // 
            // btnBank
            // 
            this.btnBank.Location = new System.Drawing.Point(13, 279);
            this.btnBank.Name = "btnBank";
            this.btnBank.Size = new System.Drawing.Size(52, 36);
            this.btnBank.TabIndex = 7;
            this.btnBank.UseVisualStyleBackColor = true;
            this.btnBank.Click += new System.EventHandler(this.btnBank_Click);
            // 
            // btnDiscount
            // 
            this.btnDiscount.Location = new System.Drawing.Point(12, 207);
            this.btnDiscount.Name = "btnDiscount";
            this.btnDiscount.Size = new System.Drawing.Size(52, 36);
            this.btnDiscount.TabIndex = 6;
            this.btnDiscount.UseVisualStyleBackColor = true;
            this.btnDiscount.Click += new System.EventHandler(this.btnDiscount_Click);
            // 
            // btnPromotions
            // 
            this.btnPromotions.Location = new System.Drawing.Point(12, 136);
            this.btnPromotions.Name = "btnPromotions";
            this.btnPromotions.Size = new System.Drawing.Size(52, 36);
            this.btnPromotions.TabIndex = 5;
            this.btnPromotions.UseVisualStyleBackColor = true;
            this.btnPromotions.Click += new System.EventHandler(this.btnPromotions_Click);
            // 
            // btnProducts
            // 
            this.btnProducts.Location = new System.Drawing.Point(12, 65);
            this.btnProducts.Name = "btnProducts";
            this.btnProducts.Size = new System.Drawing.Size(52, 36);
            this.btnProducts.TabIndex = 4;
            this.btnProducts.UseVisualStyleBackColor = true;
            this.btnProducts.Click += new System.EventHandler(this.btnProducts_Click);
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(605, 557);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(35, 27);
            this.button1.TabIndex = 5;
            this.button1.Text = "<-";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.btnPrv_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(709, 557);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(35, 27);
            this.button2.TabIndex = 6;
            this.button2.Text = "->";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // txtPageNum
            // 
            this.txtPageNum.Location = new System.Drawing.Point(663, 561);
            this.txtPageNum.Name = "txtPageNum";
            this.txtPageNum.ReadOnly = true;
            this.txtPageNum.Size = new System.Drawing.Size(17, 23);
            this.txtPageNum.TabIndex = 7;
            this.txtPageNum.Visible = false;
            this.txtPageNum.TextChanged += new System.EventHandler(this.txtPageNum_TextChanged);
            // 
            // btnAddNewProduct
            // 
            this.btnAddNewProduct.Location = new System.Drawing.Point(131, 9);
            this.btnAddNewProduct.Name = "btnAddNewProduct";
            this.btnAddNewProduct.Size = new System.Drawing.Size(118, 36);
            this.btnAddNewProduct.TabIndex = 0;
            this.btnAddNewProduct.Text = "+ Add Product";
            this.btnAddNewProduct.UseVisualStyleBackColor = true;
            this.btnAddNewProduct.Click += new System.EventHandler(this.btnAddNewProduct_Click);
            // 
            // btnAddNewPromotion
            // 
            this.btnAddNewPromotion.Location = new System.Drawing.Point(321, 9);
            this.btnAddNewPromotion.Name = "btnAddNewPromotion";
            this.btnAddNewPromotion.Size = new System.Drawing.Size(134, 36);
            this.btnAddNewPromotion.TabIndex = 11;
            this.btnAddNewPromotion.Text = "+ Add Promotion";
            this.btnAddNewPromotion.UseVisualStyleBackColor = true;
            this.btnAddNewPromotion.Click += new System.EventHandler(this.btnAddNewPromotion_Click);
            // 
            // btnAddNewBank
            // 
            this.btnAddNewBank.Location = new System.Drawing.Point(524, 9);
            this.btnAddNewBank.Name = "btnAddNewBank";
            this.btnAddNewBank.Size = new System.Drawing.Size(131, 36);
            this.btnAddNewBank.TabIndex = 13;
            this.btnAddNewBank.Text = "+ Add Bank";
            this.btnAddNewBank.UseVisualStyleBackColor = true;
            this.btnAddNewBank.Click += new System.EventHandler(this.btnAddNewBank_Click);
            // 
            // productDataGridView
            // 
            this.productDataGridView.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.productDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.productDataGridView.Location = new System.Drawing.Point(153, 143);
            this.productDataGridView.Name = "productDataGridView";
            this.productDataGridView.Size = new System.Drawing.Size(1087, 406);
            this.productDataGridView.TabIndex = 4;
            this.productDataGridView.Visible = false;
            this.productDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.productdataGrid_CellContentClick);
            // 
            // promotionDataGridView
            // 
            this.promotionDataGridView.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.promotionDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.promotionDataGridView.Location = new System.Drawing.Point(153, 143);
            this.promotionDataGridView.Name = "promotionDataGridView";
            this.promotionDataGridView.Size = new System.Drawing.Size(1098, 393);
            this.promotionDataGridView.TabIndex = 8;
            this.promotionDataGridView.Visible = false;
            this.promotionDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.promotionDataGrid_CellContentClick);
            // 
            // discountDataGridView
            // 
            this.discountDataGridView.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.discountDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.discountDataGridView.Location = new System.Drawing.Point(153, 143);
            this.discountDataGridView.Name = "discountDataGridView";
            this.discountDataGridView.Size = new System.Drawing.Size(1108, 377);
            this.discountDataGridView.TabIndex = 9;
            this.discountDataGridView.Visible = false;
            this.discountDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.discountDataGrid_CellContentClick);
            // 
            // bankDataGridView
            // 
            this.bankDataGridView.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.bankDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.bankDataGridView.Location = new System.Drawing.Point(454, 143);
            this.bankDataGridView.Name = "bankDataGridView";
            this.bankDataGridView.Size = new System.Drawing.Size(268, 383);
            this.bankDataGridView.TabIndex = 10;
            this.bankDataGridView.Visible = false;
            this.bankDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.BankDataGrid_CellContentClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel1.Controls.Add(this.btnMenu);
            this.panel1.Controls.Add(this.btnAddNewProduct);
            this.panel1.Controls.Add(this.btnAddNewBank);
            this.panel1.Controls.Add(this.btnAddNewPromotion);
            this.panel1.Location = new System.Drawing.Point(0, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1445, 55);
            this.panel1.TabIndex = 14;
            // 
            // btnMenu
            // 
            this.btnMenu.Location = new System.Drawing.Point(16, 9);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(50, 36);
            this.btnMenu.TabIndex = 14;
            this.btnMenu.UseVisualStyleBackColor = true;
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // bindingSource1
            // 
            this.bindingSource1.CurrentChanged += new System.EventHandler(this.bindingSource1_CurrentChanged);
            // 
            // bindingSource2
            // 
            this.bindingSource2.CurrentChanged += new System.EventHandler(this.bindingSource2_CurrentChanged);
            // 
            // bindingSource3
            // 
            this.bindingSource3.CurrentChanged += new System.EventHandler(this.bindingSource3_CurrentChanged);
            // 
            // bindingSource4
            // 
            this.bindingSource4.CurrentChanged += new System.EventHandler(this.bindingSource4_CurrentChanged);
            // 
            // frmMainPage
            // 
            this.BackgroundImage = global::Desktop_Windwos_form_application.Properties.Resources.pexels_nothing_ahead_8670494;
            this.ClientSize = new System.Drawing.Size(1319, 660);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.bankDataGridView);
            this.Controls.Add(this.discountDataGridView);
            this.Controls.Add(this.promotionDataGridView);
            this.Controls.Add(this.txtPageNum);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.productDataGridView);
            this.Controls.Add(this.Sidepanel);
            this.Controls.Add(this.File);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmMainPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Kiwi Suit";
            this.Load += new System.EventHandler(this.frmMainPage_Load);
            this.File.ResumeLayout(false);
            this.File.PerformLayout();
            this.Sidepanel.ResumeLayout(false);
            this.Sidepanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.productDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.promotionDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.discountDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bankDataGridView)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        #region Using Items
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (Sidepanel.Visible)
            {
                // If it's visible, hide it
                Sidepanel.Visible = false;
            }
            else
            {
                // If it's hidden, show it
                Sidepanel.Visible = true;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private async void btnProducts_Click(object sender, EventArgs e)
        {
            await OnOptionClicked();
            await OnOption1Clicked();


        }

        private void productdataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewCell clickedCell = productDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];

                if (clickedCell is DataGridViewButtonCell)
                {
                    // Handle the button click based on the column name
                    string columnName = productDataGridView.Columns[e.ColumnIndex].Name;

                    if (columnName == "btnViewDetails")
                    {

                        int productId = Convert.ToInt32(productDataGridView.Rows[e.RowIndex].Cells["Id"].Value);
                        string name = Convert.ToString(productDataGridView.Rows[e.RowIndex].Cells["Names"].Value);
                        string description = Convert.ToString(productDataGridView.Rows[e.RowIndex].Cells["Descriptions"].Value);
                        bool isAvailable = Convert.ToBoolean(productDataGridView.Rows[e.RowIndex].Cells["IsAvalable"].Value);
                        DateTime expiryDate = Convert.ToDateTime(productDataGridView.Rows[e.RowIndex].Cells["ExpirDate"].Value);
                        string imageData = Convert.ToString(productDataGridView.Rows[e.RowIndex].Cells["ImageData"].Value);

                        // Open the edit form and pass the data
                        frmEditProductForm editForm = new frmEditProductForm(productId, name, description, isAvailable, expiryDate, imageData,userName);
                        editForm.ShowDialog();

                        // Add your logic for View Details button click
                    }
                    else if (columnName == "btnEdit")
                    {
                        string productId = productDataGridView.Rows[e.RowIndex].Cells["Id"].Value.ToString();
                        string productName = productDataGridView.Rows[e.RowIndex].Cells["Names"].Value.ToString();

                        frmAddDiscount addDiscountPage = new frmAddDiscount(loggingTo, productId, productName);
                        addDiscountPage.Show();
                        this.Hide();

                        // Add your logic for Edit button click
                    }
                }
            }
        }



        
        private bool ColumnExists(DataGridView dataGridView, string columnName)
        {
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                if (column.Name == columnName)
                {
                    return true;
                }
            }
            return false;
        }

      

        private void btnPrv_Click(object sender, EventArgs e)
        {
            if (pageNumber > 1)
            {
                pageNumber--; // Decrement page number
                button2.Enabled = true;
                txtPageNum.Text = pageNumber.ToString();


                // Reload data for the previous page
                OnOptionClicked();
            }
            UpdateButtonVisibility();
        }

        private async void btnNext_Click(object sender, EventArgs e)
        {
            totalProductsCount = await GetTotalProductsCount();
            maxPage = (int)Math.Ceiling((double)totalProductsCount / itemsPerPage);
            // Reload data for the next page
            if (pageNumber < maxPage + 1)
            {

                // If there is no more data, disable the "Next" button
                await OnOptionClicked();
                pageNumber++; // Increment page number]
                txtPageNum.Text = pageNumber.ToString();



            }
            else
            {

                button2.Enabled = false;
            }
            UpdateButtonVisibility();

        }

        private void txtPageNum_TextChanged(object sender, EventArgs e)
        {

        }

        private void UpdateButtonVisibility()
        {
            // Disable "Previous" button when pageNumber is 1, otherwise enable both buttons
            button1.Enabled = pageNumber > 1;
        }



        private void promotionDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewCell clickedCell = promotionDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];

                if (clickedCell is DataGridViewButtonCell)
                {
                    // Handle the button click based on the column name
                    string columnName = promotionDataGridView.Columns[e.ColumnIndex].Name;

                    if (columnName == "btnViewDetails")
                    {
                        string promotionId = promotionDataGridView.Rows[e.RowIndex].Cells["PromotionId"].Value.ToString();
                        string payMethod = promotionDataGridView.Rows[e.RowIndex].Cells["PayMethod"].Value.ToString();
                        decimal discountNumber = Convert.ToDecimal(promotionDataGridView.Rows[e.RowIndex].Cells["DiscountNumber"].Value);
                        DateTime startDate = Convert.ToDateTime(promotionDataGridView.Rows[e.RowIndex].Cells["StartDate"].Value);
                        DateTime endDate = Convert.ToDateTime(promotionDataGridView.Rows[e.RowIndex].Cells["EndDate"].Value);
                        bool isValid = Convert.ToBoolean(promotionDataGridView.Rows[e.RowIndex].Cells["IsValid"].Value);

                        // Pass the additional data when creating the form
                        frmEditPromotion editForm = new frmEditPromotion(promotionId, payMethod, discountNumber, startDate, endDate, isValid,userName);
                        editForm.ShowDialog();
                    }
                    else if (columnName == "btnEdit")
                    {
                        MessageBox.Show("Edit button clicked for row " + e.RowIndex);
                        // Add your logic for Edit button click
                    }
                }
            }
        }

        private async void btnPromotions_Click(object sender, EventArgs e)
        {
            await onOptionClicked1();
            productDataGridView.Visible = false;
            productDataGridView.Visible = false;
            button1.Visible = false;
            button2.Visible = false;
            txtPageNum.Visible = false;
            promotionDataGridView.Visible = true;


        }

        private void discountDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewCell clickedCell = discountDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];

                if (clickedCell is DataGridViewButtonCell)
                {
                    // Handle the button click based on the column name
                    string columnName = discountDataGridView.Columns[e.ColumnIndex].Name;

                    if (columnName == "btnViewDetails")
                    {
                        int discountId = Convert.ToInt32(discountDataGridView.Rows[e.RowIndex].Cells["DiscountId"].Value);
                        string productname = discountDataGridView.Rows[e.RowIndex].Cells["ProductName"].Value.ToString();
                        int productId = Convert.ToInt32(discountDataGridView.Rows[e.RowIndex].Cells["ProductId"].Value);
                        decimal discountNumber = Convert.ToDecimal(discountDataGridView.Rows[e.RowIndex].Cells["DiscountNumber"].Value);
                        DateTime startDate = Convert.ToDateTime(discountDataGridView.Rows[e.RowIndex].Cells["StartDate"].Value);
                        DateTime endDate = Convert.ToDateTime(discountDataGridView.Rows[e.RowIndex].Cells["EndDate"].Value);
                        bool isValid = Convert.ToBoolean(discountDataGridView.Rows[e.RowIndex].Cells["IsValid"].Value);
                        string paymentMethod = discountDataGridView.Rows[e.RowIndex].Cells["PaymentMethod"].Value.ToString();

                        frmEditDiscount editForm = new frmEditDiscount(discountId, productId, discountNumber, startDate, endDate, isValid, paymentMethod, productname,userName);
                        editForm.ShowDialog();


                        // Add your logic for View Details button click
                    }
                    else if (columnName == "btnEdit")
                    {
                        MessageBox.Show("Edit button clicked for row " + e.RowIndex);
                        // Add your logic for Edit button click
                    }
                }
            }
        }

        private async void btnDiscount_Click(object sender, EventArgs e)
        {
            await onOptionClicked2();
            productDataGridView.Visible = false;
            productDataGridView.Visible = false;
            button1.Visible = false;
            button2.Visible = false;
            txtPageNum.Visible = false;
            promotionDataGridView.Visible = false;

        }

        private async void btnBank_Click(object sender, EventArgs e)
        {
            await onOptionClicked3();
            productDataGridView.Visible = false;
            button1.Visible = false;
            button2.Visible = false;
            txtPageNum.Visible = false;
            promotionDataGridView.Visible = false;
            discountDataGridView.Visible = false;


        }

        private void BankDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnLogging_Click(object sender, EventArgs e)
        {
            frmLogin loggingPage = new frmLogin();
            loggingPage.Show();
            this.Hide();
        }

        private void btnAddNewProduct_Click(object sender, EventArgs e)
        {
            frmAddProduct addProductPage = new frmAddProduct(userName,loggingTo);
            addProductPage.Show();
            this.Hide();
        }

        private void btnAddNewBank_Click(object sender, EventArgs e)
        {
            frmAddBank addBankPage = new frmAddBank(userName,loggingTo);
            addBankPage.Show();
            this.Hide();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btnAddNewPromotion_Click(object sender, EventArgs e)
        {
            frmAddPromotions addPromotionPage = new frmAddPromotions(userName,loggingTo);
            addPromotionPage.Show();
            this.Hide();
        }

        private void btnPurchase_Click(object sender, EventArgs e)
        {
            frmAddPurchase addPurchasePage = new frmAddPurchase(userName,loggingTo);
            addPurchasePage.Show();
        }

        private void btnNewUser_Click(object sender, EventArgs e)
        {
            frmAddNew addNew = new frmAddNew(loggingTo);
            addNew.Show();
        }

        private void File_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void bindingSource2_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void bindingSource3_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void bindingSource4_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void frmMainPage_Load(object sender, EventArgs e)
        {

        }
        private void lbName_Click(object sender, EventArgs e)
        {

        }
        private void lblUser_Click(object sender, EventArgs e)
        {

        }
        private void btnMenu_Click(object sender, EventArgs e)
        {
            if (Sidepanel.Visible)
            {
                // If it's visible, hide it
                Sidepanel.Visible = false;
            }
            else
            {
                // If it's hidden, show it
                Sidepanel.Visible = true;
            }
        }
        #endregion
        #region Using Method


        private async Task onOptionClicked2()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://localhost:7141/discounts");

            string content = await response.Content.ReadAsStringAsync();

            BindingList<Discount> promotions = JsonConvert.DeserializeObject<BindingList<Discount>>(content);

            this.bindingSource3.DataSource = promotions;
            this.discountDataGridView.DataSource = this.bindingSource3;



            if (!ColumnExists(discountDataGridView, "btnViewDetails"))
            {
                DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
                buttonColumn.HeaderText = "Edit";
                buttonColumn.Text = "Edit";
                buttonColumn.Name = "btnViewDetails";
                buttonColumn.UseColumnTextForButtonValue = true;
                discountDataGridView.Columns.Add(buttonColumn);
            }


            discountDataGridView.Visible = true;
            productDataGridView.Visible = false;
            promotionDataGridView.Visible = false;
            bankDataGridView.Visible = false;

        }


        private async Task onOptionClicked3()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://localhost:7141/api/banks");

            string content = await response.Content.ReadAsStringAsync();

            BindingList<BankModelDTO> banks = JsonConvert.DeserializeObject<BindingList<BankModelDTO>>(content);
            this.bindingSource4.DataSource = banks;
            this.bankDataGridView.DataSource = this.bindingSource4;



            bankDataGridView.Visible = true;
            productDataGridView.Visible = false;
            promotionDataGridView.Visible = false;
            discountDataGridView.Visible = false;

        }


        private async Task OnOptionClicked()
        {
            productDataGridView.Rows.Clear();

            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync($"https://localhost:7141/Allproduct?pageNumber={pageNumber}&itemsPerPage={itemsPerPage}");

            string content = await response.Content.ReadAsStringAsync();


            BindingList<ProductDTO> products = JsonConvert.DeserializeObject<BindingList<ProductDTO>>(content);
            // Create a dictionary to store the list of products
            Dictionary<string, List<Dictionary<string, string>>> productDictionary = new Dictionary<string, List<Dictionary<string, string>>>();

            // Convert each ProductData object into a dictionary and add it to the list


            List<Dictionary<string, string>> productList = new List<Dictionary<string, string>>();
            this.bindingSource2.DataSource = products;
            this.productDataGridView.DataSource = this.bindingSource2;
        }

        private async Task OnOption1Clicked()
        {



            if (!ColumnExists(productDataGridView, "btnViewDetails"))
            {
                DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
                buttonColumn.HeaderText = "Edit";
                buttonColumn.Text = "Edit";
                buttonColumn.Name = "btnViewDetails";
                buttonColumn.UseColumnTextForButtonValue = true;
                productDataGridView.Columns.Add(buttonColumn);
            }

            if (!ColumnExists(productDataGridView, "btnEdit"))
            {
                DataGridViewButtonColumn editButtonColumn = new DataGridViewButtonColumn();
                editButtonColumn.HeaderText = "Promotion";
                editButtonColumn.Text = "Promotion";
                editButtonColumn.Name = "btnEdit";
                editButtonColumn.UseColumnTextForButtonValue = true;
                productDataGridView.Columns.Add(editButtonColumn);
                productDataGridView.CellContentClick += productdataGrid_CellContentClick;

            }
            productDataGridView.Visible = true;
            promotionDataGridView.Visible = false;
            discountDataGridView.Visible = false;
            bankDataGridView.Visible = false;


            button1.Visible = true;
            button2.Visible = true;
            txtPageNum.Visible = true;
            txtPageNum.Text = pageNumber.ToString();


        }

        private async Task onOptionClicked1()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://localhost:7141/promotions");

            string content = await response.Content.ReadAsStringAsync();

            BindingList<PromotionDTO> promotions = JsonConvert.DeserializeObject<BindingList<PromotionDTO>>(content);
            this.bindingSource1.DataSource = promotions;
            this.promotionDataGridView.DataSource = this.bindingSource1;


            if (!ColumnExists(promotionDataGridView, "btnViewDetails"))
            {
                DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
                buttonColumn.HeaderText = "Edit";
                buttonColumn.Text = "Edit";
                buttonColumn.Name = "btnViewDetails";
                buttonColumn.UseColumnTextForButtonValue = true;
                promotionDataGridView.Columns.Add(buttonColumn);
            }


            promotionDataGridView.Visible = true;
            productDataGridView.Visible = false;
            discountDataGridView.Visible = false;
            bankDataGridView.Visible = false;

        }

        private async Task<int> GetTotalProductsCount()
        {
            // Use your API call or database query to get the total count of products
            // For example, with an HTTP call
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://localhost:7141/product");
            string content = await response.Content.ReadAsStringAsync();

            // Deserialize the content to get the list of products
            List<ProductDTO> products = JsonConvert.DeserializeObject<List<ProductDTO>>(content);

            // Calculate and return the count of products
            return products.Count;


        }


        #endregion

       
    }
}
