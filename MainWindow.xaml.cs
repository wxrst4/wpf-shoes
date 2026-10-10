using System.Linq;
using System.Windows;
using wpf_shoes.admin;

namespace wpf_shoes
{
    public partial class MainWindow : Window
    {
        private readonly shoes_dbEntities db;

        public MainWindow() {
            InitializeComponent();
            db = new shoes_dbEntities();
        }

        private void Btn_SingIn(object sender, RoutedEventArgs e)
        {
            var user = db.users.FirstOrDefault(u =>u.login == tb_login.Text.Trim() && u.password == tb_password.Password);


            switch (user.user_roles.role.name)
            {
                case "ADMIN": new AdminWindow().Show(); break;
                case "MANAGER": new ManagerWindow().Show(); break;
                case "CLIENT": new ClientWindow().Show(); break;
                default:
                    MessageBox.Show("Неизвестная роль пользователя");
                    return;
            }
        }

        private void Btn_SingInGuest(object sender, RoutedEventArgs e)
        {
            new ClientWindow().Show();
        }

    }
}
