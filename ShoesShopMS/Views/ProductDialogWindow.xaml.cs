using System;
using System.Windows;
using ShoesShopMS.Models;
using ShoesShopMS.Services;

namespace ShoesShopMS.Views
{
    public partial class ProductDialogWindow : Window
    {
        private Product currentProduct;
        public bool IsSaved { get; set; } = false;

        public ProductDialogWindow(Product product = null)
        {
            InitializeComponent();
            currentProduct = product;
            this.WindowStartupLocation = WindowStartupLocation.CenterOwner;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (currentProduct != null)
            {
                // Edit mode - populate form
                ArticleNumberTextBox.Text = currentProduct.ArticleNumber;
                ArticleNumberTextBox.IsEnabled = false;
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateForm())
            {
                if (currentProduct == null)
                {
                    currentProduct = new Product();
                }

                currentProduct.ArticleNumber = ArticleNumberTextBox.Text;
                currentProduct.Brand = BrandTextBox.Text;
                currentProduct.ProductType = "Shoe";
                currentProduct.Color = ColorTextBox.Text;
                currentProduct.Size = SizeTextBox.Text;
                currentProduct.Material = MaterialTextBox.Text;
                currentProduct.PurchasePrice = decimal.Parse(PurchasePriceTextBox.Text);
                currentProduct.SalePrice = decimal.Parse(SalePriceTextBox.Text);
                currentProduct.Discount = decimal.TryParse(DiscountTextBox.Text, out var disc) ? disc : 0;
                currentProduct.MinimumStock = int.Parse(MinimumStockTextBox.Text);

                if (currentProduct.ProductId == 0)
                {
                    ProductService.AddProduct(currentProduct);
                }
                else
                {
                    ProductService.UpdateProduct(currentProduct);
                }

                IsSaved = true;
                this.DialogResult = true;
                this.Close();
            }
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrEmpty(ArticleNumberTextBox.Text))
            {
                MessageBox.Show("Article Number is required", "Validation Error");
                return false;
            }

            if (!decimal.TryParse(PurchasePriceTextBox.Text, out _))
            {
                MessageBox.Show("Purchase Price must be a valid number", "Validation Error");
                return false;
            }

            if (!decimal.TryParse(SalePriceTextBox.Text, out _))
            {
                MessageBox.Show("Sale Price must be a valid number", "Validation Error");
                return false;
            }

            return true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}