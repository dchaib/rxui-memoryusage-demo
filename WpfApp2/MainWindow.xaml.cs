using DynamicData;
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
using WpfApp2.Models;
using WpfApp2.ViewModels;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var shops = new SourceList<Shop>();
            shops.AddRange(GetDummyData());

            var vm = new InventoryViewModel(shops);
        }

        private static List<Shop> GetDummyData()
        {
            var shops = new List<Shop>();

            for (int i = 0; i < 50; i++)
            {
                var products = new List<Product>();
                for (int j = 0; j < 100; j++)
                {
                    products.Add(new Product { Id = i * 1000 + j, Name = $"Product {i * 1000 + j}" });
                }
                shops.Add(new Shop(products)
                {
                    Id = i,
                    Name = $"Shop {i}"
                });
            }

            return shops;
        }
    }
}
