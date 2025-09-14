// 代码生成时间: 2025-09-15 01:32:03
using System;
using System.Collections.Generic;
using System.Windows;

// ShoppingCartApp.xaml.cs
public partial class ShoppingCartApp : Window
{
    private readonly ShoppingCart _shoppingCart;

    // Constructor
    public ShoppingCartApp()
    {
        InitializeComponent();
        _shoppingCart = new ShoppingCart();
    }

    // Method to add item to the shopping cart
    public void AddItemToCart(Item item)
    {
        if (item == null)
        {
            throw new ArgumentNullException(nameof(item), "Item cannot be null");
        }

        try
        {
            _shoppingCart.AddItem(item);
        }
        catch (Exception ex)
        {
            // Log the exception or show error message to the user
            MessageBox.Show($"Error adding item to cart: {ex.Message}");
        }
    }

    // Method to remove item from the shopping cart
    public void RemoveItemFromCart(Item item)
    {
        if (item == null)
        {
            throw new ArgumentNullException(nameof(item), "Item cannot be null");
        }

        try
        {
            _shoppingCart.RemoveItem(item);
        }
        catch (Exception ex)
        {
            // Log the exception or show error message to the user
            MessageBox.Show($"Error removing item from cart: {ex.Message}");
        }
    }

    // Method to clear the shopping cart
    public void ClearCart()
    {
        _shoppingCart.Clear();
    }
}

// ShoppingCart.cs
public class ShoppingCart
{
    private readonly List<Item> _items = new List<Item>();

    public void AddItem(Item item)
    {
        if (item == null)
        {
            throw new ArgumentNullException(nameof(item), "Item cannot be null");
        }

        _items.Add(item);
    }

    public void RemoveItem(Item item)
    {
        if (item == null)
        {
            throw new ArgumentNullException(nameof(item), "Item cannot be null");
        }

        if (!_items.Contains(item))
        {
            throw new InvalidOperationException("This item does not exist in the cart");
        }

        _items.Remove(item);
    }

    public void Clear()
    {
        _items.Clear();
    }
}

// Item.cs
public class Item
{
    public string Name { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }

    // Constructor
    public Item(string name, double price, int quantity)
    {
        Name = name;
        Price = price;
        Quantity = quantity;
    }
}
