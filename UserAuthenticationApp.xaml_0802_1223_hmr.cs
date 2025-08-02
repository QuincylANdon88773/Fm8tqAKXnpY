// 代码生成时间: 2025-08-02 12:23:27
using System;
using System.Windows;
using System.Windows.Controls;

namespace UserAuthenticationApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IAuthenticationService authenticationService;

        public MainWindow()
        {
            InitializeComponent();
            authenticationService = new AuthenticationService();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordPasswordBox.Password;

            try
            {
                bool isAuthenticated = authenticationService.Authenticate(username, password);
                if (isAuthenticated)
                {
                    MessageBox.Show("Login successful");
                }
                else
                {
                    MessageBox.Show("Invalid username or password");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
    }
}

public interface IAuthenticationService
{
    bool Authenticate(string username, string password);
}

public class AuthenticationService : IAuthenticationService
{
    /// <summary>
    /// Authenticates the user with the given username and password.
    /// For simplicity, this example uses hard-coded credentials.
    /// </summary>
    /// <param name="username">The username to authenticate.</param>
    /// <param name="password">The password to authenticate.</param>
    /// <returns>True if authentication is successful, false otherwise.</returns>
    public bool Authenticate(string username, string password)
    {
        // Normally, you would check the credentials against a database or a secure service.
        // For demonstration purposes, we're using hardcoded credentials.
        const string validUsername = "admin";
        const string validPassword = "password123";

        if (username == validUsername && password == validPassword)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}