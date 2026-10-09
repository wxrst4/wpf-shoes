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
    /// Логика взаимодействия для CreateOrderWindow.xaml
    /// </summary>
    public partial class CreateOrderWindow : Window
    {

        private shoes_dbEntities db = new shoes_dbEntities();

        public CreateOrderWindow()
        {
            InitializeComponent();
        }

        private void BtnAddOrder(object sender, RoutedEventArgs e)
        {
            var newOrder = new order
            {
                orderId = long.Parse(tbOrderId.Text),
                articleNumber = tbArticleNumber.Text,
                createdAt = DateTime.Parse(tbCreatedAt.Text),
                deliveredAt = DateTime.Parse(tbDeliveredAt.Text),
                addressId = long.Parse(tbAddressId.Text),
                userId = long.Parse(tbUserId.Text),
                code = long.Parse(tbCode.Text),
                status = tbStatus.Text
            };

            db.orders.Add(newOrder);
            db.SaveChanges();

            Close();
        }
    }
}
