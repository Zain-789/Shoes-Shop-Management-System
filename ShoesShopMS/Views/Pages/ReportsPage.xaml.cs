using System;
using System.Windows;
using System.Windows.Controls;
using ShoesShopMS.Services;

namespace ShoesShopMS.Views.Pages
{
    public partial class ReportsPage : Page
    {
        public ReportsPage()
        {
            InitializeComponent();
            this.Loaded += ReportsPage_Loaded;
        }

        private void ReportsPage_Loaded(object sender, RoutedEventArgs e)
        {
            FromDatePicker.SelectedDate = DateTime.Today.AddDays(-30);
            ToDatePicker.SelectedDate = DateTime.Today;
            GenerateReport();
        }

        private void GenerateReport_Click(object sender, RoutedEventArgs e)
        {
            GenerateReport();
        }

        private void GenerateReport()
        {
            DateTime fromDate = FromDatePicker.SelectedDate ?? DateTime.Today.AddDays(-30);
            DateTime toDate = ToDatePicker.SelectedDate ?? DateTime.Today;

            var stats = ReportService.GetDateRangeStats(fromDate, toDate);
            TotalSalesLabel.Text = $"Rs. {stats.TodaySales:F2}";
            TotalProfitLabel.Text = $"Rs. {stats.TodayProfit:F2}";
            TotalExpensesLabel.Text = $"Rs. {stats.TotalExpenses:F2}";
        }
    }
}