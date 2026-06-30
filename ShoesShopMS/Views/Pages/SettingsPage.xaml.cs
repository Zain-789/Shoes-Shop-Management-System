using System;
using System.Windows;
using System.Windows.Controls;
using ShoesShopMS.Services;

namespace ShoesShopMS.Views.Pages
{
    public partial class SettingsPage : Page
    {
        public SettingsPage()
        {
            InitializeComponent();
        }

        private void SaveChanges_Click(object sender, RoutedEventArgs e)
        {
            string currentPassword = CurrentPasswordBox.Password;
            string newPassword = NewPasswordBox.Password;
            string confirmPassword = ConfirmPasswordBox.Password;

            if (string.IsNullOrEmpty(currentPassword) || string.IsNullOrEmpty(newPassword))
            {
                MessageLabel.Text = "❌ Please fill all fields";
                MessageLabel.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Red);
                return;
            }

            if (newPassword != confirmPassword)
            {
                MessageLabel.Text = "❌ Passwords do not match";
                MessageLabel.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Red);
                return;
            }

            if (AuthenticationService.ChangePassword(App.CurrentUser.UserId, currentPassword, newPassword))
            {
                MessageLabel.Text = "✅ Password changed successfully";
                MessageLabel.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Green);
                CurrentPasswordBox.Clear();
                NewPasswordBox.Clear();
                ConfirmPasswordBox.Clear();
            }
            else
            {
                MessageLabel.Text = "❌ Current password is incorrect";
                MessageLabel.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Red);
            }
        }
    }
}