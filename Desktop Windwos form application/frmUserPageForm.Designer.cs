﻿namespace Desktop_Windwos_form_application
{
    partial class frmUserPageForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txtProduct = new System.Windows.Forms.TextBox();
            this.txtQuentity = new System.Windows.Forms.TextBox();
            this.cmbPaymentMethode = new System.Windows.Forms.ComboBox();
            this.cmbPaymnttype = new System.Windows.Forms.ComboBox();
            this.lbLoyeltyCard = new System.Windows.Forms.Label();
            this.cmbLoyeltyCard = new System.Windows.Forms.ComboBox();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.txtExtraForCard = new System.Windows.Forms.TextBox();
            this.btnConform = new System.Windows.Forms.Button();
            this.btnCheackOut = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lstProduct = new System.Windows.Forms.ListView();
            this.lbUserTotal = new System.Windows.Forms.Label();
            this.totalCostLabel = new System.Windows.Forms.TextBox();
            this.txtCardNumber = new System.Windows.Forms.TextBox();
            this.lbTotal = new System.Windows.Forms.Label();
            this.lbQentity = new System.Windows.Forms.Label();
            this.lbPaymentType = new System.Windows.Forms.Label();
            this.lbPaymentMethod = new System.Windows.Forms.Label();
            this.lbAmount = new System.Windows.Forms.Label();
            this.lbCardNumber = new System.Windows.Forms.Label();
            this.lbExtraForCard = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnAddCustomer = new System.Windows.Forms.Button();
            this.btnAvalableProduct = new System.Windows.Forms.Button();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.ProductDataGrid = new System.Windows.Forms.DataGridView();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbUserName = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbHeadder = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btCalculator = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProductDataGrid)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtProduct
            // 
            this.txtProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProduct.Location = new System.Drawing.Point(56, 144);
            this.txtProduct.Name = "txtProduct";
            this.txtProduct.Size = new System.Drawing.Size(156, 23);
            this.txtProduct.TabIndex = 0;
            this.txtProduct.TextChanged += new System.EventHandler(this.txtProduct_TextChanged);
            // 
            // txtQuentity
            // 
            this.txtQuentity.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuentity.Location = new System.Drawing.Point(224, 144);
            this.txtQuentity.Name = "txtQuentity";
            this.txtQuentity.Size = new System.Drawing.Size(58, 23);
            this.txtQuentity.TabIndex = 2;
            this.txtQuentity.TextChanged += new System.EventHandler(this.txtQutity_TextChanged);
            // 
            // cmbPaymentMethode
            // 
            this.cmbPaymentMethode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPaymentMethode.FormattingEnabled = true;
            this.cmbPaymentMethode.Location = new System.Drawing.Point(1127, 166);
            this.cmbPaymentMethode.Name = "cmbPaymentMethode";
            this.cmbPaymentMethode.Size = new System.Drawing.Size(197, 24);
            this.cmbPaymentMethode.TabIndex = 3;
            this.cmbPaymentMethode.SelectedIndexChanged += new System.EventHandler(this.cmbPaymentMethode_SelectedIndexChanged);
            // 
            // cmbPaymnttype
            // 
            this.cmbPaymnttype.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPaymnttype.FormattingEnabled = true;
            this.cmbPaymnttype.Items.AddRange(new object[] {
            "Cash",
            "Card"});
            this.cmbPaymnttype.Location = new System.Drawing.Point(864, 166);
            this.cmbPaymnttype.Name = "cmbPaymnttype";
            this.cmbPaymnttype.Size = new System.Drawing.Size(192, 24);
            this.cmbPaymnttype.TabIndex = 4;
            this.cmbPaymnttype.SelectedIndexChanged += new System.EventHandler(this.cmdPaymentType_SelectedIndexChanged);
            // 
            // lbLoyeltyCard
            // 
            this.lbLoyeltyCard.AutoSize = true;
            this.lbLoyeltyCard.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLoyeltyCard.Location = new System.Drawing.Point(861, 225);
            this.lbLoyeltyCard.Name = "lbLoyeltyCard";
            this.lbLoyeltyCard.Size = new System.Drawing.Size(85, 17);
            this.lbLoyeltyCard.TabIndex = 5;
            this.lbLoyeltyCard.Text = "Loyalty card";
            this.lbLoyeltyCard.Click += new System.EventHandler(this.lbLoyeltyCard_Click);
            // 
            // cmbLoyeltyCard
            // 
            this.cmbLoyeltyCard.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbLoyeltyCard.FormattingEnabled = true;
            this.cmbLoyeltyCard.Items.AddRange(new object[] {
            "Phone Number",
            "Card Number",
            "No"});
            this.cmbLoyeltyCard.Location = new System.Drawing.Point(864, 255);
            this.cmbLoyeltyCard.Name = "cmbLoyeltyCard";
            this.cmbLoyeltyCard.Size = new System.Drawing.Size(192, 24);
            this.cmbLoyeltyCard.TabIndex = 6;
            this.cmbLoyeltyCard.SelectedIndexChanged += new System.EventHandler(this.cmbLoyeltyCard_SelectedIndexChanged);
            // 
            // txtAmount
            // 
            this.txtAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmount.Location = new System.Drawing.Point(864, 447);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(192, 23);
            this.txtAmount.TabIndex = 7;
            this.txtAmount.TextChanged += new System.EventHandler(this.txtAmount_TextChanged);
            // 
            // txtExtraForCard
            // 
            this.txtExtraForCard.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtExtraForCard.Location = new System.Drawing.Point(864, 353);
            this.txtExtraForCard.Name = "txtExtraForCard";
            this.txtExtraForCard.Size = new System.Drawing.Size(192, 23);
            this.txtExtraForCard.TabIndex = 8;
            this.txtExtraForCard.TextChanged += new System.EventHandler(this.txtExtraForloyelty_TextChanged);
            // 
            // btnConform
            // 
            this.btnConform.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConform.Location = new System.Drawing.Point(1127, 241);
            this.btnConform.Name = "btnConform";
            this.btnConform.Size = new System.Drawing.Size(201, 38);
            this.btnConform.TabIndex = 9;
            this.btnConform.Text = "Conform";
            this.btnConform.UseVisualStyleBackColor = true;
            this.btnConform.Click += new System.EventHandler(this.btnConform_Click);
            // 
            // btnCheackOut
            // 
            this.btnCheackOut.Location = new System.Drawing.Point(1131, 425);
            this.btnCheackOut.Name = "btnCheackOut";
            this.btnCheackOut.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnCheackOut.Size = new System.Drawing.Size(201, 45);
            this.btnCheackOut.TabIndex = 10;
            this.btnCheackOut.Text = "Check Out";
            this.btnCheackOut.UseVisualStyleBackColor = true;
            this.btnCheackOut.Click += new System.EventHandler(this.btnCheackOut_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(317, 134);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(74, 33);
            this.btnAdd.TabIndex = 11;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lstProduct
            // 
            this.lstProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstProduct.HideSelection = false;
            this.lstProduct.Location = new System.Drawing.Point(58, 181);
            this.lstProduct.Name = "lstProduct";
            this.lstProduct.Size = new System.Drawing.Size(156, 98);
            this.lstProduct.TabIndex = 13;
            this.lstProduct.UseCompatibleStateImageBehavior = false;
            this.lstProduct.SelectedIndexChanged += new System.EventHandler(this.lstProduct_SelectedIndexChanged);
            // 
            // lbUserTotal
            // 
            this.lbUserTotal.AutoSize = true;
            this.lbUserTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUserTotal.Location = new System.Drawing.Point(624, 650);
            this.lbUserTotal.Name = "lbUserTotal";
            this.lbUserTotal.Size = new System.Drawing.Size(48, 17);
            this.lbUserTotal.TabIndex = 14;
            this.lbUserTotal.Text = "Total :";
            this.lbUserTotal.Click += new System.EventHandler(this.lbTotal_Click);
            // 
            // totalCostLabel
            // 
            this.totalCostLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalCostLabel.Location = new System.Drawing.Point(687, 647);
            this.totalCostLabel.Name = "totalCostLabel";
            this.totalCostLabel.Size = new System.Drawing.Size(149, 23);
            this.totalCostLabel.TabIndex = 15;
            this.totalCostLabel.TextChanged += new System.EventHandler(this.totalCostLabel_TextChanged);
            // 
            // txtCardNumber
            // 
            this.txtCardNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCardNumber.Location = new System.Drawing.Point(1131, 353);
            this.txtCardNumber.Name = "txtCardNumber";
            this.txtCardNumber.Size = new System.Drawing.Size(201, 23);
            this.txtCardNumber.TabIndex = 16;
            this.txtCardNumber.TextChanged += new System.EventHandler(this.txtCardNumber_TextChanged);
            // 
            // lbTotal
            // 
            this.lbTotal.AutoSize = true;
            this.lbTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotal.Location = new System.Drawing.Point(55, 110);
            this.lbTotal.Name = "lbTotal";
            this.lbTotal.Size = new System.Drawing.Size(57, 17);
            this.lbTotal.TabIndex = 17;
            this.lbTotal.Text = "Product";
            this.lbTotal.Click += new System.EventHandler(this.lbProduct_Click);
            // 
            // lbQentity
            // 
            this.lbQentity.AutoSize = true;
            this.lbQentity.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbQentity.Location = new System.Drawing.Point(221, 110);
            this.lbQentity.Name = "lbQentity";
            this.lbQentity.Size = new System.Drawing.Size(61, 17);
            this.lbQentity.TabIndex = 18;
            this.lbQentity.Text = "Quantity";
            this.lbQentity.Click += new System.EventHandler(this.lbQuentity_Click);
            // 
            // lbPaymentType
            // 
            this.lbPaymentType.AutoSize = true;
            this.lbPaymentType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPaymentType.Location = new System.Drawing.Point(861, 134);
            this.lbPaymentType.Name = "lbPaymentType";
            this.lbPaymentType.Size = new System.Drawing.Size(94, 17);
            this.lbPaymentType.TabIndex = 19;
            this.lbPaymentType.Text = "Payment type";
            this.lbPaymentType.Click += new System.EventHandler(this.lbPaymentType_Click);
            // 
            // lbPaymentMethod
            // 
            this.lbPaymentMethod.AutoSize = true;
            this.lbPaymentMethod.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPaymentMethod.Location = new System.Drawing.Point(1124, 134);
            this.lbPaymentMethod.Name = "lbPaymentMethod";
            this.lbPaymentMethod.Size = new System.Drawing.Size(114, 17);
            this.lbPaymentMethod.TabIndex = 20;
            this.lbPaymentMethod.Text = "Payment Method";
            this.lbPaymentMethod.Click += new System.EventHandler(this.lbpaymentMethode_Click);
            // 
            // lbAmount
            // 
            this.lbAmount.AutoSize = true;
            this.lbAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAmount.Location = new System.Drawing.Point(861, 411);
            this.lbAmount.Name = "lbAmount";
            this.lbAmount.Size = new System.Drawing.Size(56, 17);
            this.lbAmount.TabIndex = 21;
            this.lbAmount.Text = "Amount";
            this.lbAmount.Click += new System.EventHandler(this.lbAmount_Click);
            // 
            // lbCardNumber
            // 
            this.lbCardNumber.AutoSize = true;
            this.lbCardNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCardNumber.Location = new System.Drawing.Point(1124, 320);
            this.lbCardNumber.Name = "lbCardNumber";
            this.lbCardNumber.Size = new System.Drawing.Size(96, 17);
            this.lbCardNumber.TabIndex = 22;
            this.lbCardNumber.Text = " Card Number";
            this.lbCardNumber.Click += new System.EventHandler(this.lbCardNumber_Click);
            // 
            // lbExtraForCard
            // 
            this.lbExtraForCard.AutoSize = true;
            this.lbExtraForCard.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbExtraForCard.Location = new System.Drawing.Point(861, 320);
            this.lbExtraForCard.Name = "lbExtraForCard";
            this.lbExtraForCard.Size = new System.Drawing.Size(93, 17);
            this.lbExtraForCard.TabIndex = 23;
            this.lbExtraForCard.Text = "Extra for card";
            this.lbExtraForCard.Click += new System.EventHandler(this.lbExtraForCard_Click);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.SystemColors.HighlightText;
            this.btnBack.Location = new System.Drawing.Point(9, 644);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(46, 34);
            this.btnBack.TabIndex = 24;
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnAddCustomer
            // 
            this.btnAddCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddCustomer.Location = new System.Drawing.Point(9, 55);
            this.btnAddCustomer.Name = "btnAddCustomer";
            this.btnAddCustomer.Size = new System.Drawing.Size(44, 34);
            this.btnAddCustomer.TabIndex = 25;
            this.btnAddCustomer.Text = "+\r\n\r\n";
            this.btnAddCustomer.UseVisualStyleBackColor = true;
            this.btnAddCustomer.Click += new System.EventHandler(this.btnAddCustomer_Click);
            // 
            // btnAvalableProduct
            // 
            this.btnAvalableProduct.BackColor = System.Drawing.SystemColors.HighlightText;
            this.btnAvalableProduct.Location = new System.Drawing.Point(9, 107);
            this.btnAvalableProduct.Name = "btnAvalableProduct";
            this.btnAvalableProduct.Size = new System.Drawing.Size(44, 34);
            this.btnAvalableProduct.TabIndex = 26;
            this.btnAvalableProduct.UseVisualStyleBackColor = false;
            this.btnAvalableProduct.Click += new System.EventHandler(this.btnAvalableProducts_Click_1);
            // 
            // bindingSource1
            // 
            this.bindingSource1.CurrentChanged += new System.EventHandler(this.bindingSource1_CurrentChanged);
            // 
            // ProductDataGrid
            // 
            this.ProductDataGrid.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ProductDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ProductDataGrid.Location = new System.Drawing.Point(56, 286);
            this.ProductDataGrid.MinimumSize = new System.Drawing.Size(30, 0);
            this.ProductDataGrid.Name = "ProductDataGrid";
            this.ProductDataGrid.Size = new System.Drawing.Size(780, 316);
            this.ProductDataGrid.TabIndex = 27;
            this.ProductDataGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ProductDataGrid_CellContentClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.Controls.Add(this.lbUserName);
            this.panel1.Controls.Add(this.lblTime);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lbHeadder);
            this.panel1.Location = new System.Drawing.Point(36, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1373, 89);
            this.panel1.TabIndex = 28;
            // 
            // lbUserName
            // 
            this.lbUserName.AutoSize = true;
            this.lbUserName.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUserName.Location = new System.Drawing.Point(1187, 44);
            this.lbUserName.Name = "lbUserName";
            this.lbUserName.Size = new System.Drawing.Size(103, 19);
            this.lbUserName.TabIndex = 30;
            this.lbUserName.Text = "lbUserName";
            this.lbUserName.Click += new System.EventHandler(this.lbUserName_Click);
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.Location = new System.Drawing.Point(648, 57);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(46, 17);
            this.lblTime.TabIndex = 29;
            this.lblTime.Text = "label2";
            this.lblTime.Click += new System.EventHandler(this.lblTime_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(633, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 32);
            this.label1.TabIndex = 28;
            this.label1.Text = "Kiwi Suit";
            // 
            // lbHeadder
            // 
            this.lbHeadder.AutoSize = true;
            this.lbHeadder.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHeadder.Location = new System.Drawing.Point(31, 25);
            this.lbHeadder.Name = "lbHeadder";
            this.lbHeadder.Size = new System.Drawing.Size(225, 32);
            this.lbHeadder.TabIndex = 27;
            this.lbHeadder.Text = "Order Summary";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DarkGray;
            this.panel2.Controls.Add(this.btCalculator);
            this.panel2.Controls.Add(this.btnAvalableProduct);
            this.panel2.Controls.Add(this.btnAddCustomer);
            this.panel2.Controls.Add(this.btnBack);
            this.panel2.Location = new System.Drawing.Point(-6, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(58, 691);
            this.panel2.TabIndex = 29;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(156, 592);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(10, 10);
            this.dataGridView1.TabIndex = 30;
            this.dataGridView1.Visible = false;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // btCalculator
            // 
            this.btCalculator.BackColor = System.Drawing.SystemColors.HighlightText;
            this.btCalculator.Location = new System.Drawing.Point(11, 157);
            this.btCalculator.Name = "btCalculator";
            this.btCalculator.Size = new System.Drawing.Size(44, 34);
            this.btCalculator.TabIndex = 27;
            this.btCalculator.UseVisualStyleBackColor = false;
            this.btCalculator.Click += new System.EventHandler(this.btCalculator_Click);
            // 
            // frmUserPageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1365, 685);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ProductDataGrid);
            this.Controls.Add(this.lbExtraForCard);
            this.Controls.Add(this.lbCardNumber);
            this.Controls.Add(this.lbAmount);
            this.Controls.Add(this.lbPaymentMethod);
            this.Controls.Add(this.lbPaymentType);
            this.Controls.Add(this.lbQentity);
            this.Controls.Add(this.lbTotal);
            this.Controls.Add(this.txtCardNumber);
            this.Controls.Add(this.totalCostLabel);
            this.Controls.Add(this.lbUserTotal);
            this.Controls.Add(this.lstProduct);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnCheackOut);
            this.Controls.Add(this.btnConform);
            this.Controls.Add(this.txtExtraForCard);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.cmbLoyeltyCard);
            this.Controls.Add(this.lbLoyeltyCard);
            this.Controls.Add(this.cmbPaymnttype);
            this.Controls.Add(this.cmbPaymentMethode);
            this.Controls.Add(this.txtQuentity);
            this.Controls.Add(this.txtProduct);
            this.Name = "frmUserPageForm";
            this.Text = "Kiwi Suit";
            this.Load += new System.EventHandler(this.UserPageForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProductDataGrid)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtProduct;
        private System.Windows.Forms.TextBox txtQuentity;
        private System.Windows.Forms.ComboBox cmbPaymentMethode;
        private System.Windows.Forms.ComboBox cmbPaymnttype;
        private System.Windows.Forms.Label lbLoyeltyCard;
        private System.Windows.Forms.ComboBox cmbLoyeltyCard;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.TextBox txtExtraForCard;
        private System.Windows.Forms.Button btnConform;
        private System.Windows.Forms.Button btnCheackOut;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ListView lstProduct;
        private System.Windows.Forms.Label lbUserTotal;
        private System.Windows.Forms.TextBox totalCostLabel;
        private System.Windows.Forms.TextBox txtCardNumber;
        private System.Windows.Forms.Label lbTotal;
        private System.Windows.Forms.Label lbQentity;
        private System.Windows.Forms.Label lbPaymentType;
        private System.Windows.Forms.Label lbPaymentMethod;
        private System.Windows.Forms.Label lbAmount;
        private System.Windows.Forms.Label lbCardNumber;
        private System.Windows.Forms.Label lbExtraForCard;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnAddCustomer;
        private System.Windows.Forms.Button btnAvalableProduct;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.DataGridView ProductDataGrid;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbHeadder;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lbUserName;
        private System.Windows.Forms.Button btCalculator;
    }
}