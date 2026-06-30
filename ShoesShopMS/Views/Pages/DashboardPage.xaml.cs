using System.Windows;
using System.Windows.Controls;
using ShoesShopMS.Services;

namespace ShoesShopMS.Views.Pages
{
    public partial class DashboardPage : Page
    {
        public DashboardPage()
        {
            InitializeComponent();
            this.Loaded += DashboardPage_Loaded;
        }

        private void DashboardPage_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDashboardData();
        }

        private void LoadDashboardData()
        {
            var stats = ReportService.GetTodayStats();

            TodaysSalesLabel.Text = $"Rs. {stats.TodaySales:F2}";
            TodaysProfitLabel.Text = $"Rs. {stats.TodayProfit:F2}";
            TotalStockLabel.Text = $"{stats.TotalStockItems} pairs";
            TotalCustomersLabel.Text = stats.TotalCustomers.ToString();
            PendingPaymentsLabel.Text = $"Rs. {stats.PendingPayments:F2}";
            LowStockLabel.Text = stats.LowStockItems.ToString();
            TotalProductsLabel.Text = stats.TotalProducts.ToString();
            ExpensesLabel.Text = $"Rs. {stats.TotalExpenses:F2}";
        }
    }
}
