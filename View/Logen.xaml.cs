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
using System.Windows.Shapes;
using BusinessLogicLayer;
using DataAccessLayer.OrderModel;
using DataAccessLayer.SushiModels;

namespace View
{
    /// <summary>
    /// Логика взаимодействия для Logen.xaml
    /// </summary>
    public partial class Logen : Window
    {
        public Logen()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Login button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtUsername.Text != "")
                {
                    OrdersList ol = new OrdersList(txtUsername.Text);
                    MainWindow mainWindow = new MainWindow(ol);
                    mainWindow.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Username is empty");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
