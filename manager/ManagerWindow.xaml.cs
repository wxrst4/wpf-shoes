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

namespace wpf_shoes
{
    /// <summary>
    /// Логика взаимодействия для ManagerWindow.xaml
    /// </summary>
    public partial class ManagerWindow : Window
    {

        private shoes_dbEntities db = new shoes_dbEntities();

        public ManagerWindow()
        {
            InitializeComponent();

            ProductsGrid.ItemsSource = db.products
                .Include(p => p.category)
                .Include(p => p.manufacturer)
                .Include(p => p.deliver)
                .ToList();

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
