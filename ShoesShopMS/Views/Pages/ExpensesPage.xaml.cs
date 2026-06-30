using System;
using System.Windows;
using System.Windows.Controls;
using ShoesShopMS.Services;

namespace ShoesShopMS.Views.Pages
{
    public partial class ExpensesPage : Page
    {
        public ExpensesPage()
        {
            InitializeComponent();
            this.Loaded += ExpensesPage_Loaded;
        }

        private void ExpensesPage_Loaded(object sender, RoutedEventArgs e)
        {
            LoadExpenses();
        }

        private void LoadExpenses()
        {
            var expenses = ExpenseService.GetAllExpenses();
            ExpensesDataGrid.ItemsSource = expenses;
        }

        private void AddExpense_Click(object sender, RoutedEventArgs e)
        {
            ExpenseDialogWindow dialog = new ExpenseDialogWindow();
            if (dialog.ShowDialog() == true)
            {
                LoadExpenses();
            }
        }
    }
}