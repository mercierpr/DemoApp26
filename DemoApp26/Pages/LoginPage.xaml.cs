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
using DemoApp26.AppData;

namespace DemoApp26.Pages
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var currentUser = AppData.AppData.db.userss.FirstOrDefault
                (u => u.login == loginInput.Text && u.password == passwordInput.Text);

            if (currentUser == null)
            {
                MessageBox.Show("Пользователя не существует или вы ввели неправильный пароль");
            }
            else
            {
                AppData.AppData.CurrentUser = currentUser;
                NavigationService.Navigate(new ProductPage());
                switch (currentUser.role)
                {
                    case "Администратор":
                        NavigationService.Navigate(new ProductPage());
                        AppData.AppData.IsAdmin = true;
                        break;
                    case "Менеджер":
                        NavigationService.Navigate(new ProductPage());
                        break;
                    default:
                        NavigationService.Navigate(new UserPage());
                        break;
                }
            }
        }
    }
}
