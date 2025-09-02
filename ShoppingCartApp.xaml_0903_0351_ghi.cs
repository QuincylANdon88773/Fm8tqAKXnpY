// 代码生成时间: 2025-09-03 03:51:03
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace ShoppingCartWPFApp
{
    /// <summary>
    /// Interaction logic for MainWindow
    /// </summary>
    public partial class ShoppingCartApp : Window
    {
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartApp()
        {
            InitializeComponent();
            _shoppingCart = new ShoppingCart();
        }

        private void AddToCartButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var product = GetSelectedProduct();
                if (product != null)
                {
                    _shoppingCart.AddProduct(product);
                    MessageBox.Show("You have added "" + product.Name + "" to your cart.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private Product GetSelectedProduct()
        {
            // Assuming there's a ListBox named 'ProductList' in XAML with items of type Product
            var selectedProduct = (Product)ProductList.SelectedItem;
            if (selectedProduct == null)
            {
                throw new InvalidOperationException("No product is selected.");
            }
            return selectedProduct;
        }
    }
}

/*
 * Product.cs
 * Represents a product in the shopping cart.
 */
namespace ShoppingCartWPFApp
{
    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; } = 1;
    }
}

/*
 * ShoppingCart.cs
 * Manages the shopping cart operations.
 */
namespace ShoppingCartWPFApp
{
    public class ShoppingCart
    {
        private List<Product> _products;

        public ShoppingCart()
        {
            _products = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            // Check if the product is already in the cart
            var existingProduct = _products.Find(p => p.Name == product.Name);
            if (existingProduct != null)
            {
                existingProduct.Quantity++;
            }
            else
            {
                _products.Add(product);
            }
        }

        // Additional methods like RemoveProduct, GetTotal, etc., can be added here.
    }
}