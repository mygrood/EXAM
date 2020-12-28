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
using System.IO;


namespace EXAM.pages
{
    /// <summary>
    /// Логика взаимодействия для mainPage.xaml
    /// </summary>
    public partial class mainPage : Page
    {
        int R0, R1, R2, R3;
        
        public mainPage()
        {
            InitializeComponent();
        }

        private void btnWriteFile_Click(object sender, RoutedEventArgs e)
        {
            string result = Microsoft.VisualBasic.Interaction.InputBox("Введите путь к файлу:");
            if (File.Exists(result) == false)
            {
                MessageBox.Show("Файл не существует");
            }
            else
            {
                int k = txbCodeInput.LineCount;
                StreamWriter sr = new StreamWriter(result);
                for (int i = 0; i < k; i++)
                {
                    string l = txbCodeInput.GetLineText(i);
                    sr.WriteLine(l);

                }
                sr.Close();
            }
           
        }

        private void btnCheck_Click(object sender, RoutedEventArgs e)
        {
            int k=txbCodeInput.LineCount;
           List <string> lines = new List<string>();
            for (int i = 0; i < k; i++)
            {
                string l= txbCodeInput.GetLineText(i);
                lines.Add(l);
            }

            compileCode(lines);
        }

        private void compileCode(List<string> list)
        {
            try
            {
                string[] line = new string[2];
                string[] reg = new string[2];
                foreach (var i in list)
                {
                    line = i.Split(' ').ToArray();
                    reg = line[1].Split(',').ToArray();

                }
                MessageBox.Show("Что-то пошло не так,увы!");
            }
            catch (Exception)
            {
                MessageBox.Show("Что-то пошло не так! Проверьте правильность ввода.");
                return;
            }
        }

        private void btnFile_Click(object sender, RoutedEventArgs e)
        {
            string result= Microsoft.VisualBasic.Interaction.InputBox("Введите путь к файлу:");
            if (File.Exists(result) == false)
            {
                MessageBox.Show("Файл не существует");                
            }
            else
            {
                StreamReader sr = new StreamReader(result);
                string line;
                while (!sr.EndOfStream)
                {
                    line = sr.ReadLine();
                    txbCodeInput.AppendText(line);
                }
                sr.Close();
            }
            
           
            
        }
    }
    }

