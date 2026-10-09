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
    /// Логика взаимодействия для ClientWindow.xaml
    /// </summary>
    public partial class ClientWindow : Window
    {
        public ClientWindow()
        {
            InitializeComponent();

            using (var db = new shoes_dbEntities())
            {
                ProductsGrid.ItemsSource = db.products
                    .Include(p => p.category)
                    .Include(p => p.manufacturer)
                    .Include(p => p.deliver)
                    .ToList();
            }
        }
    }
}
