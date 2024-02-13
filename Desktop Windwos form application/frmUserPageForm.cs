#region Using Directives

using Desktop_application;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

#endregion
namespace Desktop_Windwos_form_application
{
    public partial class frmUserPageForm : Form
    {
        #region Using Variable
        string UsernameOfTheLogingPersom = "";
        private HttpClient client = new HttpClient();
        private static decimal totalCostPrice = 0;
        private List<int> ItemsId = new List<int>(); // List to store added items
        private Dictionary<int, decimal> itemIdCounts = new Dictionary<int,decimal>(); // Dictionary to store item counts

        private List<string> dailyOrders = new List<string>(); // Define a list to store daily orders
        private Dictionary<string, decimal> productCosts = new Dictionary<string, decimal> { };
        private Dictionary<int, decimal> Cost = new Dictionary<int, decimal> { };
        private Dictionary<int, decimal> Price = new Dictionary<int, decimal> { };


        private Dictionary<int, string> ItemSellprice = new Dictionary<int, string> { };

        private Dictionary<string, int> productIds = new Dictionary<string, int> { };
        private Dictionary<int, int> productItemIds = new Dictionary<int, int> { };

        private Dictionary<int, List<Discount>> productDiscounts = new Dictionary<int, List<Discount>>();
        private Dictionary<string, decimal> productPromotion = new Dictionary<string, decimal>();
        private static decimal Cash = 0;
        string loyaltyCardNumber = "";
        int previousstartPoint = 0;
        int bankId = 0;
        private Dictionary<string, int> bankDictionary = new Dictionary<string, int>();
        public string productName = "";
        public decimal availableQuantity = 0;
        public string name;
        public static string TmpName = "";
        public static string TmpHtmlName = "";
        public int orderNumber = 0;
        public string Email;
        #endregion
        #region Using Constructor
        public frmUserPageForm(string username)
        {
            name = username;
            InitializeComponent();
            UsernameOfTheLogingPersom = username;
            FetchItemPrices();
            FetchProducts();
            FetchBankNames();
            dataGridView1.CellContentClick += dataGridView1_CellContentClick_2;
            btnDelete_Click();
            lbUserName.Text = username;

            // Load the icon image
            Bitmap icon = new Bitmap("C://Users/Chamindu/Downloads/icons8-search-50.png"); // Replace "icon.png" with the actual file path
            Bitmap iconLogOut = new Bitmap("C://Users/Chamindu/Downloads/icons8-logout-50.png"); // Replace "icon.png" with the actual file path
            Bitmap iconCalculator = new Bitmap("C://Users/Chamindu/Downloads/icons8-calculator-66.png"); // Replace "icon.png" with the actual file path


            int newWidth = 15; // Set your desired width
            int newHeight = 15; // Set your desired height
            Bitmap resizedIcon = new Bitmap(icon, new Size(newWidth, newHeight));
            Bitmap resizedIconLogout = new Bitmap(iconLogOut, new Size(newWidth, newHeight));
            Bitmap resizedCalculator = new Bitmap(iconCalculator, new Size(newWidth, newHeight));


            // Set the icon for the button
            btnAvalableProduct.Image = resizedIcon;
            btnBack.Image = resizedIconLogout;
            btCalculator.Image = resizedCalculator;

                   Timer timer = new Timer();
            timer.Interval = 1000; // Update every 1000 milliseconds (1 second)
            timer.Tick += (timerSender, timerArgs) =>
            {
                // Update the time label
                lblTime.Text = DateTime.Now.ToString("hh:mm:ss tt");
                lblDate.Text = DateTime.Now.ToString("yyyy-MM-dd");

            };

            // Start the timer
            timer.Start();
        }
        #endregion
        #region Using Items
        private void txtProduct_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtProduct.Text;

            if (string.IsNullOrWhiteSpace(searchText))
            {
                // Hide the suggestions when the search bar is empty
                lstProduct.Visible = false;
                return;
            }

            // Filter products based on the search text
            var filteredProducts = productCosts.Keys
                .Where(p => p.ToLower().Contains(searchText.ToLower()))
                .ToArray();

            // Show the suggestions list only when there are matching items
            lstProduct.Items.Clear();
            foreach (var product in filteredProducts)
            {
                lstProduct.Items.Add(product);
            }

            lstProduct.Visible = filteredProducts.Any();
        }







        private async void cmbLoyeltyCard_SelectedIndexChanged(object sender, EventArgs e)
        {

            string selectedPaymentMethod = cmbLoyeltyCard.SelectedItem?.ToString();





            if (selectedPaymentMethod == "Phone Number")
            {
                await DisplayAlertForUserData(false);

            }
            // Optionally, perform actions based on the selected payment method
            else if (selectedPaymentMethod == "Card Number")
            {
                await DisplayAlertForUserData(true);

            }
            else
            {

            }


        }










        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtQuentity.Text))
            {
                MessageBox.Show("Please enter a valid Quantity.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!decimal.TryParse(txtQuentity.Text, out _))
            {
                MessageBox.Show("Please enter a valid numeric Quantity.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (dataGridView1 == null)
            {
                // Create and configure the DataGridView if not already done
                dataGridView1 = new DataGridView();
                dataGridView1.Dock = DockStyle.Fill;

                // Add columns if needed
                dataGridView1.Columns.Add("ItemName", "Item Name");
                dataGridView1.Columns.Add("Quantity", "Quantity");
                dataGridView1.Columns.Add("UnitPrice", "Unit Price");
                dataGridView1.Columns.Add("TotalPrice", "Total Price");

                // Add the DataGridView to the form
                Controls.Add(dataGridView1);
            }

            // Get the selected product and its price
            string selectedProduct = txtProduct.Text;

            // Parse the quantity from textBox2.Text
            if (!decimal.TryParse(txtQuentity.Text, out decimal quantity))
            {
                // Handle invalid quantity input
                MessageBox.Show("Invalid Quentity. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            decimal quentity = 0;
            var selectedProductItemIds = ItemSellprice.Where(x => x.Value == selectedProduct).Select(x => x.Key).ToList();
            var selectedProductItemPrice = Cost.Where(x => selectedProductItemIds.Contains(x.Key)).Select(x => x.Value).ToList();
            int selectedItemId = 0;


            if (selectedProductItemIds.Count > 1)
            {
                var itemIdMap = selectedProductItemIds
                    .ToDictionary(itemId => $"Item ID: {itemId} - Price: {Cost[itemId]}", itemId => itemId);

                using (var itemSelectionForm = new frmItemSelectionForm(itemIdMap))
                {
                    var result = itemSelectionForm.ShowDialog();

                    if (result == DialogResult.OK && !string.IsNullOrEmpty(itemSelectionForm.SelectedItem))
                    {
                        string selectedItemString = itemSelectionForm.SelectedItem;
                        if (itemIdMap.TryGetValue(selectedItemString, out int selectedItem))
                        {
                            selectedItemId = selectedItem;
                            if (Cost.TryGetValue(selectedItemId, out decimal selectedUnitPrice))
                            {
                                // Update the DataGridView with the selected item
                                if (!decimal.TryParse(txtQuentity.Text, out decimal count) || count <= 0)
                                {
                                    // Handle invalid input
                                    return;
                                }
                                if (!productIds.TryGetValue(selectedProduct, out int productId))
                                {
                                    // Handle product not found
                                    return;
                                }
                                bool isAvailable = await IsQuantityAvailable(productId, selectedItemId, count);

                                if (!isAvailable)
                                {
                                    // Handle case where quantity is not available
                                    MessageBox.Show("Sorry, the selected product quantity is not available.", "Quantity Unavailable", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);

                                    // Display a message to the user or take appropriate action
                                    return;
                                }



                                if (isAvailable)
                                {
                                    quentity = availableQuantity - count;

                                    await UpdateProductStockQuantity(productId, selectedItemId, quentity, productName);
                                    UpdateDataGridView(selectedProduct, quantity, selectedUnitPrice, selectedItemId);

                                }

                                if (ItemsId.Contains(selectedItemId))
                                {
                                    // If the item already exists, just increment its count
                                    itemIdCounts[selectedItemId] += count;
                                }
                                else
                                {
                                    // If the item doesn't exist, add it to the lists and dictionaries at the top
                                    ItemsId.Insert(0, selectedItemId);
                                    itemIdCounts[selectedItemId] = count;

                                }


                            }
                        }
                        else
                        {
                            MessageBox.Show("Product Not Found. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Canceled. Product selection canceled.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        return;
                    }
                }
            }
            else if (selectedProductItemIds.Count == 1)
            {
                selectedItemId = selectedProductItemIds[0];

                if (Cost.TryGetValue(selectedItemId, out decimal selectedUnitPrice))
                {
                    // Update the DataGridView with the selected item
                    if (!decimal.TryParse(txtQuentity.Text, out decimal count) || count <= 0)
                    {
                        // Handle invalid input
                        return;
                    }
                    if (!productIds.TryGetValue(selectedProduct, out int productId))
                    {
                        // Handle product not found
                        return;
                    }
                    bool isAvailable = await IsQuantityAvailable(productId, selectedItemId, count);

                    if (!isAvailable)
                    {
                        // Handle case where quantity is not available
                        MessageBox.Show("Sorry, the selected product quantity is not available.", "Quantity Unavailable", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);

                        // Display a message to the user or take appropriate action
                        return;
                    }



                    if (isAvailable)
                    {
                        quentity = availableQuantity - count;

                        await UpdateProductStockQuantity(productId, selectedItemId, quentity, productName);
                        UpdateDataGridView(selectedProduct, quantity, selectedUnitPrice, selectedItemId);

                    }

                    if (ItemsId.Contains(selectedItemId))
                    {
                        // If the item already exists, just increment its count
                        itemIdCounts[selectedItemId] += quantity;
                    }
                    else
                    {
                        // If the item doesn't exist, add it to the lists and dictionaries at the top
                        ItemsId.Insert(0, selectedItemId);
                        itemIdCounts[selectedItemId] = quantity;

                    }

                }

            }
            else
            {
                // Handle case where no items were found
                MessageBox.Show("Error.No Items found! .", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Fetch the unit price from productCosts dictionary



          
            UpdateTotalCost();

            txtProduct.Clear();
            txtQuentity.Clear();
        }






        private void UpdateDataGridView(string selectedProduct, decimal quantity, decimal unitPrice,int selectedItemId)
        {
            // Check if the item already exists in the DataGridView
            DataGridViewRow existingRow = null;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["ItemName"].Value != null && row.Cells["ItemName"].Value.ToString() == selectedProduct)
                {
                    existingRow = row;
                    break;
                }
            }

            if (existingRow != null)
            {
                // Item already exists, update quantity and total price
                decimal existingQuantity = Convert.ToInt32(existingRow.Cells["Quantity"].Value);
                decimal existingTotalPrice = Convert.ToDecimal(existingRow.Cells["TotalPrice"].Value);

                existingQuantity += quantity;
                existingTotalPrice += quantity * unitPrice;

                existingRow.Cells["Quantity"].Value = existingQuantity;
                existingRow.Cells["TotalPrice"].Value = existingTotalPrice;
            }
            else
            {
                // Item doesn't exist, add a new row
                Item existingItem = itemList.FirstOrDefault(item => item.ItemName == selectedProduct);

                if (existingItem != null)
                {
                    // Item already exists, update quantity
                    existingItem.Quantity += quantity;
                }
                else
                {
                    // Item doesn't exist, add a new item
                    itemList.Add(new Item
                    {
                        Itemnumber = selectedItemId,
                        ItemName = selectedProduct,
                        Quantity = quantity,
                        UnitPrice = unitPrice
                    });
                }

                var bindingList = new BindingList<Item>(itemList);
                var source = new BindingSource(bindingList, null);
                bindingSource1.DataSource = source;
                ProductDataGrid.DataSource = this.bindingSource1;


                ProductDataGrid.Columns["ItemName"].Width = 200; 
                ProductDataGrid.Columns["Quantity"].Width = 120;   // Set the width of the Quantity column
                ProductDataGrid.Columns["UnitPrice"].Width = 150;  // Set the width of the UnitPrice column
                ProductDataGrid.Columns["TotalPrice"].Width = 170;


                ProductDataGrid.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold); // Set the font for column headers


                ProductDataGrid.Columns["ItemName"].DefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Regular); // Set the font for the ItemName column
                ProductDataGrid.Columns["Quantity"].DefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Regular);  // Set the font for the Quantity column
                ProductDataGrid.Columns["UnitPrice"].DefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Regular); // Set the font for the UnitPrice column
                ProductDataGrid.Columns["TotalPrice"].DefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Regular); // Set the font for the TotalPrice column


               

            }

        }

        private BindingList<Item> itemList = new BindingList<Item>();

        public class Item
        {
            public int Itemnumber { get; set; }
            public string ItemName { get; set; }
            public decimal Quantity { get; set; }
            public decimal UnitPrice { get; set; }
            public decimal TotalPrice => Quantity * UnitPrice;
        }







        private async void cmbPaymentMethode_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedBankName = cmbPaymentMethode.SelectedItem?.ToString();
            await FetchPromotion();
            string selectedPaymentMethod = cmbPaymnttype.SelectedItem?.ToString();

            if (selectedPaymentMethod != null && selectedPaymentMethod.Equals("Cash"))
            {
                if (selectedBankName.Equals("ALL"))
                {
                    // Handle the case when "ALL" is selected in comboBox1
                    // Perform actions specific to "ALL" selection
                    Console.WriteLine("ALL selected in comboBox1");
                }
            }

            // Optionally, you can use the selected bank name to get the corresponding bank ID from the dictionary
            if (selectedBankName != null && bankDictionary.TryGetValue(selectedBankName, out int selectedBankId))
            {
                // Use the selected bank ID as needed
                Console.WriteLine($"Selected Bank ID: {selectedBankId}");
            }
        }

        private void cmdPaymentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Clear the existing items in comboBox2



            // Now you can handle the selected payment method based on comboBox2.SelectedItem
            string selectedPaymentMethod = cmbPaymnttype.SelectedItem?.ToString();

            // Optionally, perform actions based on the selected payment method
            switch (selectedPaymentMethod)
            {
                case "Cash":
                    // Handle cash payment
                    break;

                case "Card":
                    // Handle card payment
                    break;

                // Add more cases for additional payment methods if needed

                default:
                    // Handle the default case or do nothing
                    break;
            }
        }

        private void toolStrip1_ItemClicked_1(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void lblTime_Click(object sender, EventArgs e)
        {

        }

        private void lbUserName_Click(object sender, EventArgs e)
        {

        }

        private void lbLoyeltyCard_Click(object sender, EventArgs e)
        {

        }

        private void txtAmount_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtExtraForloyelty_TextChanged(object sender, EventArgs e)
        {

        }

        private async void btnConform_Click(object sender, EventArgs e)
        {
            string paymentMethod = cmbPaymentMethode.SelectedItem as string;
            string selectedPaymentMethod = cmbPaymnttype.SelectedItem?.ToString();
            string loyeltyCard = cmbLoyeltyCard.SelectedItem?.ToString();


            if (selectedPaymentMethod == "Cash")
            {
                cmbPaymentMethode.SelectedItem = "ALL";

                lbCardNumber.Visible = false;
                txtCardNumber.Visible = false;
                txtAmount.Visible = true;
                lbAmount.Visible = true;
            }
            else if (selectedPaymentMethod == "Card")
            {
                txtAmount.Visible = false;
                lbAmount.Visible = false;
                lbCardNumber.Visible = true;
                txtCardNumber.Visible = true;

            }

            if (loyeltyCard == "No")
            {
                lbExtraForCard.Visible = false;
                txtExtraForCard.Visible = false;

            }
            else
            {
                lbExtraForCard.Visible = true;
                txtExtraForCard.Visible = true;
                await UpdateStarPoints();


            }

            await FetchDiscounts(paymentMethod);
            UpdateTotalCost();


        }

        private async void btnCheackOut_Click(object sender, EventArgs e)
        {

            
             
            orderNumber = GenerateOrderId();
            PlaceOrder(orderNumber);
            txtExtraForCard.Text = "";
            Cash = 0;
            ItemsId.Clear();
            txtCardNumber.Text = "";
            totalCostLabel.Clear();
            ProductDataGrid.Rows.Clear();
            txtProduct.Clear();
            txtQuentity.Clear();
            cmbLoyeltyCard.SelectedItem = "No";
            cmbPaymnttype.SelectedIndex = 0;
            cmbPaymentMethode.SelectedIndex = 0;



        }




        private async void btnDelete_Click()
        {
            DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn();
            deleteButtonColumn.Name = "Delete";
            deleteButtonColumn.Text = "Delete";
            deleteButtonColumn.UseColumnTextForButtonValue = true;
            ProductDataGrid.Columns.Add(deleteButtonColumn);
        }



        private async void dataGridView1_CellContentClick_2(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the clicked cell is in a valid range (avoiding header clicks)
            if (e.RowIndex >= 0 && e.ColumnIndex == ProductDataGrid.Columns["Delete"].Index)
            {
                // Prompt the user for username and password
                string enteredUsername = PromptForInput("Enter Username:");
                string enteredPassword = PromptForInput("Enter Password:", true); // Use true for password input

                HttpResponseMessage response = await client.PostAsync($"https://localhost:7141/Users/{enteredUsername}/{enteredPassword}", null);



                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    Dictionary<string, string> userData = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonResponse);
                    int logging = 1;
                    string userType;
                    if (userData.TryGetValue("type", out userType))
                    {
                        if (userType == "user")
                        {

                            // Navigate to UserPage
                            MessageBox.Show("Canceled. Invalid credentials. Unable to delete data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                        else if (userType == "admin")
                        {
                            dataGridView1.Rows.RemoveAt(e.RowIndex);
                            MessageBox.Show("Data deleted successfully!");
                        }
                    }
                }
            }
        }




        private void lstProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstProduct.SelectedItems.Count > 0)
            {
                string selectedProduct = lstProduct.SelectedItems[0].Text;

                // Append the selected product to the textBox1.Text
                txtProduct.Text = selectedProduct;

                // Hide the suggestions list after selecting a suggestion
                lstProduct.Visible = false;
            }
        }

        private void totalCostLabel_TextChanged(object sender, EventArgs e)
        {

        }

        private void lbTotal_Click(object sender, EventArgs e)
        {

        }

        private void txtCardNumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void lbProduct_Click(object sender, EventArgs e)
        {

        }

        private void lbExtraForCard_Click(object sender, EventArgs e)
        {

        }

        private void lbAmount_Click(object sender, EventArgs e)
        {

        }

        private void lbCardNumber_Click(object sender, EventArgs e)
        {

        }

        private void UserPageForm_Load(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            frmLogin loggingPage = new frmLogin();
            loggingPage.Show();
            this.Hide();
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            frmAddCustermer addCustermer = new frmAddCustermer();
            addCustermer.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void btnAvalableProducts_Click_1(object sender, EventArgs e)
        {
            frmAvalableProduct avalableProduct = new frmAvalableProduct();
            avalableProduct.Show();
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private async void ProductDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the clicked cell is in a valid range (avoiding header clicks)
            if (e.RowIndex >= 0 && e.ColumnIndex == ProductDataGrid.Columns["Delete"].Index)
            {
                // Prompt the user for username and password
                string enteredUsername = PromptForInput("Enter Username:");
                string enteredPassword = PromptForInput("Enter Password:", true); // Use true for password input

                HttpResponseMessage response = await client.PostAsync($"https://localhost:7141/Users/{enteredUsername}/{enteredPassword}", null);



                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    Dictionary<string, string> userData = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonResponse);
                    int logging = 1;
                    string userType;
                    if (userData.TryGetValue("type", out userType))
                    {
                        if (userType == "user")
                        {

                            // Navigate to UserPage
                            MessageBox.Show("Canceled. Invalid credentials. Unable to delete data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                        else if (userType == "admin")
                        {
                            DataGridViewRow selectedRow = ProductDataGrid.Rows[e.RowIndex];
                            decimal selectedPrice = Convert.ToDecimal(selectedRow.Cells[4].Value);
                            int itemId = Convert.ToInt32(selectedRow.Cells[1].Value);
                            int selectedItemId = itemId;
                            if (itemIdCounts.ContainsKey(selectedItemId))
                            {
                                itemIdCounts.Remove(selectedItemId);
                            }
                            Console.WriteLine(itemId);
                            totalCostLabel.Text = (totalCostPrice - selectedPrice).ToString();
                            ProductDataGrid.Rows.RemoveAt(e.RowIndex);
                            MessageBox.Show("Data deleted successfully!");
                        }
                    }
                }
            }
        }

        private void lbQuentity_Click(object sender, EventArgs e)
        {

        }

        private void lbPaymentType_Click(object sender, EventArgs e)
        {

        }

        private void lbpaymentMethode_Click(object sender, EventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btCalculator_Click(object sender, EventArgs e)
        {
            frmCalculatorForm calculatorForm = new frmCalculatorForm();
            calculatorForm.ShowDialog();

        }

        #endregion
        #region Using Method
        private string PromptForInput(string prompt, bool isPassword = false)
        {
            Form promptForm = new Form();
            promptForm.Width = 300;
            promptForm.Height = 150;
            promptForm.Text = prompt;

            TextBox textBox = new TextBox() { Left = 50, Top = 20, Width = 200 };
            if (isPassword)
            {
                textBox.PasswordChar = '*';
            }

            Button okButton = new Button() { Text = "OK", Left = 50, Top = 50 };
            okButton.Click += (sender, e) => { promptForm.Close(); };

            promptForm.Controls.Add(textBox);
            promptForm.Controls.Add(okButton);

            promptForm.ShowDialog();

            return textBox.Text;
        }

        private async Task FetchDiscounts(string paymentMethode)
        {
            try
            {
                HttpResponseMessage discountResponse = await client.GetAsync("https://localhost:7141/discounts");

                if (discountResponse.IsSuccessStatusCode)
                {
                    string discountContent = await discountResponse.Content.ReadAsStringAsync();
                    var discounts = JsonConvert.DeserializeObject<List<Discount>>(discountContent);

                    foreach (var discount in discounts)
                    {
                        if (!productDiscounts.ContainsKey(discount.ProductId))
                        {
                            productDiscounts[discount.ProductId] = new List<Discount>();
                        }

                        if (DateTime.Now >= discount.StartDate && DateTime.Now <= discount.EndDate && discount.IsValid && paymentMethode == discount.PaymentMethod)
                        {
                            productDiscounts[discount.ProductId].Add(discount);
                        }
                        else if (DateTime.Now >= discount.StartDate && DateTime.Now <= discount.EndDate && discount.IsValid && discount.PaymentMethod == "ALL")
                        {
                            productDiscounts[discount.ProductId].Add(discount);

                        }
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
        private async Task FetchPromotion()
        {
            try
            {
                string paymentMethod = cmbPaymentMethode.SelectedItem as string;

                if (string.IsNullOrEmpty(paymentMethod))
                {
                    // Handle the case where no payment method is selected
                    return;
                }

                HttpResponseMessage discountResponse = await client.GetAsync("https://localhost:7141/promotions");

                if (discountResponse.IsSuccessStatusCode)
                {
                    string discountContent = await discountResponse.Content.ReadAsStringAsync();
                    var promotions = JsonConvert.DeserializeObject<List<PromotionDTO>>(discountContent);

                    foreach (var promotion in promotions)
                    {
                        if (DateTime.Now >= promotion.StartDate && DateTime.Now <= promotion.EndDate)
                        {
                            if (promotion.IsValid && promotion.PayMethod == paymentMethod)
                            {
                                productPromotion[promotion.PayMethod] = promotion.DiscountNumber;

                                return;
                            }
                        }
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



        private async Task SendOrderToApi(OrderDTO order)
        {
            try
            {
                string apiUrl = "https://localhost:7141/api/orders";
                string jsonOrder = JsonConvert.SerializeObject(order);
                HttpContent content = new StringContent(jsonOrder, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(apiUrl, content);
                orderNumber = GenerateOrderId();

                string summary = $"Order Number: {orderNumber}\nUser: {name}\nItems:\n";

                decimal itemPrice = 0;

                if (response.IsSuccessStatusCode)
                {
                    foreach (var item in itemIdCounts)
                    {
                        int itemId = item.Key;
                        itemPrice = CalculateItemPrice(item.Key, item.Value);
                        summary += $"  {ItemSellprice[item.Key]}     Quantity: {item.Value},    Price: ${itemPrice}\n";
                        Price[itemId] = itemPrice;
                    }

                    decimal cash;

                    if (decimal.TryParse(txtAmount.Text, out cash))
                    {
                        Cash = cash;
                    }
                    name = UsernameOfTheLogingPersom;

                    decimal priceOf;

                    if (decimal.TryParse(totalCostLabel.Text, out priceOf))
                    {
                        priceOf = totalCostPrice;
                    }
                    if (Cash == 0)
                    {
                        Cash = totalCostPrice;
                    }



                    decimal price;

                    if (decimal.TryParse(totalCostLabel.Text, out price))
                    {

                    }

                    decimal balance = Cash - totalCostPrice;
                    await GetTemplate();
                    await GetHtmlemplate();
                    MessageBox.Show($"Blance: {balance}", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    txtAmount.Clear();
                    string toMail = Email;
                    Email = "";
                    SimpleFontResolver.GenerateAndDownloadPdf(toMail, name, itemIdCounts, totalCostPrice, Cost, Price, itemPrice, Cash, orderNumber, ItemSellprice, TmpName, TmpHtmlName);
                    MessageBox.Show("Succes, product submit.", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                    itemIdCounts.Clear();




                    dailyOrders.Add(summary);



                }
                else
                {
                    MessageBox.Show("Error, product submit error.", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);


                }
            }
            catch (Exception ex)
            {
            }
        }

        private async void PlaceOrder(int orderNumber)
        {
            int cardNumber = 0;
            string selectedPaymentType = cmbPaymentMethode.SelectedItem as string;

            int selectedBankId = 0; // Default bank ID

            if (selectedPaymentType != null && bankDictionary.TryGetValue(selectedPaymentType, out int bankIdFromDictionary))
            {
                selectedBankId = bankIdFromDictionary;
            }

            // Access the text entered in the LoyaltyCard Entry field and try to parse it into an integer
            if (int.TryParse(txtCardNumber.Text, out cardNumber))
            {
                decimal promo = 0;
                foreach (var promotion in productPromotion)
                {
                    int itemId = GenerateItemId();

                    promo = promotion.Value;
                }

                OrderDTO newOrder = new OrderDTO
                {
                    OrderId = orderNumber, // Generate a unique order ID
                    OrderDate = DateTime.UtcNow,
                    TotalAmount = totalCostPrice,
                    username = name,
                    Discount = promo, // Apply the total discount to the entire order
                    CardNumber = cardNumber,
                    BankId = selectedBankId, // Assign the selected bank ID or the default bank ID
                    Items = new List<OrderItemDTO>()
                };

                foreach (var item in itemIdCounts)
                {
                    int itemId = GenerateItemId();

                    if (productItemIds.ContainsKey(item.Key))
                    {
                        int productId = productItemIds[item.Key]; // Get the product ID

                        OrderItemDTO orderItem = new OrderItemDTO
                        {
                            ItemId = item.Key + itemId, // Generate a unique item ID
                            OrderId = newOrder.OrderId,
                            ProductName = ItemSellprice[item.Key],
                            Quantity = item.Value,
                            Price = Cost[item.Key],
                            Discount = productDiscounts.ContainsKey(productId) ? CalculateItemDiscount(productId, item.Value) : 0,
                            product_id = productItemIds[item.Key].ToString()
                        };
                        itemId++;

                        newOrder.Items.Add(orderItem);
                    }
                }

                await SendOrderToApi(newOrder);
            }
            else
            {
                decimal promo = 0;
                foreach (var promotion in productPromotion)
                {
                    promo = promotion.Value;
                }

                OrderDTO newOrder = new OrderDTO
                {
                    OrderId = orderNumber, // Generate a unique order ID
                    OrderDate = DateTime.UtcNow,
                    TotalAmount = totalCostPrice,
                    username = name,
                    Discount = promo, // Apply the total discount to the entire order
                    CardNumber = cardNumber,
                    BankId = selectedBankId, // Assign the selected bank ID or the default bank ID
                    Items = new List<OrderItemDTO>()
                };

                foreach (var item in itemIdCounts)
                {
                    int itemId = GenerateItemId();

                    if (productItemIds.ContainsKey(item.Key))
                    {
                        int productId = productItemIds[item.Key]; // Get the product ID

                        OrderItemDTO orderItem = new OrderItemDTO
                        {
                            ItemId = item.Key + itemId, // Generate a unique item ID
                            OrderId = newOrder.OrderId,
                            ProductName = ItemSellprice[item.Key],
                            Quantity = item.Value,
                            Price = Cost[item.Key],
                            Discount = productDiscounts.ContainsKey(productId) ? CalculateItemDiscount(productId, item.Value) : 0,
                            product_id = productItemIds[item.Key].ToString()
                        };
                        itemId++;

                        newOrder.Items.Add(orderItem);
                    }
                }
                await SendOrderToApi(newOrder);
            }
        }

        private decimal CalculateItemDiscount(int productId, decimal quantity)
        {
            decimal itemDiscount = 0;

            if (productDiscounts.ContainsKey(productId))
            {
                // Calculate the total discount for the item based on the quantity and applicable discounts
                foreach (var discount in productDiscounts[productId])
                {
                    itemDiscount += (discount.DiscountNumber * quantity);
                }
            }

            return itemDiscount;
        }


        private int GenerateOrderId()
        {


            int randomPart = new Random().Next(1000, 9999);

            // Get the current date formatted as an integer (yyyyMMdd)
            int currentDateInt = int.Parse(DateTime.Now.ToString("MMdd"));

            // Create the combined code by appending the date with the sequence number
            int combinedCode = int.Parse($"{currentDateInt}{randomPart}");

            // Increment the order sequence for the next order

            return combinedCode;
        }


        private int GenerateItemId()
        {
            // Your logic to generate a unique item ID
            DateTime now = DateTime.UtcNow;
            long timestamp = now.Ticks / TimeSpan.TicksPerMillisecond;

            // Convert the timestamp to an int (you may need to handle potential overflow or adjust as needed)
            int itemId = (int)(timestamp % int.MaxValue);

            return itemId;
        }


        private static async Task GetTemplate()
        {

            var httpClient = new HttpClient();

            try
            {
                HttpResponseMessage response = await httpClient.GetAsync("https://localhost:7141/htmltemplates/Kiwi%20Suit%20Template");

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    var products = JsonConvert.DeserializeObject<HtmlTemplate>(content);
                    string Htmltemplate = products.html_content;
                    TmpName = Htmltemplate;


                }
                else
                {
                    Console.WriteLine($"Failed to fetch data. Status code: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }



        private static async Task GetHtmlemplate()
        {

            var httpClient = new HttpClient();

            try
            {
                HttpResponseMessage response = await httpClient.GetAsync("https://localhost:7141/htmltemplates/Kiwi%20Suit%20Email%20Template");

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    var products = JsonConvert.DeserializeObject<HtmlTemplate>(content);
                    string Htmltemplate = products.html_content;
                    TmpHtmlName = Htmltemplate;


                }
                else
                {
                    Console.WriteLine($"Failed to fetch data. Status code: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }



        private void UpdateTotalCost()
        {
            decimal totalCost = 0; // Reset the total cost

            foreach (var item in itemIdCounts)
            {
                // Calculate the total cost for each item considering the quantity and unit price
                decimal itemTotalPrice = CalculateItemPrice(item.Key, item.Value);
                totalCost += itemTotalPrice;
            }

            // Apply promotions to the total cost
            foreach (var promotion in productPromotion)
            {
                // Assuming productPromotion is a Dictionary<string, decimal> where the key is the payment method and the value is the discount
                if ((promotion.Key == cmbPaymentMethode.SelectedItem as string))
                {
                    decimal discount = promotion.Value;
                    totalCost -= (totalCost * discount / 100); // Deduct the discount from the total cost

                }
                else if (promotion.Key == "loyalty card")
                {
                    decimal discount = promotion.Value;
                    totalCost -= (totalCost * discount / 100); // Deduct the loyalty card discount from the total cost
                }
            }

            decimal totalAmount = 0;

          



            totalCostPrice = totalCost;
            totalCost = 0;
            totalCostLabel.Text = totalCostPrice.ToString();
        }

        private decimal CalculateItemPrice(int itemName, decimal count)
        {
            if (!Cost.ContainsKey(itemName))
            {
                return 0; // If the product is not found, return 0
            }

            decimal itemTotalPrice = Cost[itemName] * count;

            if (productDiscounts.ContainsKey(productItemIds[itemName]))
            {
                // Get all discounts associated with the product ID
                var discounts = productDiscounts[productItemIds[itemName]];

                // Calculate the total discount for this item
                decimal totalDiscount = 0;
                foreach (var discount in discounts)
                {
                    decimal discountValue = discount.DiscountNumber / 100;
                    totalDiscount += itemTotalPrice * discountValue;
                }

                decimal discountedTotalPrice = itemTotalPrice - totalDiscount;

                return discountedTotalPrice;
            }

            return itemTotalPrice;
        }


        private async Task<bool> IsQuantityAvailable(int productId, int selectedId, decimal requestedQuantity)
        {

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response1 = await client.GetAsync("https://localhost:7141/productitems");

                    string responseData = await response1.Content.ReadAsStringAsync();

                    decimal SellPrice = Cost[selectedId];

                    int Id = productId;
                    int foundProductId = 0;
                    List<ProductItemDTO> productStocks = JsonConvert.DeserializeObject<List<ProductItemDTO>>(responseData); // Your existing productStocks

                    ProductItemDTO foundProductStock = productStocks.FirstOrDefault(ps => ps.ProductId == Id && ps.Price == SellPrice);
                    if (foundProductStock != null)
                    {
                        foundProductId = foundProductStock.Id;
                    }


                    HttpResponseMessage response = await client.GetAsync($"https://localhost:7141/productitem/{foundProductId}/?price={SellPrice}");

                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        // Deserialize the content to get product stock information
                        // Assuming ProductStockModel is your model representing the product stock details
                        ProductStockDTO productStock = JsonConvert.DeserializeObject<ProductStockDTO>(content);

                        // Check if the requested quantity is available
                        if (productStock != null && productStock.StockQuantity >= requestedQuantity)
                        {

                            productName = productStock.ProductName;
                            availableQuantity = productStock.StockQuantity;



                            return true;
                        }
                    }
                    // If the product doesn't exist or the quantity is insufficient
                    return false;
                }
                catch (Exception ex)
                {
                    // Handle exceptions (e.g., network issues, JSON parsing errors)
                    return false;
                }
            }
        }

        private async void FetchBankNames()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("https://localhost:7141/api/banks");

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    var bankObjects = JsonConvert.DeserializeObject<List<BankModelDTO>>(content);

                    // Extract bank names from bankObjects
                    var bankNames = bankObjects.Select(bank => bank.BankName).ToList();
                    // Bind the bank names to the Picker control
                    cmbPaymentMethode.DataSource = bankNames;
                    foreach (var bank in bankObjects)
                    {
                        bankDictionary[bank.BankName] = bank.BankId; // Assuming BankId is the property representing the ID
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

        private async Task UpdateProductStockQuantity(int productId, int selectid, decimal availableQuantity, string productName)
        {

            var client = new HttpClient();

            HttpResponseMessage response1 = await client.GetAsync("https://localhost:7141/productitems");

            string responseData = await response1.Content.ReadAsStringAsync();

            decimal SellPrice = Cost[selectid];

            int Id = productId;
            int foundProductId = 0;
            List<ProductItemDTO> productStocks = JsonConvert.DeserializeObject<List<ProductItemDTO>>(responseData); // Your existing productStocks

            ProductItemDTO foundProductStock = productStocks.FirstOrDefault(ps => ps.ProductId == Id && ps.Price == SellPrice);
            if (foundProductStock != null)
            {
                foundProductId = foundProductStock.Id;
            }

            ProductItemDTO formData = new ProductItemDTO
            {
                Id = foundProductId,
                ProductId = productId,
                ProductName = productName,
                StockQuantity = availableQuantity,
                Price = SellPrice,


            };

            // Convert the object to JSON
            var jsonData = JsonConvert.SerializeObject(formData);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"https://localhost:7141/productitem", content);
        }

        private async Task FetchItemPrices()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("https://localhost:7141/orderItems");

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    var orderItems = JsonConvert.DeserializeObject<List<ItemDetailsDTO>>(content);

                    foreach (var orderItem in orderItems)
                    {
                        // Assuming 'orderItem.ProductName' is the name and 'orderItem.Price' is the price
                        productCosts[orderItem.ProductName] = orderItem.ItemSellPrice;
                        ItemSellprice[orderItem.ItemId] = orderItem.ProductName;
                        Cost[orderItem.ItemId] = orderItem.ItemSellPrice;
                        productItemIds[orderItem.ItemId] = orderItem.ProductId;
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
        private async Task DisplayAlertForUserData(bool isLoyaltyCard)
        {
            string userInput = string.Empty;
            frmInputPromptForm prompt = new frmInputPromptForm();
            DialogResult result = prompt.ShowDialog();
            if (result == DialogResult.OK)
            {
                if (isLoyaltyCard)
                {
                    userInput = prompt.InputText;
                }
                else
                {
                    userInput = prompt.InputText;
                }
            }

            if (!string.IsNullOrWhiteSpace(userInput))
            {
                CustermerDTO userData = await FetchUserData(userInput, isLoyaltyCard);

                if (userData != null)
                {
                    Email = userData.Email;
                    string message = $"User Name: {userData.Name}\nStar Points: {userData.StarPoints} \nEmail:{userData.Email}";
                    DialogResult dialogResult = MessageBox.Show($"User Information: {message}", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                    if (dialogResult == DialogResult.OK)
                    {
                        // Perform actions when the user clicks OK
                        try
                        {
                            HttpResponseMessage promotionResponse = await client.GetAsync("https://localhost:7141/promotions");

                            if (promotionResponse.IsSuccessStatusCode)
                            {
                                string promotionContent = await promotionResponse.Content.ReadAsStringAsync();
                                var promotions = JsonConvert.DeserializeObject<List<PromotionDTO>>(promotionContent);

                                foreach (var promotion in promotions)
                                {
                                    if (promotion.PayMethod == "loyalty card")
                                    {
                                        // Add the loyalty card promotion to the product promotions dictionary
                                        productPromotion[promotion.PayMethod] = promotion.DiscountNumber;

                                        // Recalculate the total price considering the loyalty card promotion
                                        UpdateTotalCost();
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("User data not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        catch (Exception ex)
                        {
                        }
                    }
                }
                else
                {
                    MessageBox.Show("User data not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            else
            {
                MessageBox.Show("Please enter a valid user input.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }


        private int CalculateStarPoints(decimal totalCost)
        {
            decimal loyaltyValue = 0;

            // Access the text entered in the LoyeltyCard Entry field and try to parse it into an integer
            if (decimal.TryParse(txtExtraForCard.Text, out loyaltyValue))
            {

            }

            // Calculate star points based on the total cost (e.g., 3.5%)
            decimal starPointsDecimal = (totalCost * 0.035m) + previousstartPoint + loyaltyValue; // Assuming star points are 3.5% of the total cost
            int starPointsRounded = (int)Math.Round(starPointsDecimal); // Rounding the decimal to the nearest integer4

            return starPointsRounded;
        }

        private async Task UpdateStarPoints()
        {
            try
            {
                int starPoints = CalculateStarPoints(totalCostPrice);

                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.PutAsync($"https://localhost:7141/api/customers/starpoints/{loyaltyCardNumber}/{starPoints}", null);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Succes, Star points added to the.", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                    }
                    else
                    {
                        // Handle unsuccessful response (e.g., log error, show alert, etc.)
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exception (e.g., log error, show alert, etc.)
            }
        }






        private async Task<CustermerDTO> FetchUserData(string userInput, bool isLoyaltyCard)
        {
            string apiUrl = isLoyaltyCard ?
                    $"https://localhost:7141/api/customers/byLoyaltyCardNumber/{userInput}" :
                    $"https://localhost:7141/api/customers/byPhoneNumber/{userInput}";

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        CustermerDTO userData = JsonConvert.DeserializeObject<CustermerDTO>(json);
                        loyaltyCardNumber = userData?.LoyaltyCardNumber ?? "";
                        previousstartPoint = userData.StarPoints;

                        return userData;
                    }
                    else
                    {
                        // Handle unsuccessful response (e.g., log error, return null, etc.)
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exception (e.g., log error, return null, etc.)
                return null;
            }
        }


        private void txtQutity_TextChanged(object sender, EventArgs e)
        {

        }

        private async void FetchProducts()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("https://localhost:7141/product");

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    var products = JsonConvert.DeserializeObject<List<ProductDTO>>(content);

                    foreach (var product in products)
                    {
                        // Assuming 'product.Name' is the name and 'product.Price' is the price
                        // productCosts[product.Names] = product.Price;
                        productIds[product.Names] = product.Id;

                    }

                    // After fetching the products, display them
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


        #endregion

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }

}