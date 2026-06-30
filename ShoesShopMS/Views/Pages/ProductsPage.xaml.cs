using System;
using System.Windows;
using System.Windows.Controls;
using ShoesShopMS.Services;

namespace ShoesShopMS.Views.Pages
{
    public partial class ProductsPage : Page
    {
        public ProductsPage()
        {
            InitializeComponent();
            this.Loaded += ProductsPage_Loaded;
        }

        private void ProductsPage_Loaded(object sender, RoutedEventArgs e)
        {
            LoadProducts();
        }

        private void LoadProducts()
        {
            var products = ProductService.GetAllProducts();
            ProductsDataGrid.ItemsSource = products;
        }

        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            ProductDialogWindow dialog = new ProductDialogWindow();
            if (dialog.ShowDialog() == true)
            {
                LoadProducts();
            }
        }

        private void EditProduct_Click(object sender, RoutedEventArgs e)
        {
            if (ProductsDataGrid.SelectedItem is Models.Product product)
            {
                ProductDialogWindow dialog = new ProductDialogWindow(product);
                if (dialog.ShowDialog() == true)
                {
                    LoadProducts();
                }
            }
        }

        private void DeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            if (ProductsDataGrid.SelectedItem is Models.Product product)
            {
                if (MessageBox.Show($"Delete product {product.ArticleNumber}?", "Confirm", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    ProductService.DeleteProduct(product.ProductId);
                    LoadProducts();
                }
            }
        }
    }
}