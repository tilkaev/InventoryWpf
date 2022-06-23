using InventoryWpf.Core;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace InventoryWpf
{
    /// <summary>
    /// Логика взаимодействия для PageInventory.xaml
    /// </summary>
    public partial class PageInventory : Page
    {
        DataTable dataTableMain;
        DataTable dataTableCategory;
        public PageInventory()
        {
            InitializeComponent();
            var inquiry = @"select товары.идтовара, товары.название Название, категориитоваров.название Категория, товары.колвонаскладе 'Кол-во на складе'  from товары, категориитоваров
where товары.идкатегории = категориитоваров.идкатегории";
            string inquiry2 = String.Format("select * from категориитоваров");

            SQL.SQLConnect();
            dataTableMain = SQL.Inquiry(inquiry);
            dataTableCategory = SQL.Inquiry(inquiry2);
            SQL.Close();
            main_data_grid.ItemsSource = dataTableMain.AsDataView();
            //main_data_grid.Columns[0].Visibility = Visibility.Collapsed; // Скрываем первый столбец с ID

            foreach (DataRow item in dataTableCategory.Rows)
            {
                comboBoxCategory.Items.Add(item[1].ToString()); // Заполнение КомбоБокса
            }



        }

        private void Search_Changed(object sender, object e)
        {
            string textToFind1 = SearchTextBox.Text;
            string textToFind2 = "";

            if (comboBoxCategory.SelectedIndex != -1)
            {
                textToFind2 = comboBoxCategory.SelectedItem.ToString();
            }

            var searcherData = new SearcherDataTable()
            {
                search_words = new string[] { textToFind1, textToFind2 },
                search_columns = new int[] { 1, 2 },
                dataTable = dataTableMain
            };
            var newDataTable = searcherData.MultiSearch();
            main_data_grid.ItemsSource = newDataTable.AsDataView();



        }

        private void main_data_grid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }


    }
}
