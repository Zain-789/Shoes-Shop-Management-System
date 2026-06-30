using System;
using System.Windows;
using System.Windows.Controls;
using ShoesShopMS.Services;

namespace ShoesShopMS.Views.Pages
{
    public partial class CustomersPage : Page
    {
        public CustomersPage()
        {
            InitializeComponent();
            this.Loaded += CustomersPage_Loaded;
        }

        private void CustomersPage_Loaded(object sender, RoutedEventArgs e)
        {
            LoadCustomers();
        }

        private void LoadCustomers()
        {
            var customers = CustomerService.GetAllCustomers();
            CustomersDataGrid.ItemsSource = customers;
        }

        private void AddCustomer_Click(object sender, RoutedEventArgs e)
        {
            CustomerDialogWindow dialog = new CustomerDialogWindow();
            if (dialog.ShowDialog() == true)
            {
                LoadCustomers();
            }
        }

        private void EditCustomer_Click(object sender, RoutedEventArgs e)
        {
            if (CustomersDataGrid.SelectedItem is Models.Customer customer)
            {
                CustomerDialogWindow dialog = new CustomerDialogWindow(customer);
                if (dialog.ShowDialog() == true)
                {
                    LoadCustomers();
                }
            }
        }

        private void DeleteCustomer_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Feature Coming Soon", "Info");
        }
    }
}