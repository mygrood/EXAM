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
    /// Логика взаимодействия для edit.xaml
    /// </summary>
    public partial class edit : Page
    {
        public edit()
        {
            InitializeComponent();
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            examLog logObj = BaseConnect.BaseModel.examLog.FirstOrDefault(u => (u.login == txbLogin.Text) || u.idWho == Convert.ToInt32(txbLogin.Text));
            if (logObj == null)
            {
                MessageBox.Show("Пользователь не найден");
            }
            else
            {
                BaseConnect.BaseModel.examLog.Remove(logObj);
                BaseConnect.BaseModel.SaveChanges();
            }


        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            if (cmb1.SelectedIndex != -1&& txbNew.Text!=null)
            {
                examLog logObj = BaseConnect.BaseModel.examLog.FirstOrDefault(u => (u.login == txbLogin.Text) || u.idWho == Convert.ToInt32(txbLogin.Text));
                if (logObj == null)
                {
                    MessageBox.Show("Пользователь не найден");
                }
                else
                {
                    int k = -1;
                    switch (k)
                    {
                        case 0:
                            logObj.login = txbNew.Text;
                            break;
                        case 1:
                            logObj.password = txbNew.Text.GetHashCode();
                            break;
                        default:
                            break;
                    }
                    BaseConnect.BaseModel.SaveChanges();
                }
            }
            else 
            {
                MessageBox.Show("Заполните все поля");
            }

           
        }
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new startLog());
        }
    }
}
