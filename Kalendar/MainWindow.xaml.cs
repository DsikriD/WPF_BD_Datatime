using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Kalendar
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        void rebot() {
            lbl_bd.Content = "";
            BaseDate.LoadDate();
            foreach (var a in BaseDate.ListOrder)
            {
                lbl_bd.Content += a.Id + " " + a.Customer_name + " " + a.Order + a.DateCreated + '\n';
            }
        }


        public MainWindow()
        {
            InitializeComponent();


            Item_for_Sell CMBLIST= new Item_for_Sell();
            foreach(var a in CMBLIST.Item_value)
            Cmbbox.Items.Add(a);
       



            DispatcherTimer LiveTime = new DispatcherTimer();
            LiveTime.Interval = TimeSpan.FromSeconds(1);
            LiveTime.Tick += timer_Tick;
            LiveTime.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            Date date = new Date(DateTime.Now);
            lbl.Content = Convert.ToString(date.DT);
            lblMon.Content = date.month;
            lblVyear.Content = date.ViskosYear();
            lblWeek.Content = date.dayWeek();
            lblDayTime.Content = date.timeday;
            

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            rebot();
        }

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {

            if (txtbox.Text != "" && txtbox.Text.Length > 2 && Cmbbox.SelectedIndex != -1)
            {

                BaseDate.AddOrderInDate(txtbox.Text,Convert.ToString(Cmbbox.Text));
            }
            else MessageBox.Show("Некооректное имя или название заказа");
            rebot();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (deleteTxtbox.Text != "")
            {
                BaseDate.ListOrderForUser(deleteTxtbox.Text);
                cmbOrDel.Items.Clear();
                    foreach (var a in BaseDate.ListOrder)
                        cmbOrDel.Items.Add($"N {a.Id} Заказ:{a.Order}");
            }
            else MessageBox.Show("Введите имя");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (cmbOrDel.Text != "")
                BaseDate.DeleteOrder(BaseDate.ListOrder[cmbOrDel.SelectedIndex].Id);
            else { MessageBox.Show("Выберите заказ из списка"); }
            rebot();
        }
    }
}
