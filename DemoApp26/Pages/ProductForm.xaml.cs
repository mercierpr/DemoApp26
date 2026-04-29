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
    /// Логика взаимодействия для ProductForm.xaml
    /// </summary>
    public partial class ProductForm : Page
    {
        public ProductForm()
        {
            InitializeComponent();
            DataContext = AppData.AppData.CurrentProduct;
        }

        private void Button_Click(object sender, RoutedEventArgs e)

        {
            var currentProduct = AppData.AppData.CurrentProduct;
            try
            {
                currentProduct.articul = TextBoxArticul.Text;
                currentProduct.name = TextBoxName.Text;
                currentProduct.edizm = TextBoxEdizm.Text;
                currentProduct.price = int.Parse(TextBoxPrice.Text);
                currentProduct.supplier = TextBoxSupplier.Text;
                currentProduct.manufacturer = TextBoxManufacturer.Text;
                currentProduct.category = TextBoxCategory.Text;
                currentProduct.sale = int.Parse(TextBoxSale.Text);
                currentProduct.count = int.Parse(TextBoxCount.Text);
                currentProduct.description = TextBoxDescription.Text;

                if (AppData.AppData.CurrentProduct.id == 0)
                {
                    AppData.AppData.db.products.Add(AppData.AppData.CurrentProduct);
                    AppData.AppData.db.SaveChanges();
                    MessageBox.Show("Продукт добавлен", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    AppData.AppData.db.SaveChanges();
                    MessageBox.Show("Данные успешно обновлены", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                }

                NavigationService.Navigate(new ProductForm());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Info", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
