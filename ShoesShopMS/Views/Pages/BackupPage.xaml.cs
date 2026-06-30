using System;
using System.Windows;
using System.Windows.Controls;
using System.IO;
using ShoesShopMS.Database;

namespace ShoesShopMS.Views.Pages
{
    public partial class BackupPage : Page
    {
        public BackupPage()
        {
            InitializeComponent();
        }

        private void CreateBackup_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string backupPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Backups");
                DatabaseInitializer.BackupDatabase(backupPath);
                StatusLabel.Text = "✅ Backup created successfully!";
                StatusLabel.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Green);
            }
            catch (Exception ex)
            {
                StatusLabel.Text = $"❌ Error: {ex.Message}";
                StatusLabel.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Red);
            }
        }

        private void RestoreBackup_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new Microsoft.Win32.OpenFileDialog
            {
                DefaultExt = ".db",
                Filter = "Database files (.db)|*.db"
            };

            if (dialog.ShowDialog() == true)
            {
                try
                {
                    DatabaseInitializer.RestoreDatabase(dialog.FileName);
                    StatusLabel.Text = "✅ Database restored successfully! Please restart the application.";
                    StatusLabel.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Green);
                }
                catch (Exception ex)
                {
                    StatusLabel.Text = $"❌ Error: {ex.Message}";
                    StatusLabel.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Red);
                }
            }
        }
    }
}