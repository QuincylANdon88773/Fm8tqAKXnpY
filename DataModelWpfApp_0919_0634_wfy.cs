// 代码生成时间: 2025-09-19 06:34:00
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

// ViewModel基类
public abstract class ViewModelBase : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

// 数据模型
public class DataModel : ViewModelBase
{
    private string _data;

    public string Data
    {
        get => _data;
        set => SetProperty(value);
    }

    private bool SetProperty<T>(T value, [CallerMemberName] string propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(this.GetType().GetProperty(propertyName)?.GetValue(this, null), value))
            return false;

        this.GetType().GetProperty(propertyName)?.SetValue(this, value);
        OnPropertyChanged(propertyName);
        return true;
    }
}

// MainWindow.xaml.cs
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        this.DataContext = new DataModel();
    }
}

// MainWindow.xaml
<Window x:Class=""DataModelWpfApp.MainWindow""
        xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/presentation""
        xmlns:x=""http://schemas.microsoft.com/winfx/2006/xaml""
        Title=""Data Model WPF App" " Height=""450" " Width=""800" ">
    <Grid>
        <TextBox Text=""{Binding Data, UpdateSourceTrigger=PropertyChanged}" "/>
    </Grid>
</Window>