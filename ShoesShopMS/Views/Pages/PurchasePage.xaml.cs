using System;
using System.Windows;
using System.Windows.Controls;
using ShoesShopMS.Services;

namespace ShoesShopMS.Views.Pages
{
    public partial class PurchasePage : Page
    {
        public PurchasePage()
        {
            InitializeComponent();
            this.Loaded += PurchasePage_Loaded;
        }

        private void PurchasePage_Loaded(object sender, RoutedEventArgs e)
        {
            LoadPurchases();
        }

        private void LoadPurchases()
        {
            var purchases = PurchaseService.GetAllPurchases();
            PurchaseDataGrid.ItemsSource = purchases;
        }

        private void NewPurchase_Click(object sender, RoutedEventArgs e)
        {
            PurchaseDialogWindow dialog = new PurchaseDialogWindow();
            if (dialog.ShowDialog() == true)
            {
                LoadPurchases();
            }
        }
    }
}