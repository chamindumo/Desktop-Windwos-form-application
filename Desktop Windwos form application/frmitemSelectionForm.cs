﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Desktop_Windwos_form_application
{
    public class frmItemSelectionForm : Form
    {
        private ListBox listBox;
        private Button okButton;
        private Button cancelButton;

        public string SelectedItem { get; private set; }

        public frmItemSelectionForm(Dictionary<string, int> itemIdMap)
        {
            InitializeComponents(itemIdMap);
        }

        private void InitializeComponents(Dictionary<string, int> itemIdMap)
        {
            listBox = new ListBox();
            okButton = new Button();
            cancelButton = new Button();

            // Set up ListBox
            listBox.DataSource = itemIdMap.Keys.ToList();
            listBox.Dock = DockStyle.Fill;

            // Set up OK button
            okButton.Text = "OK";
            okButton.DialogResult = DialogResult.OK;
            okButton.Click += OkButton_Click;

            // Set up Cancel button
            cancelButton.Text = "Cancel";
            cancelButton.DialogResult = DialogResult.Cancel;

            // Set up form layout
            Controls.Add(listBox);
            Controls.Add(okButton);
            Controls.Add(cancelButton);

            // Set up button layout
            okButton.Dock = DockStyle.Bottom;
            cancelButton.Dock = DockStyle.Bottom;

            Size = new Size(300, 200);
            Text = "Select Item";
            AcceptButton = okButton;
            CancelButton = cancelButton;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            SelectedItem = listBox.SelectedItem?.ToString();
            Close(); // Close the form when OK is clicked
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // frmItemSelectionForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "frmItemSelectionForm";
            this.Load += new System.EventHandler(this.ItemSelectionForm_Load);
            this.ResumeLayout(false);

        }

        private void ItemSelectionForm_Load(object sender, EventArgs e)
        {

        }
    }
}