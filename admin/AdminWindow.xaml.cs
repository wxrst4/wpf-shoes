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
using System.Windows.Shapes;
using System.Data.Entity;

namespace wpf_shoes.admin
{
    /// <summary>
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {

        private shoes_dbEntities db;

        public AdminWindow()
        {
            InitializeComponent();
            db = new shoes_dbEntities();

            ProductsGrid.ItemsSource = db.products.Include(p => p.category)
                .Include(p => p.manufacturer)
                .Include(p => p.deliver)
                .ToList();

            OrdersGrid.ItemsSource = db.orders
                .Include(o => o.user)
                .Include(o => o.address)
                .ToList();
        }

        private void BtnDeleteProductById(object sender, RoutedEventArgs e)
        {
            var id = long.Parse(tbId.Text.Trim());

            var product = db.products.FirstOrDefault(p => p.productId == id);

            db.products.Remove(product);
            db.SaveChanges();


            ProductsGrid.ItemsSource = db.products.Include(p => p.category)
                .Include(p => p.manufacturer)
                .Include(p => p.deliver)
                .ToList();
        }

        private void BtnDeleteOrderById(object sender, RoutedEventArgs e)
        {
            var id = long.Parse(tbOrderId.Text.Trim());

            var order = db.orders.FirstOrDefault(o => o.orderId == id);

            db.orders.Remove(order);
            db.SaveChanges();

            OrdersGrid.ItemsSource = db.orders
                .Include(o => o.user)
                .Include(o => o.address)
                .ToList();
        }

        private void BtnCreateProduct(object sender, RoutedEventArgs e)
        {
            new CreateProductWindow().ShowDialog();
            ProductsGrid.ItemsSource = db.products.Include(p => p.category)
                .Include(p => p.manufacturer)
                .Include(p => p.deliver)
                .ToList();

        }


        private void BtnSortOrdersByStatus(object sender, RoutedEventArgs e)
        {
            OrdersGrid.ItemsSource = db.orders
                .Include(o => o.user)
                .Include(o => o.address)
                .Where(o => o.status == "DONE")
                .ToList();
        }

        private void BtnCreateOrder(object sender, RoutedEventArgs e)
        {
            new CreateOrderWindow().ShowDialog();
            OrdersGrid.ItemsSource = db.orders
               .Include(o => o.user)
               .Include(o => o.address)
               .ToList();
        }

        private void BtnSortProductByPrice(object sender, RoutedEventArgs e)
        {
            ProductsGrid.ItemsSource = db.products
                .Include(p => p.category)
                .Include(p => p.manufacturer)
                .Include(p => p.deliver)
                .OrderBy(p => p.price)
                .ToList();
        }

        private void BtnSearchProductsByCategory(object sender, RoutedEventArgs e)
        {
            var name = tbName.Text.Trim();

            ProductsGrid.ItemsSource = db.products
                .Include(p => p.category)
                .Include(p => p.manufacturer)
                .Include(p => p.deliver)
                .Where(p => p.name == name)
                .ToList();
        }

        private void BtnFilterProductsById(object sender, RoutedEventArgs e)
        {
            ProductsGrid.ItemsSource = db.products
                .Include(p => p.category)
                .Include(p => p.manufacturer)
                .Include(p => p.deliver)
                .Where(p => p.productId > 5)
                .ToList();
        }
    }
}
