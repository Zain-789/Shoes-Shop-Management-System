using System;
using System.Windows;
using ShoesShopMS.Models;
using ShoesShopMS.Services;

namespace ShoesShopMS.Views
{
    public partial class ExpenseDialogWindow : Window
    {
        public ExpenseDialogWindow()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            DatePicker.SelectedDate = DateTime.Now;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(CategoryTextBox.Text) || string.IsNullOrEmpty(AmountTextBox.Text))
            {
                MessageBox.Show("Category and Amount are required", "Validation Error");
                return;
            }

            if (!decimal.TryParse(AmountTextBox.Text, out decimal amount))
            {
                MessageBox.Show("Amount must be a valid number", "Validation Error");
                return;
            }

            var expense = new Expense
            {
                Category = CategoryTextBox.Text,
                Amount = amount,
                ExpenseDate = DatePicker.SelectedDate ?? DateTime.Now,
                Description = DescriptionTextBox.Text
            };

            ExpenseService.AddExpense(expense);
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