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
    /// Логика взаимодействия для ProductPage.xaml
    /// </summary>
    public partial class ProductPage : Page
    {
        public bool sortAsc = true;
        public bool sortDesc = false;
        
        public ProductPage()
        {
            InitializeComponent();
            ProductsList.ItemsSource = AppData.AppData.db.products.ToList();

            SupplierFilter.Items.Add("Все поставщики");

            var suppliers = AppData.AppData.db.products
                .Select(p => p.supplier)
                .Distinct()
                .ToList();

            foreach (var s in suppliers)
                SupplierFilter.Items.Add(s);

            SupplierFilter.SelectedIndex = 0;
        }

        void LoadProducts()
        {
            var query = AppData.AppData.db.products.AsQueryable();

            var search = SearchBox.Text;

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(p =>
                    p.name.Contains(search) ||
                    p.articul.Contains(search) ||
                    p.manufacturer.Contains(search) ||
                    p.supplier.Contains(search) ||
                    p.description.Contains(search));
            }

            var supplier = SupplierFilter.SelectedItem?.ToString();

            if (!string.IsNullOrEmpty(supplier) && supplier != "Все поставщики")
            {
                query = query.Where(p => p.supplier == supplier);
            }

            if (sortAsc)
                query = query.OrderBy(p => p.count);
            else if (sortDesc)
                query = query.OrderByDescending(p => p.count);

            ProductsList.ItemsSource = query.ToList();
        }

        private void SortAsc_Click(object sender, RoutedEventArgs e)
        {
            sortAsc = true;
            sortDesc = false;
            LoadProducts();
        }

        private void SortDesc_Click(object sender, RoutedEventArgs e)
        {
            sortAsc = false;
            sortDesc = true;
            LoadProducts();
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            LoadProducts();
        }

        private void SupplierFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LoadProducts();
        }

        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            AppData.AppData.CurrentProduct = new products();
            NavigationService.Navigate(new ProductForm());
        }

        private void EditProduct_Click(object sender, MouseButtonEventArgs e)
        {
            AppData.AppData.CurrentProduct = ProductsList.SelectedItem as products;
            NavigationService.Navigate(new ProductForm());
        }
    }
}
