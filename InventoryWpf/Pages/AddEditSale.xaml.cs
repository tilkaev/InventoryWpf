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

namespace InventoryWpf.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddEditSale.xaml
    /// </summary>
    public partial class AddEditSale : Page
    {

        class SaleTovari
        {
            public int IdTovara { get; set; }

            public int count { get; set; }
            
            public int price { get; set; }
        }

        List<SaleTovari> saleTovaris = new List<SaleTovari>();

        public AddEditSale()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}
