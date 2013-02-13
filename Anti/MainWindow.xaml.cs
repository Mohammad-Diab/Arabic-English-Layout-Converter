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

namespace Anti
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string tmp;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            tmp = TextBox1.Text;
            if (RadioButton1.IsChecked == true)
                English();
            else if (RadioButton2.IsChecked == true)
                Arabic();
            else if (RadioButton3.IsChecked == true)
                Capital();
            else if (RadioButton4.IsChecked == true)
                Small();
            TextBox2.Text = tmp;
        }

        private void English()
        {
            tmp = Layout.ToArabic(tmp);
        }

        private void Arabic()
        {
            tmp = Layout.ToEnglish(tmp);
        }

        private void Capital()
        {
            tmp = tmp.ToUpper();
        }

        private void Small()
        {
            tmp = tmp.ToLower();
        }
    }
}
