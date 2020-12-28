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
    /// Логика взаимодействия для newAcc.xaml
    /// </summary>
    public partial class newAcc : Page
    {
        public newAcc()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new startLog());
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            examLog logObj = BaseConnect.BaseModel.examLog.FirstOrDefault(u => u.login == txbLogin.Text);
            if (logObj != null)
            {
                MessageBoxResult result = MessageBox.Show("Пользователь с этим логином уже существует. Хотите войти в систему?", "", MessageBoxButton.YesNo);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        NavigationService.Navigate(new startLog());
                        break;
                    case MessageBoxResult.No:
                        break;

                }
            }
            else
            {

                if (txbPass.Password == txbPass2.Password)
                {
                    examLog logNewObj = new examLog()
                    {
                        login = txbLogin.Text,
                        password = txbPass.Password.GetHashCode(),

                    };
                    BaseConnect.BaseModel.examLog.Add(logNewObj);

                    BaseConnect.BaseModel.SaveChanges();
                    MessageBox.Show("Регистрация пройдена, ура! А теперь войдите!");
                    NavigationService.Navigate(new startLog());
                }
                else
                {
                    MessageBox.Show("Пароли не совпадают.");
                    txbPass.Password = null;
                    txbPass2.Password = null;
                }              


            }



        }
    }
}
