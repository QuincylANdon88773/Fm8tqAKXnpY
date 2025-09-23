// 代码生成时间: 2025-09-24 00:46:35
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

// 定义用户权限枚举
public enum UserPermission
{
    ReadOnly,
    Edit,
    Delete,
    Admin
}

// 用户模型
public class UserModel
{
    public string Username { get; set; }
    public UserPermission Permission { get; set; }
}

// 用户权限管理系统
public class UserPermissionManager
{
    // 用户列表
    private List<UserModel> userList;

    public UserPermissionManager()
    {
        userList = new List<UserModel>();
    }

    // 添加用户
    public void AddUser(string username, UserPermission permission)
    {
        try
        {
            if (string.IsNullOrEmpty(username))
            {
                throw new ArgumentException("Username cannot be null or empty.");
            }

            var user = new UserModel { Username = username, Permission = permission };
            userList.Add(user);
            Console.WriteLine($"User '{username}' added with permission '{permission}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error adding user: {ex.Message}");
        }
    }

    // 删除用户
    public void RemoveUser(string username)
    {
        try
        {
            var user = userList.FirstOrDefault(u => u.Username == username);
            if (user == null)
            {
                throw new KeyNotFoundException($"User '{username}' not found.");
            }

            userList.Remove(user);
            Console.WriteLine($"User '{username}' removed.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error removing user: {ex.Message}");
        }
    }

    // 更新用户权限
    public void UpdateUserPermission(string username, UserPermission newPermission)
    {
        try
        {
            var user = userList.FirstOrDefault(u => u.Username == username);
            if (user == null)
            {
                throw new KeyNotFoundException($"User '{username}' not found.");
            }

            user.Permission = newPermission;
            Console.WriteLine($"User '{username}' permission updated to '{newPermission}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error updating user permission: {ex.Message}");
        }
    }

    // 显示用户列表
    public void DisplayUsers()
    {
        Console.WriteLine("User List:");
a
        foreach (var user in userList)
        {
            Console.WriteLine($"Username: {user.Username}, Permission: {user.Permission}");
        }
    }
}

// WPF 主窗口
public partial class MainWindow : Window
{
    private UserPermissionManager userPermissionManager;

    public MainWindow()
    {
        InitializeComponent();
        userPermissionManager = new UserPermissionManager();
    }

    private void AddUserButton_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            var username = UsernameTextBox.Text;
            var permission = (UserPermission)Enum.Parse(typeof(UserPermission), PermissionComboBox.SelectedItem.ToString());

            userPermissionManager.AddUser(username, permission);

            // 刷新用户列表显示
            RefreshUserList();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private void RemoveUserButton_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            var username = UsernameTextBox.Text;
            userPermissionManager.RemoveUser(username);

            // 刷新用户列表显示
            RefreshUserList();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private void RefreshUserList()
    {
        UserListDisplay.Items.Clear();
        foreach (var user in userPermissionManager.userList)
        {
            UserListDisplay.Items.Add($"Username: {user.Username}, Permission: {user.Permission}");
        }
    }
}
