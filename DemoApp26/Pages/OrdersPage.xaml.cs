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

namespace DemoApp26.Pages
{
    /// <summary>
    /// Логика взаимодействия для OrdersPage.xaml
    /// </summary>
    public partial class OrdersPage : Page
    {
        public OrdersPage()
        {
            InitializeComponent();
            OrdersList.ItemsSource = AppData.AppData.db.orders.ToList();
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void AddOrder_Click(object sender, RoutedEventArgs e)
        {
            AppData.AppData.CurrentOrder = new orders();
            NavigationService.Navigate(new OrderForm());
        }

        private void EditOrder_Click(object sender, RoutedEventArgs e)
        {
            AppData.AppData.CurrentOrder = OrdersList.SelectedItem as orders;
            NavigationService.Navigate(new OrderForm());
        }
    }
}
