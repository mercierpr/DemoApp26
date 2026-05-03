using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    /// Логика взаимодействия для OrderForm.xaml
    /// </summary>
    public partial class OrderForm : Page
    {
        public OrderForm()
        {
            InitializeComponent();
            DataContext = AppData.AppData.CurrentOrder;
            ComboBoxStatus.Items.Add("Завершен");
            ComboBoxStatus.Items.Add("Новый");
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            var currentOrder = AppData.AppData.CurrentOrder;
            try
            {
                currentOrder.articul = TextBoxArticul.Text;
                currentOrder.status = ComboBoxStatus.Text;
                currentOrder.date_order = TextBoxDateOrder.SelectedDate;
                currentOrder.date_delivery = TextBoxDateDelivery.SelectedDate;

                if (currentOrder.id == 0)
                {
                    AppData.AppData.db.orders.Add(currentOrder);
                    AppData.AppData.db.SaveChanges();
                    MessageBox.Show("Заказ добавлен", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    AppData.AppData.db.SaveChanges();
                    MessageBox.Show("Данные заказы успешно обновлены", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                }

                NavigationService.Navigate(new OrdersPage());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Info", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ButtonDel_Click(object sender, RoutedEventArgs e)
        {
            if (AppData.AppData.CurrentOrder.id == 0)
            {
                MessageBox.Show("Заказ не найден. Удаление невозможно", "Info", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                AppData.AppData.db.orders.Remove(AppData.AppData.CurrentOrder);
                AppData.AppData.db.SaveChanges();
                MessageBox.Show("Заказ успешно удален", "Info", MessageBoxButton.OK, MessageBoxImage.Information);

                NavigationService.Navigate(new ProductForm());
            }
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
