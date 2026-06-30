using System;
using System.Windows;
using System.Windows.Controls;
using ShoesShopMS.Services;

namespace ShoesShopMS.Views.Pages
{
    public partial class SuppliersPage : Page
    {
        public SuppliersPage()
        {
            InitializeComponent();
            this.Loaded += SuppliersPage_Loaded;
        }

        private void SuppliersPage_Loaded(object sender, RoutedEventArgs e)
        {
            LoadSuppliers();
        }

        private void LoadSuppliers()
        {
            var suppliers = SupplierService.GetAllSuppliers();
            SuppliersDataGrid.ItemsSource = suppliers;
        }

        private void AddSupplier_Click(object sender, RoutedEventArgs e)
        {
            SupplierDialogWindow dialog = new SupplierDialogWindow();
            if (dialog.ShowDialog() == true)
            {
                LoadSuppliers();
            }
        }

        private void EditSupplier_Click(object sender, RoutedEventArgs e)
        {
            if (SuppliersDataGrid.SelectedItem is Models.Supplier supplier)
            {
                SupplierDialogWindow dialog = new SupplierDialogWindow(supplier);
                if (dialog.ShowDialog() == true)
                {
                    LoadSuppliers();
                }
            }
        }

        private void DeleteSupplier_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Feature Coming Soon", "Info");
        }
    }
}