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
using BusinessLogicLayer;
using DataAccessLayer.OrderModel;
using DataAccessLayer.SushiModels;

namespace View
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public OrdersList Orders { get; set; }
        public List<Order> taken { get; set; }
        public int doneOrders;

        public MainWindow()
        {
            InitializeComponent();
        }

        public MainWindow(OrdersList orders)
        {
            InitializeComponent();
            this.doneOrders = 0;
            this.Salary.Content = String.Format($"{0:C}");
            this.Orders = orders;
            this.cookLabel.Content = String.Format("A cook:");
            this.acook.Content = this.Orders.CookName;
            this.Orders.OpenFromFile();
            foreach(Order elem in this.Orders.orders)
            {
                sushiDataGrid.Items.Add(elem);
            }
        }

        private void AddColumns()
        {
            DataGridTextColumn nameColumn = new DataGridTextColumn();
            nameColumn.Header = "Order name";
            this.sushiDataGrid.Columns.Add(nameColumn);

            DataGridTextColumn sushi = new DataGridTextColumn();
            sushi.Header = "Sushis";
            this.sushiDataGrid.Columns.Add(sushi);

            DataGridTextColumn dateTime = new DataGridTextColumn();
            sushi.Header = "Date";
            this.sushiDataGrid.Columns.Add(dateTime);
        }

        private void TakeOrderButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                String orderName = (sushiDataGrid.SelectedItem as Order).Name;
                int index = Int32.Parse(orderName[orderName.Length - 2].ToString());

                this.Orders.orders[index - 1].IsTaken = true;
                this.sushiDataGrid.Items.Clear();
                this.takenDataGrid.Items.Clear();

                foreach(Order elem in this.Orders.orders)
                {
                    if(elem.IsTaken == false && elem.IsReady == false)
                    {
                        sushiDataGrid.Items.Add(elem);
                    }
                    else if(elem.IsTaken == true && elem.IsReady == false)
                    {
                        takenDataGrid.Items.Add(elem);
                    }
                }

                //Order curr = sushiDataGrid.SelectedItem as Order;
                //curr.IsTaken = true;

                //this.taken.Add(curr);
                //sushiDataGrid.Items.Remove(sushiDataGrid.SelectedItem);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void ReadyOrderButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                String orderName = (takenDataGrid.SelectedItem as Order).Name;
                int index = Int32.Parse(orderName[orderName.Length - 2].ToString());

                this.Orders.orders[index - 1].IsReady = true;
                this.takenDataGrid.Items.Clear();
                this.sushiDataGrid.Items.Clear();

                foreach (Order elem in this.Orders.orders)
                {
                    if (elem.IsReady == false && elem.IsTaken == false)
                    {
                        sushiDataGrid.Items.Add(elem);
                    }
                    else if(elem.IsReady == false && elem.IsTaken == true)
                    {
                        takenDataGrid.Items.Add(elem);
                    }
                }

                this.doneOrders += 1;
                string content = this.Salary.Content.ToString();
                int newSalary = Int32.Parse(content, System.Globalization.NumberStyles.Any) + 1000000;
                this.Salary.Content = String.Format($"{newSalary:C}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool isSuccesful = false;
            if (doneOrders == 0)
            {
                MessageBox.Show($"You did nothing!");
                return;
            }
            foreach(Order elem in this.Orders.orders)
            {
                if(elem.IsTaken == true && elem.IsReady == false)
                {
                    MessageBox.Show($"Finish your job!");
                    return;
                }
            }
            MessageBox.Show($"The restaurant is stuck in debt and ruined.");
            this.Close();
        }
    }
}
