using System;
using System.Windows;
using ShoesShopMS.Models;
using ShoesShopMS.Services;

namespace ShoesShopMS.Views
{
    public partial class SupplierDialogWindow : Window
    {
        private Supplier currentSupplier;

        public SupplierDialogWindow(Supplier supplier = null)
        {
            InitializeComponent();
            currentSupplier = supplier;
            this.WindowStartupLocation = WindowStartupLocation.CenterOwner;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (currentSupplier != null)
            {
                NameTextBox.Text = currentSupplier.SupplierName;
                PhoneTextBox.Text = currentSupplier.Phone;
                EmailTextBox.Text = currentSupplier.Email;
                AddressTextBox.Text = currentSupplier.Address;
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(NameTextBox.Text) || string.IsNullOrEmpty(PhoneTextBox.Text))
            {
                MessageBox.Show("Name and Phone are required", "Validation Error");
                return;
            }

            if (currentSupplier == null)
            {
                currentSupplier = new Supplier();
            }

            currentSupplier.SupplierName = NameTextBox.Text;
            currentSupplier.Phone = PhoneTextBox.Text;
            currentSupplier.Email = EmailTextBox.Text;
            currentSupplier.Address = AddressTextBox.Text;

            if (currentSupplier.SupplierId == 0)
            {
                SupplierService.AddSupplier(currentSupplier);
            }
            else
            {
                SupplierService.UpdateSupplier(currentSupplier);
            }

            this.DialogResult = true;
            this.Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}