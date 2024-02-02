using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop_Windwos_form_application
{
    public class frmAvalableProduct: Form
    {
        private BindingSource StockbindingSource;
        private DataGridView avalableStockDataGridView;
        private TextBox txtSearch;
        private System.ComponentModel.IContainer components;
        private Label lbHeadder;
        public List<AvalableStock> stock; // New list to store the original data


        public frmAvalableProduct()
        {
            FetchStock();
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.StockbindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.avalableStockDataGridView = new System.Windows.Forms.DataGridView();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lbHeadder = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.StockbindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.avalableStockDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // StockbindingSource
            // 
            this.StockbindingSource.CurrentChanged += new System.EventHandler(this.StockbindingSource_CurrentChanged);
            // 
            // avalableStockDataGridView
            // 
            this.avalableStockDataGridView.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.avalableStockDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.avalableStockDataGridView.Location = new System.Drawing.Point(174, 92);
            this.avalableStockDataGridView.Name = "avalableStockDataGridView";
            this.avalableStockDataGridView.Size = new System.Drawing.Size(559, 229);
            this.avalableStockDataGridView.TabIndex = 0;
            this.avalableStockDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.avalableStockDataGridView_CellContentClick);
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(255, 37);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(173, 23);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // lbHeadder
            // 
            this.lbHeadder.AutoSize = true;
            this.lbHeadder.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHeadder.Location = new System.Drawing.Point(170, 40);
            this.lbHeadder.Name = "lbHeadder";
            this.lbHeadder.Size = new System.Drawing.Size(53, 17);
            this.lbHeadder.TabIndex = 2;
            this.lbHeadder.Text = "Search";
            // 
            // frmAvalableProduct
            // 
            this.ClientSize = new System.Drawing.Size(925, 355);
            this.Controls.Add(this.lbHeadder);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.avalableStockDataGridView);
            this.Name = "frmAvalableProduct";
            this.Text = "Avalable Stock";
            ((System.ComponentModel.ISupportInitialize)(this.StockbindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.avalableStockDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void StockbindingSource_CurrentChanged(object sender, System.EventArgs e)
        {

        }

        private void avalableStockDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private async Task FetchStock()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://localhost:7141/productitems");

            string content = await response.Content.ReadAsStringAsync();

            BindingList<AvalableStock> banks = JsonConvert.DeserializeObject<BindingList<AvalableStock>>(content);
            stock = JsonConvert.DeserializeObject<List<AvalableStock>>(content);

            this.StockbindingSource.DataSource = banks;
            this.avalableStockDataGridView.DataSource = this.StockbindingSource;



           

        }

        private void txtSearch_TextChanged(object sender, System.EventArgs e)
        {
            string searchTerm = txtSearch.Text.Trim();

            if (StockbindingSource.DataSource != null && !string.IsNullOrEmpty(searchTerm))
            {
                // Retrieve the original list of AvalableStock


                // Filter the list based on the product name containing the search term
                var filteredList = new BindingList<AvalableStock>(
                    stock.Where(stock => stock.ProductName.Contains(searchTerm)).ToList());

                // Update the DataGridView with the filtered list
                StockbindingSource.DataSource = filteredList;
                avalableStockDataGridView.DataSource = StockbindingSource;
            }
            else
            {
                // If the search term is empty, reset the DataSource to the original list
                StockbindingSource.DataSource = stock;
                avalableStockDataGridView.DataSource = StockbindingSource;
            }

        }
    }
}