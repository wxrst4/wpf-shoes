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

namespace wpf_shoes.admin
{
    /// <summary>
    /// Логика взаимодействия для CreateProductWindow.xaml
    /// </summary>
    public partial class CreateProductWindow : Window
    {

        private shoes_dbEntities db = new shoes_dbEntities();

        public CreateProductWindow()
        {
            InitializeComponent();

            cbCategoryId.ItemsSource = db.categories.ToList();
            cbManufacturerId.ItemsSource = db.manufacturers.ToList();
            cbDeliveryId.ItemsSource = db.delivers.ToList();
        }

        private void BtnAddProduct(object sender, RoutedEventArgs e)
        {
            var p = new product
            {
                productId = int.Parse(tbId.Text),
                name = tbName.Text,
                price = decimal.Parse(tbPrice.Text),
                categoryId = (long)cbCategoryId.SelectedValue,
                manufacturerId = (long)cbManufacturerId.SelectedValue,
                deliveryId = (long)cbDeliveryId.SelectedValue,
                discount = int.Parse(tbDiscount.Text),
                stock = int.Parse(tbStock.Text),
                description = tbDescription.Text
            };

            db.products.Add(p);
            db.SaveChanges();
            Close();
        }
    }
}
