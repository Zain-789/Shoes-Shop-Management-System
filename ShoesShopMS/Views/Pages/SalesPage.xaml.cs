using System;
using System.Windows;
using System.Windows.Controls;
using ShoesShopMS.Services;

namespace ShoesShopMS.Views.Pages
{
    public partial class SalesPage : Page
    {
        public SalesPage()
        {
            InitializeComponent();
            this.Loaded += SalesPage_Loaded;
        }

        private void SalesPage_Loaded(object sender, RoutedEventArgs e)
        {
            LoadSales();
        }

        private void LoadSales()
        {
            var sales = SalesService.GetAllSales();
            SalesDataGrid.ItemsSource = sales;
        }

        private void NewSale_Click(object sender, RoutedEventArgs e)
        {
            SaleDialogWindow dialog = new SaleDialogWindow();
            if (dialog.ShowDialog() == true)
            {
                LoadSales();
            }
        }

        private void ViewSale_Click(object sender, RoutedEventArgs e)
        {
            if (SalesDataGrid.SelectedItem is Models.Sale sale)
            {
                MessageBox.Show($"Sale Details:\nBill: {sale.BillNumber}\nAmount: Rs. {sale.TotalAmount:F2}\nProfit: Rs. {sale.Profit:F2}", "Sale Details");
            }
        }
    }
}