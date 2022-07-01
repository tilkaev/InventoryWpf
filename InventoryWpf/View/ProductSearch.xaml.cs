﻿using System;
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

namespace InventoryWpf.View
{
    /// <summary>
    /// Логика взаимодействия для ProductSearch.xaml
    /// </summary>
    public partial class ProductSearch : Window
    {


        DataTable dataTableMain;
        DataTable dataTableCategory;
        DataTable newDataTable;



        public ProductSearch()
        {
            InitializeComponent();
            var inquiry = @"select товары.идтовара, товары.название Название, категориитоваров.название Категория, товары.цена Цена, товары.колвонаскладе 'Кол-во на складе'  from товары, категориитоваров
where товары.идкатегории = категориитоваров.идкатегории and товары.колвонаскладе > 0";

            SQL.SQLConnect();
            SearchTextBox.Text = "";
            dataTableMain = SQL.Inquiry(inquiry);
            newDataTable = dataTableMain.Copy();
            SQL.Close();
            dataGridMain.ItemsSource = dataTableMain.AsDataView();
            //main_data_grid.Columns[0].Visibility = Visibility.Collapsed; // Скрываем первый столбец с ID
        }

        private void Search_Changed(object sender, TextChangedEventArgs e)
        {

        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {

        }

        private void dataGridMain_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
