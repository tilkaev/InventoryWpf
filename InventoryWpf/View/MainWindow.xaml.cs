using System;
using System.Collections.Generic;
using System.Data;
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

namespace InventoryWpf
{
    /// <summary>
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            var inquiry = @"select товары.идтовара, товары.название Название, категориитоваров.название Категория, товары.колвонаскладе 'Кол-во на складе'  from товары, категориитоваров
where товары.идкатегории = категориитоваров.идкатегории";

            SQL.SQLConnect();
            DataTable dt = SQL.Inquiry(inquiry);
            SQL.Close();
            main_data_grid.ItemsSource = dt.AsDataView();
            main_data_grid.Columns[0].Visibility = Visibility.Collapsed; // Скрываем первый столбец с ID
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var win = new Window3();
            win.Show();
        }

        private void MoveWindow(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }
    }
}
