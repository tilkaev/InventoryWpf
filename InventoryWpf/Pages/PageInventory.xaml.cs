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

        private void MultiplySearch(string[] strings)
        {
            foreach (var row in strings)
            {

            }
        }

        private void Find(string str = "", int column = -1)
        {
            if (str != "")
            {
                str = SearchTextBox.Text.ToLower();
            }

            int num_column = dataTableMain.Columns.Count;
            var dataTable = dataTableMain.Copy();


            int index_from = column == -1 ? 0 : column;
            int index_to = column == -1 ? num_column : column + 1;
            int index_for_delete = column == -1 ? num_column : 1;

            if (str != "")
            {
                foreach (DataRow item in dataTable.Rows) // Модуль активного поиска
                {
                    int skip_del = 0;

                    for (int i = index_from; i < index_to; i++) // Проход по строкам
                    {
                        bool booling = item[i].ToString().ToLower().Contains(str); //str.IndexOf()
                        //MessageBox.Show(item[i].ToString().ToLower() + "|" + str);
                        if (booling)
                        {
                            skip_del = 0;
                            break;
                        }
                        skip_del++;
                    }
                    if (skip_del == index_for_delete)
                    {
                        item.Delete();
                    }
                }
                dataTable.AcceptChanges();
            }

            main_data_grid.ItemsSource = dataTable.AsDataView();
        }



        private void comboBoxCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var index = comboBoxCategory.SelectedIndex;

            if (index == -1)
            {
                main_data_grid.ItemsSource = dataTableMain.AsDataView();
            }
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Find(SearchTextBox.Text);
        }

        private void main_data_grid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
