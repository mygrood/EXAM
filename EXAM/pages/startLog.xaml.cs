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

namespace EXAM.pages
{
    /// <summary>
    /// Логика взаимодействия для startLog.xaml
    /// </summary>
    public partial class startLog : Page
    {
        public startLog()
        {
            InitializeComponent();
        }

        private void btnIn_Click(object sender, RoutedEventArgs e)
        {
            int pass = txbPass.Password.GetHashCode();
            examLog logObj = BaseConnect.BaseModel.examLog.FirstOrDefault(u => (u.login == txbLogin.Text) && u.password == pass);
            if (logObj == null)
            {
                MessageBox.Show("Нет такого пользователя или пароль не верен.");
            }
            else
            {                
                NavigationService.Navigate(new mainPage());
            }
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new newAcc());
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
