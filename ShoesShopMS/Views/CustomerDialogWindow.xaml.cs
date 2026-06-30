using System;
using System.Windows;
using ShoesShopMS.Models;
using ShoesShopMS.Services;

namespace ShoesShopMS.Views
{
    public partial class CustomerDialogWindow : Window
    {
        private Customer currentCustomer;

        public CustomerDialogWindow(Customer customer = null)
        {
            InitializeComponent();
            currentCustomer = customer;
            this.WindowStartupLocation = WindowStartupLocation.CenterOwner;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (currentCustomer != null)
            {
                NameTextBox.Text = currentCustomer.CustomerName;
                PhoneTextBox.Text = currentCustomer.Phone;
                EmailTextBox.Text = currentCustomer.Email;
                AddressTextBox.Text = currentCustomer.Address;
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(NameTextBox.Text) || string.IsNullOrEmpty(PhoneTextBox.Text))
            {
                MessageBox.Show("Name and Phone are required", "Validation Error");
                return;
            }

            if (currentCustomer == null)
            {
                currentCustomer = new Customer();
            }

            currentCustomer.CustomerName = NameTextBox.Text;
            currentCustomer.Phone = PhoneTextBox.Text;
            currentCustomer.Email = EmailTextBox.Text;
            currentCustomer.Address = AddressTextBox.Text;

            if (currentCustomer.CustomerId == 0)
            {
                CustomerService.AddCustomer(currentCustomer);
            }
            else
            {
                CustomerService.UpdateCustomer(currentCustomer);
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