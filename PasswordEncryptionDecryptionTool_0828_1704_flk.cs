// 代码生成时间: 2025-08-28 17:04:31
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows;

namespace PasswordEncryptionDecryptionTool
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void EncryptButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string password = PasswordTextBox.Text;
                byte[] encryptedPassword = EncryptPassword(password);
                EncryptedTextBox.Text = Convert.ToBase64String(encryptedPassword);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void DecryptButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string encryptedPassword = EncryptedTextBox.Text;
                byte[] decryptedPassword = DecryptPassword(Convert.FromBase64String(encryptedPassword));
                PasswordTextBox.Text = Encoding.UTF8.GetString(decryptedPassword);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private byte[] EncryptPassword(string password)
        {
            using (Aes aes = Aes.Create())
            {
                using (ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV))
                {
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                        {
                            using (StreamWriter streamWriter = new StreamWriter(cryptoStream))
                            {
                                streamWriter.Write(password);
                            }
                        }
                        return memoryStream.ToArray();
                    }
                }
            }
        }

        private byte[] DecryptPassword(byte[] encryptedPassword)
        {
            using (Aes aes = Aes.Create())
            {
                using (ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV))
                {
                    using (MemoryStream memoryStream = new MemoryStream(encryptedPassword))
                    {
                        using (CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                        {
                            using (StreamReader streamReader = new StreamReader(cryptoStream))
                            {
                                return Encoding.UTF8.GetBytes(streamReader.ReadToEnd());
                            }
                        }
                    }
                }
            }
        }
    }
}