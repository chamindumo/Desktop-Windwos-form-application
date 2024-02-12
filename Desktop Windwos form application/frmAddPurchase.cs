#region Using Directives

using System.Collections.Generic;
using System.Net.Http;
using System;
using System.Windows.Forms;
using System.Linq;
using Newtonsoft.Json;
using TextBox = System.Windows.Forms.TextBox;
using ListView = System.Windows.Forms.ListView;
using Button = System.Windows.Forms.Button;
using System.Text;
using System.Threading.Tasks; 
#endregion

namespace Desktop_Windwos_form_application
{
    public class frmAddPurchase: Form
    {

        #region Using Variable
        private readonly HttpClient _httpClient;
        public string productName = "";
        public int availableQuantity = 0;
        private static Random _random = new Random();
        public string NewproductName;
        Dictionary<int, string> ProductName = new Dictionary<int, string>();
        Dictionary<int, int> ProductId = new Dictionary<int, int>();
        Dictionary<int, int> ItemId = new Dictionary<int, int>();
        Dictionary<int, decimal> ItemCost = new Dictionary<int, decimal>();
        Dictionary<int, int> Quntity = new Dictionary<int, int>();
        Dictionary<int, decimal> ItemPrice = new Dictionary<int, decimal>();
        Dictionary<int, decimal> ItemSellprice = new Dictionary<int, decimal>();
        Dictionary<int, decimal> ItemSellCost = new Dictionary<int, decimal>();
        Dictionary<int, int> ItemQuntity = new Dictionary<int, int>();
        Dictionary<int, string> ItemName = new Dictionary<int, string>();
        private Dictionary<string, int> productIds = new Dictionary<string, int> { };
        private Dictionary<string, int> productCosts = new Dictionary<string, int>();
        private Dictionary<int, string> Product = new Dictionary<int, string>();
        public static int foundProductId = 0;
        private int quentity = 0;
        private Label lbHeadding;
        private Label lbBatchName;
        private Label lbItemSellPrice;
        private Label lbProductId;
        private Label lbTotalAmount;
        private Label lbQuantity;
        private Label lbItemPrice;
        private Label lbProductName;
        private Label lbSupplierId;
        private Label lbPurchaseDate;
        private TextBox txtBatchNumber;
        private TextBox txtPrice;
        private TextBox txtId;
        private TextBox txtProductName;
        private TextBox txtTotalAmount;
        private TextBox txtSupplierId;
        private TextBox txtQuentity;
        private TextBox txtSellPrice;
        private DateTimePicker purchaseDateTimePicker;
        private Button btnAdd;
        private DataGridView itemDataGridView;
        private DataGridViewTextBoxColumn ProductNameColoum;
        private DataGridViewTextBoxColumn ProductIDColumn1;
        private DataGridViewTextBoxColumn ItemPriceColumn1;
        private DataGridViewTextBoxColumn ItemSellPriceColumn1;
        private DataGridViewTextBoxColumn QuantityColumn1;
        private Button btnSubmit;
        private ListView ProductListView;
        public int loggingto;
        #endregion 
        #region Using Constructor
        public frmAddPurchase(int logging)
        {
            InitializeComponent();
            _httpClient = new HttpClient(); // Initialize _httpClient

            productCosts = new Dictionary<string, int>();
            Product = new Dictionary<int, string>();


            FetchProducts();
            loggingto = logging;
        }

        #endregion
        #region Using Initalize
        private void InitializeComponent()
        {
            this.lbHeadding = new System.Windows.Forms.Label();
            this.lbBatchName = new System.Windows.Forms.Label();
            this.lbItemSellPrice = new System.Windows.Forms.Label();
            this.lbProductId = new System.Windows.Forms.Label();
            this.lbTotalAmount = new System.Windows.Forms.Label();
            this.lbQuantity = new System.Windows.Forms.Label();
            this.lbItemPrice = new System.Windows.Forms.Label();
            this.lbProductName = new System.Windows.Forms.Label();
            this.lbSupplierId = new System.Windows.Forms.Label();
            this.lbPurchaseDate = new System.Windows.Forms.Label();
            this.txtBatchNumber = new System.Windows.Forms.TextBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.txtTotalAmount = new System.Windows.Forms.TextBox();
            this.txtSupplierId = new System.Windows.Forms.TextBox();
            this.txtQuentity = new System.Windows.Forms.TextBox();
            this.txtSellPrice = new System.Windows.Forms.TextBox();
            this.purchaseDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.btnAdd = new System.Windows.Forms.Button();
            this.itemDataGridView = new System.Windows.Forms.DataGridView();
            this.ProductNameColoum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductIDColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemPriceColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemSellPriceColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QuantityColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.ProductListView = new System.Windows.Forms.ListView();
            ((System.ComponentModel.ISupportInitialize)(this.itemDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // lbHeadding
            // 
            this.lbHeadding.AutoSize = true;
            this.lbHeadding.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHeadding.Location = new System.Drawing.Point(379, 9);
            this.lbHeadding.Name = "lbHeadding";
            this.lbHeadding.Size = new System.Drawing.Size(136, 25);
            this.lbHeadding.TabIndex = 0;
            this.lbHeadding.Text = "Add Purchase";
            this.lbHeadding.Click += new System.EventHandler(this.lbHeadding_Click);
            // 
            // lbBatchName
            // 
            this.lbBatchName.AutoSize = true;
            this.lbBatchName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbBatchName.Location = new System.Drawing.Point(91, 82);
            this.lbBatchName.Name = "lbBatchName";
            this.lbBatchName.Size = new System.Drawing.Size(98, 17);
            this.lbBatchName.TabIndex = 1;
            this.lbBatchName.Text = "Batch Number";
            this.lbBatchName.Click += new System.EventHandler(this.lbPurchaseDate_Click);
            // 
            // lbItemSellPrice
            // 
            this.lbItemSellPrice.AutoSize = true;
            this.lbItemSellPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbItemSellPrice.Location = new System.Drawing.Point(448, 211);
            this.lbItemSellPrice.Name = "lbItemSellPrice";
            this.lbItemSellPrice.Size = new System.Drawing.Size(97, 17);
            this.lbItemSellPrice.TabIndex = 6;
            this.lbItemSellPrice.Text = "Item Sell Price";
            this.lbItemSellPrice.Click += new System.EventHandler(this.lbIItemSellPriceClick);
            // 
            // lbProductId
            // 
            this.lbProductId.AutoSize = true;
            this.lbProductId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbProductId.Location = new System.Drawing.Point(242, 210);
            this.lbProductId.Name = "lbProductId";
            this.lbProductId.Size = new System.Drawing.Size(74, 17);
            this.lbProductId.TabIndex = 7;
            this.lbProductId.Text = "Product ID";
            this.lbProductId.Click += new System.EventHandler(this.lbProductId_Click);
            // 
            // lbTotalAmount
            // 
            this.lbTotalAmount.AutoSize = true;
            this.lbTotalAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotalAmount.Location = new System.Drawing.Point(91, 174);
            this.lbTotalAmount.Name = "lbTotalAmount";
            this.lbTotalAmount.Size = new System.Drawing.Size(92, 17);
            this.lbTotalAmount.TabIndex = 8;
            this.lbTotalAmount.Text = "Total Amount";
            this.lbTotalAmount.Click += new System.EventHandler(this.lbTotalAmount_Click);
            // 
            // lbQuantity
            // 
            this.lbQuantity.AutoSize = true;
            this.lbQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbQuantity.Location = new System.Drawing.Point(575, 211);
            this.lbQuantity.Name = "lbQuantity";
            this.lbQuantity.Size = new System.Drawing.Size(61, 17);
            this.lbQuantity.TabIndex = 12;
            this.lbQuantity.Text = "Quantity";
            this.lbQuantity.Click += new System.EventHandler(this.lbQuentity_Click);
            // 
            // lbItemPrice
            // 
            this.lbItemPrice.AutoSize = true;
            this.lbItemPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbItemPrice.Location = new System.Drawing.Point(346, 212);
            this.lbItemPrice.Name = "lbItemPrice";
            this.lbItemPrice.Size = new System.Drawing.Size(70, 17);
            this.lbItemPrice.TabIndex = 13;
            this.lbItemPrice.Text = "Item Price";
            this.lbItemPrice.Click += new System.EventHandler(this.lbItemPrice_Click);
            // 
            // lbProductName
            // 
            this.lbProductName.AutoSize = true;
            this.lbProductName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbProductName.Location = new System.Drawing.Point(90, 210);
            this.lbProductName.Name = "lbProductName";
            this.lbProductName.Size = new System.Drawing.Size(98, 17);
            this.lbProductName.TabIndex = 14;
            this.lbProductName.Text = "Product Name";
            this.lbProductName.Click += new System.EventHandler(this.lbProductName_Click);
            // 
            // lbSupplierId
            // 
            this.lbSupplierId.AutoSize = true;
            this.lbSupplierId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSupplierId.Location = new System.Drawing.Point(91, 144);
            this.lbSupplierId.Name = "lbSupplierId";
            this.lbSupplierId.Size = new System.Drawing.Size(77, 17);
            this.lbSupplierId.TabIndex = 15;
            this.lbSupplierId.Text = "Supplier ID";
            this.lbSupplierId.Click += new System.EventHandler(this.lbSupplierId_Click);
            // 
            // lbPurchaseDate
            // 
            this.lbPurchaseDate.AutoSize = true;
            this.lbPurchaseDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPurchaseDate.Location = new System.Drawing.Point(91, 112);
            this.lbPurchaseDate.Name = "lbPurchaseDate";
            this.lbPurchaseDate.Size = new System.Drawing.Size(102, 17);
            this.lbPurchaseDate.TabIndex = 16;
            this.lbPurchaseDate.Text = "Purchase Date";
            // 
            // txtBatchNumber
            // 
            this.txtBatchNumber.Location = new System.Drawing.Point(227, 79);
            this.txtBatchNumber.Name = "txtBatchNumber";
            this.txtBatchNumber.Size = new System.Drawing.Size(200, 20);
            this.txtBatchNumber.TabIndex = 17;
            this.txtBatchNumber.TextChanged += new System.EventHandler(this.txtBatchNumber_TextChanged);
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(349, 250);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(67, 20);
            this.txtPrice.TabIndex = 18;
            this.txtPrice.TextChanged += new System.EventHandler(this.txtItemPrice_TextChanged);
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(245, 249);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(71, 20);
            this.txtId.TabIndex = 19;
            this.txtId.TextChanged += new System.EventHandler(this.txtProductId_TextChanged);
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(89, 249);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(121, 20);
            this.txtProductName.TabIndex = 20;
            this.txtProductName.TextChanged += new System.EventHandler(this.txtProductName_TextChanged);
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.Location = new System.Drawing.Point(227, 174);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.Size = new System.Drawing.Size(200, 20);
            this.txtTotalAmount.TabIndex = 21;
            this.txtTotalAmount.TextChanged += new System.EventHandler(this.txtTotalAmount_TextChanged);
            // 
            // txtSupplierId
            // 
            this.txtSupplierId.Location = new System.Drawing.Point(227, 144);
            this.txtSupplierId.Name = "txtSupplierId";
            this.txtSupplierId.Size = new System.Drawing.Size(200, 20);
            this.txtSupplierId.TabIndex = 22;
            this.txtSupplierId.TextChanged += new System.EventHandler(this.txtSuplierId_TextChanged);
            // 
            // txtQuentity
            // 
            this.txtQuentity.Location = new System.Drawing.Point(578, 250);
            this.txtQuentity.Name = "txtQuentity";
            this.txtQuentity.Size = new System.Drawing.Size(58, 20);
            this.txtQuentity.TabIndex = 23;
            this.txtQuentity.TextChanged += new System.EventHandler(this.txtQuentity_TextChanged);
            // 
            // txtSellPrice
            // 
            this.txtSellPrice.Location = new System.Drawing.Point(451, 249);
            this.txtSellPrice.Name = "txtSellPrice";
            this.txtSellPrice.Size = new System.Drawing.Size(64, 20);
            this.txtSellPrice.TabIndex = 24;
            this.txtSellPrice.TextChanged += new System.EventHandler(this.txtItemSellPrice_TextChanged);
            // 
            // purchaseDateTimePicker
            // 
            this.purchaseDateTimePicker.Location = new System.Drawing.Point(227, 112);
            this.purchaseDateTimePicker.Name = "purchaseDateTimePicker";
            this.purchaseDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.purchaseDateTimePicker.TabIndex = 25;
            this.purchaseDateTimePicker.ValueChanged += new System.EventHandler(this.PurchaseDateTimePicker_ValueChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(701, 241);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(90, 34);
            this.btnAdd.TabIndex = 26;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // itemDataGridView
            // 
            this.itemDataGridView.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.itemDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.itemDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProductNameColoum,
            this.ProductIDColumn1,
            this.ItemPriceColumn1,
            this.ItemSellPriceColumn1,
            this.QuantityColumn1});
            this.itemDataGridView.Location = new System.Drawing.Point(268, 312);
            this.itemDataGridView.Name = "itemDataGridView";
            this.itemDataGridView.Size = new System.Drawing.Size(605, 149);
            this.itemDataGridView.TabIndex = 27;
            this.itemDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.productsDataGridView_CellContentClick);
            // 
            // ProductNameColoum
            // 
            this.ProductNameColoum.HeaderText = "Product Name";
            this.ProductNameColoum.Name = "ProductNameColoum";
            // 
            // ProductIDColumn1
            // 
            this.ProductIDColumn1.HeaderText = "Product ID";
            this.ProductIDColumn1.Name = "ProductIDColumn1";
            // 
            // ItemPriceColumn1
            // 
            this.ItemPriceColumn1.HeaderText = "Item Price";
            this.ItemPriceColumn1.Name = "ItemPriceColumn1";
            // 
            // ItemSellPriceColumn1
            // 
            this.ItemSellPriceColumn1.HeaderText = "Item Sell Price";
            this.ItemSellPriceColumn1.Name = "ItemSellPriceColumn1";
            // 
            // QuantityColumn1
            // 
            this.QuantityColumn1.HeaderText = "Quantity";
            this.QuantityColumn1.Name = "QuantityColumn1";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(505, 487);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(148, 37);
            this.btnSubmit.TabIndex = 28;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnsubmit_Click);
            // 
            // ProductListView
            // 
            this.ProductListView.HideSelection = false;
            this.ProductListView.Location = new System.Drawing.Point(89, 284);
            this.ProductListView.Name = "ProductListView";
            this.ProductListView.Size = new System.Drawing.Size(121, 97);
            this.ProductListView.TabIndex = 29;
            this.ProductListView.UseCompatibleStateImageBehavior = false;
            this.ProductListView.SelectedIndexChanged += new System.EventHandler(this.ProductListView_SelectedIndexChanged);
            // 
            // frmAddPurchase
            // 
            this.ClientSize = new System.Drawing.Size(906, 536);
            this.Controls.Add(this.ProductListView);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.itemDataGridView);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.purchaseDateTimePicker);
            this.Controls.Add(this.txtSellPrice);
            this.Controls.Add(this.txtQuentity);
            this.Controls.Add(this.txtSupplierId);
            this.Controls.Add(this.txtTotalAmount);
            this.Controls.Add(this.txtProductName);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.txtBatchNumber);
            this.Controls.Add(this.lbPurchaseDate);
            this.Controls.Add(this.lbSupplierId);
            this.Controls.Add(this.lbProductName);
            this.Controls.Add(this.lbItemPrice);
            this.Controls.Add(this.lbQuantity);
            this.Controls.Add(this.lbTotalAmount);
            this.Controls.Add(this.lbProductId);
            this.Controls.Add(this.lbItemSellPrice);
            this.Controls.Add(this.lbBatchName);
            this.Controls.Add(this.lbHeadding);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmAddPurchase";
            this.Text = "Add Purchase";
            this.Load += new System.EventHandler(this.frmAddPurchase_Load);
            ((System.ComponentModel.ISupportInitialize)(this.itemDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        #region Using method
        private async void FetchProducts()
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync("https://localhost:7141/product");

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    var products = JsonConvert.DeserializeObject<List<ProductDTO>>(content);

                    foreach (var product in products)
                    {
                        // Assuming 'product.Name' is the name and 'product.Price' is the price
                        Product[product.Id] = product.Names;
                        productCosts[product.Names] = product.Id;



                    }

                }
                else
                {
                    // Handle the case where the response is unsuccessful
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
            }
        }



       

        int counter = 1;

        private async void AddToDictionary()
        {
            string keyPrefix = $"Entry{counter}"; // Unique key prefix for each set of values

            // Retrieve data from UI elements
            string newProductName = txtProductName.Text;
            string productId = txtId.Text;
            int quantity = Convert.ToInt32(txtQuentity.Text);
            decimal itemPrice = Convert.ToDecimal(txtPrice.Text);
            decimal itemSellPrice = Convert.ToDecimal(txtSellPrice.Text);
            int batchnumber = Convert.ToInt32(txtBatchNumber.Text);
            List<ItemDetailsDTO> productList = new List<ItemDetailsDTO>();

            // Add data to the dictionary
            if (int.TryParse(productId, out int parsedProductId))
            {
                // Use parsedProductId as an integer
            }

            ProductName[parsedProductId] = newProductName;
            ProductId[batchnumber] = parsedProductId;
            Quntity[parsedProductId] = quantity;
            ItemPrice[parsedProductId] = itemPrice;
            ItemSellprice[parsedProductId] = itemSellPrice;

            HttpResponseMessage response1 = await _httpClient.GetAsync("https://localhost:7141/productitems");

            string responseData = await response1.Content.ReadAsStringAsync();

            decimal SellPrice;

            if (decimal.TryParse(txtSellPrice.Text, out SellPrice))
            {
                // The conversion was successful, and SellPrice now contains the decimal value.
            }

            int Id;

            if (int.TryParse(txtId.Text, out Id))
            {
                // The conversion was successful, and Id now contains the integer value.
            }

            List<ProductItemDTO> productStocks = JsonConvert.DeserializeObject<List<ProductItemDTO>>(responseData); // Your existing productStocks

            ProductItemDTO foundProductStock = productStocks.FirstOrDefault(ps => ps.ProductId == Id && ps.Price == SellPrice);
            if (foundProductStock != null)
            {
                foundProductId = foundProductStock.Id;
            }
            else
            {
                foundProductId = GenerateItemId();
            }



            ItemId[foundProductId] = parsedProductId;
            ItemCost[foundProductId] = itemPrice;
            ItemSellCost[foundProductId] = itemSellPrice;
            ItemQuntity[foundProductId] = quantity;
            ItemName[foundProductId] = newProductName;
            counter++;




        }


        public static int GenerateItemId()
        {
            // Generate a random integer for the ItemId
            return _random.Next();
        }

        public static int GeneratePurchaseId()
        {
            // Generate a random integer for the PurchaseId
            return _random.Next();
        }

        private async Task UpdateProductStockQuantity(List<int> existingProductIds, Dictionary<int, int> ItemId, Dictionary<int, decimal> ItemSellCost, Dictionary<int, int> ItemQuentity, Dictionary<int, string> ItemName)
        {
            using (HttpClient server = new HttpClient())
            {
                foreach (var productId in existingProductIds)
                {
                    string productName = ItemName[productId];
                    int quantity = ItemQuentity[productId];
                    decimal price = ItemSellCost[productId];
                    int prodId = ItemId[productId];
                    HttpResponseMessage response1 = await server.GetAsync($"https://localhost:7141/productitem/{productId}/?price={price}");

                    if (response1.IsSuccessStatusCode)
                    {
                        string content1 = await response1.Content.ReadAsStringAsync();
                        ProductItemDTO productStock = JsonConvert.DeserializeObject<ProductItemDTO>(content1);

                        decimal availableQuantity = productStock.StockQuantity + quantity;

                        ProductItemDTO formData = new ProductItemDTO
                        {
                            Id = productId,
                            ProductId = prodId,
                            ProductName = productName,
                            StockQuantity = availableQuantity,
                            Price = ItemSellCost[productId],

                        };

                        var jsonData = JsonConvert.SerializeObject(formData);
                        var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                        var response = await server.PutAsync($"https://localhost:7141/productitem", content);
                        // Handle the response if needed
                    }
                }
            }
        }




        private async Task CreateNewProducts(List<int> newProductIds, Dictionary<int, int> ItemId, Dictionary<int, decimal> ItemSellCost, Dictionary<int, int> ItemQuentity, Dictionary<int, string> ItemName)
        {
            using (HttpClient client = new HttpClient())
            {
                foreach (var productId in newProductIds)
                {
                    string productName = ItemName[productId];
                    int quantity = ItemQuentity[productId];
                    decimal price = ItemSellCost[productId];
                    int prodId = ItemId[productId];

                    ProductItemDTO formData = new ProductItemDTO
                    {
                        Id = productId,
                        ProductId = prodId,
                        ProductName = productName,
                        StockQuantity = quantity,
                        Price = ItemSellCost[productId],

                    };

                    var jsonData = JsonConvert.SerializeObject(formData);
                    var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                    try
                    {
                        HttpResponseMessage response = await client.PostAsync($"https://localhost:7141/productitem", content);

                        if (response.IsSuccessStatusCode)
                        {
                            // Handle success if needed
                        }
                        else
                        {
                            // Handle failure, log the error, or show an error message
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle exceptions, log the exception details
                    }
                }
            }
        }


        #endregion
        #region Using Items

        private async void ProductListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ProductListView.SelectedItems.Count > 0)
            {
                string selectedProduct = ProductListView.SelectedItems[0].Text;

                // Append the selected product to the textBox1.Text


                // Update the textBox3.Text with the retrieved ID


                HttpResponseMessage response1 = await _httpClient.GetAsync("https://localhost:7141/productitems");

                string responseData = await response1.Content.ReadAsStringAsync();

                List<ProductItemDTO> productStocks = JsonConvert.DeserializeObject<List<ProductItemDTO>>(responseData); // Your existing productStocks

                txtProductName.Text = selectedProduct;



                int productId = Product.FirstOrDefault(x => x.Value.Equals(selectedProduct, StringComparison.OrdinalIgnoreCase)).Key;
                txtId.Text = productId.ToString();

            }
        }



        private async void btnsubmit_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtBatchNumber.Text))
            {
                MessageBox.Show("Please enter a valid batch number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validate Supplier ID
            if (!int.TryParse(txtSupplierId.Text, out _))
            {
                MessageBox.Show("Please enter a valid numeric supplier ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validate Total Amount
            if (!decimal.TryParse(txtTotalAmount.Text, out _))
            {
                MessageBox.Show("Please enter a valid numeric total amount.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check if Supplier ID is a string
            if (txtSupplierId.Text.Any(char.IsLetter))
            {
                MessageBox.Show("Supplier ID cannot contain letters. Please enter a valid numeric supplier ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check if Total Amount is a string
            if (txtTotalAmount.Text.Any(char.IsLetter))
            {
                MessageBox.Show("Total Amount cannot contain letters. Please enter a valid numeric total amount.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }



            string batchNumber = txtBatchNumber.Text;
            DateTime purchaseDate = purchaseDateTimePicker.Value;
            string customerId = txtSupplierId.Text;
            decimal totalAmount = Convert.ToDecimal(txtTotalAmount.Text);
            int newPurchaseId = GeneratePurchaseId();

            PurchaseDetailsDTO purchaseDetails = new PurchaseDetailsDTO
            {
                PurchaseId = newPurchaseId,
                BatchNumber = Convert.ToInt32(batchNumber),
                PurchaseDate = purchaseDate,
                CustomerId = Convert.ToInt32(customerId),
                TotalAmount = totalAmount,
                Items = new List<ItemDetailsDTO>()
            };

            foreach (var productId in ProductName)
            {
                int newItemId = GenerateItemId();

                ItemDetailsDTO itemDetails = new ItemDetailsDTO
                {
                    ItemId = newItemId,
                    PurchaseId = newPurchaseId,
                    ProductId = productId.Key,
                    ItemPrice = ItemPrice[productId.Key],
                    ItemSellPrice = ItemSellprice[productId.Key],
                    ProductName = productId.Value,
                    Quantity = Quntity[productId.Key],
                };
                NewproductName = ProductName[productId.Key];
                purchaseDetails.Items.Add(itemDetails);
                quentity = availableQuantity + Quntity[productId.Key];


            }

            HttpClient client = new HttpClient();
            string jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(purchaseDetails);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            try
            {
                HttpResponseMessage response = await client.PostAsync("https://localhost:7141/purchases", content);

                // Check if the request was successful
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Purchase added!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtBatchNumber.Clear();
                    purchaseDateTimePicker.Value = DateTime.Now; // Set it to the current date and time or any default value
                    txtSupplierId.Clear();
                    txtTotalAmount.Clear();


                }
                else
                {
                    MessageBox.Show("Error adding data. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding data. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                client.Dispose(); // Dispose the HttpClient
            }

            //HttpResponseMessage response1 = await _httpClient.GetAsync("https://localhost:7141/productstocks");
            HttpResponseMessage response1 = await _httpClient.GetAsync("https://localhost:7141/productitems");


            string responseData = await response1.Content.ReadAsStringAsync();
            //List<ProductStock> productStocks = JsonConvert.DeserializeObject<List<ProductStock>>(responseData);
            List<ProductItemDTO> productStocks = JsonConvert.DeserializeObject<List<ProductItemDTO>>(responseData);




            // Extract the list of product IDs from ProductName dictionary
            List<int> productIds = ItemId.Keys.ToList();

            // Check for existing products in productStocks list
            List<int> existingProductIds = productStocks.Select(p => p.Id).Intersect(productIds).ToList();

            // Get the new products that are not in the productStocks list
            List<int> newProductIds = productIds.Except(existingProductIds).ToList();

            // Update quantities for existing products
            await UpdateProductStockQuantity(existingProductIds, ItemId, ItemSellCost, ItemQuntity, ItemName);

            // Create new products
            await CreateNewProducts(newProductIds, ItemId, ItemSellCost, ItemQuntity, ItemName);


        }


        private void txtProductName_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtProductName.Text;

            if (string.IsNullOrWhiteSpace(searchText))
            {
                // Hide the suggestions when the search bar is empty
                return;
            }

            var filteredProducts = productCosts.Keys
             .Where(p => p.ToLower().Contains(searchText.ToLower()))
             .ToList();

            // Clear the existing items in the ListView
            ProductListView.Items.Clear();

            // Add each item to the ListView
            foreach (var product in filteredProducts)
            {
                ProductListView.Items.Add(product);
            }

            // Show the suggestions list only when there are matching items

        }



        private void btnAdd_Click(object sender, EventArgs e)
        {

            // Validate Product Name
            if (string.IsNullOrWhiteSpace(txtProductName.Text))
            {
                MessageBox.Show("Please select a valid product name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validate Item Price
            if (!decimal.TryParse(txtPrice.Text, out _))
            {
                MessageBox.Show("Please enter a valid numeric item price.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validate Item Sell Price
            if (!decimal.TryParse(txtSellPrice.Text, out _))
            {
                MessageBox.Show("Please enter a valid numeric item sell price.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validate Quantity
            if (!int.TryParse(txtQuentity.Text, out _))
            {
                MessageBox.Show("Please enter a valid numeric quantity.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }



            string data1 = txtProductName.Text;
            string data2 = txtId.Text;
            string data3 = txtPrice.Text;
            string data4 = txtSellPrice.Text;
            string data5 = txtQuentity.Text;

            AddToDictionary();


            // Add a new row to the DataGridView
            itemDataGridView.Rows.Add(data1, data2, data3, data4, data5);

            // Optionally, clear the text in the textboxes after adding the data
            txtProductName.Clear();
            txtId.Clear();
            txtPrice.Clear();
            txtSellPrice.Clear();
            txtQuentity.Clear();
            ProductListView.Items.Clear();


        }


        private void PurchaseDateTimePicker_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtSuplierId_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtTotalAmount_TextChanged(object sender, EventArgs e)
        {

        }

        private void lbHeadding_Click(object sender, EventArgs e)
        {

        }

        private void lbPurchaseDate_Click(object sender, EventArgs e)
        {

        }

        private void lbSupplierId_Click(object sender, EventArgs e)
        {

        }

        private void lbTotalAmount_Click(object sender, EventArgs e)
        {

        }

        private void lbProductName_Click(object sender, EventArgs e)
        {

        }

        private void lbItemPrice_Click(object sender, EventArgs e)
        {

        }

        private void txtProductId_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtItemPrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtItemSellPrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtQuentity_TextChanged(object sender, EventArgs e)
        {

        }

        private void lbIItemSellPriceClick(object sender, EventArgs e)
        {

        }

        private void lbQuentity_Click(object sender, EventArgs e)
        {

        }

        private void frmAddPurchase_Load(object sender, EventArgs e)
        {

        }

        private void lbProductId_Click(object sender, System.EventArgs e)
        {

        }

        private void txtBatchNumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void productsDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        } 
        #endregion
    }
}