using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using PageSize = iTextSharp.text.PageSize;
using System.Net.Mime;

namespace Desktop_application
{
    public class SimpleFontResolver
    {
        private static bool fontResolverSet = false;
        public static string template = "";

        public class Item
        {
            public string Name { get; set; }
            public int Quantity { get; set; }
            public decimal UnitPrice { get; set; }
            public decimal Amount { get; set; }
        }





        private static List<Item> ExtractItems(Dictionary<int, int> itemCounts, Dictionary<int, decimal> productCost, Dictionary<int, decimal> productprice, Dictionary<int, string> itemSellPrice, decimal itemPrice)
        {
            List<Item> items = new List<Item>();

            foreach (var item in itemCounts)
            {
                int itemId = item.Key;
                int quantity = item.Value;
                decimal unitPrice = 0; // Default value
                string itemName = "Unknown"; // Default value
                decimal itemCost = 0;

                // Get the unit price from productCost dictionary if available
                if (productCost.TryGetValue(itemId, out decimal price))
                {
                    unitPrice = price;
                }

                // Get the item name from itemSellPrice dictionary if available
                if (itemSellPrice.TryGetValue(itemId, out string name))
                {
                    itemName = name;
                }

                if (productprice.TryGetValue(itemId, out decimal cost))
                {
                    itemCost = cost;
                }

                // Create an Item object and add it to the list
                Item newItem = new Item
                {
                    Name = itemName,
                    Quantity = quantity,
                    UnitPrice = unitPrice,
                    Amount = itemCost// Calculate the amount
                };

                items.Add(newItem);
            }

            return items;
        }

        private static string GenerateHtmlBill(string orderSummary, string userName, Dictionary<int, int> itemCounts, decimal totalCost, Dictionary<int, decimal> productCost, Dictionary<int, decimal> productprice, decimal itemPrice, decimal cash, int orderNumber, Dictionary<int, string> itemSellPrice, string TmpName)
        {
            // Retrieve items from the dictionaries

            string htmlTemplatePath = TmpName;


            List<Item> items = ExtractItems(itemCounts, productCost, productprice, itemSellPrice, itemPrice);
            decimal calculatedTotalCost = totalCost;
            string htmlContent = htmlTemplatePath;

            // Replace user-related placeholders
            htmlContent = htmlContent.Replace("[USER_NAME]", userName);
            htmlContent = htmlContent.Replace("[ORDER_NUMBER]", orderNumber.ToString());
            htmlContent = htmlContent.Replace("[CURRENT_DATE]", DateTime.Now.ToShortDateString());
            // Add other replacements as needed...

            // Replace item-related placeholders dynamically
            string tableRows = "";
            foreach (Item item in items)
            {
                tableRows += $"<tr><td>{item.Name}</td><td>{item.Quantity}</td><td>{item.UnitPrice}</td><td>{item.Amount}</td></tr>";
            }

            // Target the specific placeholder in your template (e.g., table body)
            htmlContent = htmlContent.Replace("[]", tableRows);

            // Calculate balance due
            decimal balanceDue = calculatedTotalCost - cash;
            htmlContent = htmlContent.Replace("[TOTAL_COST]", calculatedTotalCost.ToString());
            htmlContent = htmlContent.Replace("[PAID_AMOUNT]", cash.ToString());
            htmlContent = htmlContent.Replace("[BALANCE_DUE]", balanceDue.ToString());

            // Return the generated HTML content
            return htmlContent;
        }


        private static byte[] GenerateBill(string orderSummary, string userName, Dictionary<int, int> itemCounts, decimal totalCost, Dictionary<int, decimal> productCost, Dictionary<int, decimal> productprice, decimal itemPrice, decimal cash, int orderNumber, Dictionary<int, string> itemSellPrice, string TmpName)
        {
            // Retrieve items from the dictionaries

            //string htmlTemplatePath = "C://Users/Chamindu/source/repos/Hello/Desktop-application/Desktop application/template.html";
            string htmlTemplatePath = TmpName;

            List<Item> items = ExtractItems(itemCounts, productCost, productprice, itemSellPrice, itemPrice);
            decimal calculatedTotalCost = totalCost;
            string htmlContent = htmlTemplatePath;

            // Replace user-related placeholders
            htmlContent = htmlContent.Replace("[USER_NAME]", userName);
            htmlContent = htmlContent.Replace("[ORDER_NUMBER]", orderNumber.ToString());
            htmlContent = htmlContent.Replace("[CURRENT_DATE]", DateTime.Now.ToShortDateString());
            // Add other replacements as needed...

            // Replace item-related placeholders dynamically
            string tableRows = "";
            foreach (Item item in items)
            {
                tableRows += $"<tr><td>{item.Name}</td><td>{item.Quantity}</td><td>{item.UnitPrice}</td><td>{item.Amount}</td></tr>";
            }

            // Target the specific placeholder in your template (e.g., table body)
            htmlContent = htmlContent.Replace("[]", tableRows);



            // Calculate balance due
            decimal balanceDue = calculatedTotalCost - cash;
            htmlContent = htmlContent.Replace("[TOTAL_COST]", calculatedTotalCost.ToString());
            htmlContent = htmlContent.Replace("[PAID_AMOUNT]", cash.ToString());
            htmlContent = htmlContent.Replace("[BALANCE_DUE]", balanceDue.ToString());


            // For illustration, displaying item details (replace this with your logic)
            using (MemoryStream stream = new MemoryStream())
            {
                var pageSize = iTextSharp.text.PageSize.A7;

                var a4Height = PageSize.A1.Height;
                using (Document document = new Document(new iTextSharp.text.Rectangle(pageSize.Width, a4Height)))
                {
                    using (PdfWriter writer = PdfWriter.GetInstance(document, stream))
                    {
                        document.Open();



                        // Parse the HTML using HTMLWorker for better CSS support
                        HTMLWorker htmlParser = new HTMLWorker(document);
                        htmlParser.Parse(new StringReader(htmlContent)); // Use the generated HTML content directly

                        document.Close();
                    }
                }
                return stream.ToArray();
            }

        }


        public static async void GenerateAndDownloadPdf(string orderSummary, string userName, Dictionary<int, int> itemCounts, decimal totalCost, Dictionary<int, decimal> productcost, Dictionary<int, decimal> productprice, decimal itemPrice, decimal Cash, int orderNumber, Dictionary<int, string> ItemSellprice, string TmpName , string TmpHtmlName)
        {
            // Call the method to generate PDF from HTML template
            byte[] pdfBytes = GenerateBill("Order Summary", userName, itemCounts, totalCost, productcost, productprice, itemPrice, Cash, orderNumber, ItemSellprice, TmpName);
            string fileName = $"Bill_{DateTime.Now:yyyyMMddHHmmss}.pdf";
            string filePath = "C://Users/Chamindu/source/repos/Hello/Desktop-application/Desktop application/" + fileName; // Path to save the file
            File.WriteAllBytes(filePath, pdfBytes);
            string htmlContetnt = GenerateHtmlBill("Order Summary", userName, itemCounts, totalCost, productcost, productprice, itemPrice, Cash, orderNumber, ItemSellprice, TmpHtmlName);
            // Save or send the generated PDF as needed

            SendHtmlByEmail(orderSummary, htmlContetnt);

            Console.WriteLine("PDF generated and saved to desktop.");

            // Open the PDF file using the default application associated with PDF files
        }




        private static void SendHtmlByEmail(string toEmail, string htmlContent)
        {
            try
            {
                string smtpServer = "smtp.gmail.com";
                int smtpPort = 587; // Update with your SMTP server port
                string smtpUsername = "chamindumoramudali99@gmail.com"; // Update with your SMTP server username
                string smtpPassword = "faxnmyhocirfjxqx"; // Update with your SMTP server password

                // Create an SMTP client
                SmtpClient smtpClient = new SmtpClient(smtpServer, smtpPort);
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(smtpUsername, smtpPassword);
                smtpClient.EnableSsl = true;

                // Create the email message
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress("chamindumoramudali99@gmail.com"); // Update with your email address
                mailMessage.To.Add(toEmail);
                mailMessage.Subject = "Bill";

                // Set the HTML content as the body of the email
                mailMessage.Body = htmlContent;
                mailMessage.IsBodyHtml = true; // Specify that the body contains HTML content

                // Send the email
                smtpClient.Send(mailMessage);
            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed
                Console.WriteLine($"Error sending email: {ex.Message}");
            }
        }


    }
}
