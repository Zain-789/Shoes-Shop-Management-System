using System.Windows;
using System.Windows.Controls;
using ShoesShopMS.Services;

namespace ShoesShopMS.Views.Pages
{
    public partial class StockPage : Page
    {
        public StockPage()
        {
            InitializeComponent();
            this.Loaded += StockPage_Loaded;
        }

        private void StockPage_Loaded(object sender, RoutedEventArgs e)
        {
            LoadStock();
        }

        private void LoadStock()
        {
            var products = ProductService.GetAllProducts();
            StockDataGrid.ItemsSource = products;
        }
    }
}