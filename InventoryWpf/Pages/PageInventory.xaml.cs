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

        private void MultiplySearch(string[] strings)
        {
            foreach (var row in strings)
            {

            }
        }

        private void Find(string str, int column = -1)
        {
            Find(new string[] { str.ToLower() }, column);
        }

        private void Find(string[] search_words, int search_column = -1)
        {
            /*
            if (search_words == null)
                return;

            var dataTable = dataTableMain.Copy();
            int num_column = dataTable.Columns.Count;



            int index_from;
            int index_to;
            int index_for_delete;

            if (search_column == -1) // Вся таблица
            {
                index_from = 0;
                index_to = num_column;
                index_for_delete = num_column;
            }
            else // Определенный столбец
            {
                index_from = search_column;
                index_to = search_column + 1;
                index_for_delete = 1;
            }



            foreach (DataRow item in dataTable.Rows) // Модуль активного поиска
            {
                int skip_del = 0;

                for (int i = index_from; i < index_to; i++) // Проход по строкам
                {
                    bool booling = item[i].ToString().ToLower().Contains(search_words); //str.IndexOf()
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

            main_data_grid.ItemsSource = dataTable.AsDataView();*/
        }


        private void Search_Changed(object sender, object e)
        {

            var newDataTable = SearcherDataTable.WordSearch(SearchTextBox.Text, dataTableMain);
            main_data_grid.ItemsSource = newDataTable.AsDataView();


            return;
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
            //var newDataTable = searcherData.MultiSearch();
            main_data_grid.ItemsSource = newDataTable.AsDataView();

            /*
            Find(SearchTextBox.Text, 1);



            if (index == -1)
            {
                main_data_grid.ItemsSource = dataTableMain.AsDataView();
            }*/

        }

        private void main_data_grid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void comboBoxCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
