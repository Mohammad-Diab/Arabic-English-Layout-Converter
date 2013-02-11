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
            MessageBox.Show("Done", "Convert", MessageBoxButton.OK, MessageBoxImage.Information);
            TextBox2.Text = tmp;
        }

        private void English()
        {
            tmp = tmp.Replace('a', 'ش');
            if (tmp.Contains('b'))
                swap('b', "لا");
            tmp = tmp.Replace('c', 'ؤ');
            tmp = tmp.Replace('d', 'ي');
            tmp = tmp.Replace('e', 'ث');
            tmp = tmp.Replace('f', 'ب');
            tmp = tmp.Replace('g', 'ل');
            tmp = tmp.Replace('h', 'ا');
            tmp = tmp.Replace('i', 'ه');
            tmp = tmp.Replace('j', 'ت');
            tmp = tmp.Replace('k', 'ن');
            tmp = tmp.Replace('l', 'م');
            tmp = tmp.Replace('m', 'ة');
            tmp = tmp.Replace('n', 'ى');
            tmp = tmp.Replace('o', 'خ');
            tmp = tmp.Replace('p', 'ح');
            tmp = tmp.Replace('q', 'ض');
            tmp = tmp.Replace('r', 'ق');
            tmp = tmp.Replace('s', 'س');
            tmp = tmp.Replace('t', 'ف');
            tmp = tmp.Replace('u', 'ع');
            tmp = tmp.Replace('v', 'ر');
            tmp = tmp.Replace('w', 'ص');
            tmp = tmp.Replace('x', 'ء');
            tmp = tmp.Replace('y', 'غ');
            tmp = tmp.Replace('z', 'ئ');
            tmp = tmp.Replace('A', 'ِ');
            if (tmp.Contains('B'))
                swap('B', "لآ");
            tmp = tmp.Replace('C', '}');
            tmp = tmp.Replace('D', ']');
            tmp = tmp.Replace('E', 'ُ');
            tmp = tmp.Replace('F', '[');
            if (tmp.Contains('G'))
                swap('G', "لأ");
            tmp = tmp.Replace('H', 'أ');
            tmp = tmp.Replace('I', '÷');
            tmp = tmp.Replace('J', 'ـ');
            tmp = tmp.Replace('K', '،');
            tmp = tmp.Replace('L', '/');
            tmp = tmp.Replace('M', '’');
            tmp = tmp.Replace('N', 'آ');
            tmp = tmp.Replace('O', '×');
            tmp = tmp.Replace('P', '؛');
            tmp = tmp.Replace('Q', 'َ');
            tmp = tmp.Replace('R', 'ٌ');
            tmp = tmp.Replace('S', 'ٍ');
            if (tmp.Contains('T'))
                swap('T', "لإ");
            tmp = tmp.Replace('U', '‘');
            tmp = tmp.Replace('V', '{');
            tmp = tmp.Replace('W', 'ً');
            tmp = tmp.Replace('X', 'ْ');
            tmp = tmp.Replace('Y', 'إ');
            tmp = tmp.Replace('Z', '~');
            tmp = tmp.Replace('[', 'ج');
            tmp = tmp.Replace(']', 'د');
            tmp = tmp.Replace(';', 'ك');
            tmp = tmp.Replace('\'', 'ط');
            tmp = tmp.Replace(',', 'و');
            tmp = tmp.Replace('.', 'ز');
            tmp = tmp.Replace('/', 'ظ');
            tmp = tmp.Replace('{', '<');
            tmp = tmp.Replace('}', '>');
            tmp = tmp.Replace(':', ':');
            tmp = tmp.Replace('"', '"');
            tmp = tmp.Replace('<', ',');
            tmp = tmp.Replace('>', '.');
            tmp = tmp.Replace('?', '؟');
            tmp = tmp.Replace('`', 'ذ');
            tmp = tmp.Replace('~', 'ّ');
        }

        private void Arabic()
        {
            tmp = tmp.Replace('ش', 'a');
            if (tmp.Contains('b'))
                swap('ا','b');
            tmp = tmp.Replace('ؤ', 'c');
            tmp = tmp.Replace('ي', 'd');
            tmp = tmp.Replace('ث', 'e');
            tmp = tmp.Replace('ب', 'f');
            tmp = tmp.Replace('ل', 'g');
            tmp = tmp.Replace('ا', 'h');
            tmp = tmp.Replace('ه', 'i');
            tmp = tmp.Replace('ت', 'j');
            tmp = tmp.Replace('ن', 'k');
            tmp = tmp.Replace('م', 'l');
            tmp = tmp.Replace('ة', 'm');
            tmp = tmp.Replace('ى', 'n');
            tmp = tmp.Replace('خ', 'o');
            tmp = tmp.Replace('ح', 'p');
            tmp = tmp.Replace('ض', 'q');
            tmp = tmp.Replace('ق', 'r');
            tmp = tmp.Replace('س', 's');
            tmp = tmp.Replace('ف', 't');
            tmp = tmp.Replace('ع', 'u');
            tmp = tmp.Replace('ر', 'v');
            tmp = tmp.Replace('ص', 'w');
            tmp = tmp.Replace('ء', 'x');
            tmp = tmp.Replace('غ', 'y');
            tmp = tmp.Replace('ئ', 'z');
            tmp = tmp.Replace('ِ', 'A');
            if (tmp.Contains('B'))
                swap('آ','B');
            tmp = tmp.Replace('}', 'C');
            tmp = tmp.Replace(']', 'D');
            tmp = tmp.Replace('ُ', 'E');
            tmp = tmp.Replace('[', 'F');
            if (tmp.Contains('G'))
                swap('أ','G');
            tmp = tmp.Replace('أ', 'H');
            tmp = tmp.Replace('÷', 'I');
            tmp = tmp.Replace('ـ', 'J');
            tmp = tmp.Replace('،', 'K');
            tmp = tmp.Replace('/', 'L');
            tmp = tmp.Replace('’', 'M');
            tmp = tmp.Replace('آ', 'N');
            tmp = tmp.Replace('×', 'O');
            tmp = tmp.Replace('؛', 'P');
            tmp = tmp.Replace('َ', 'Q');
            tmp = tmp.Replace('ٌ', 'R');
            tmp = tmp.Replace('ٍ', 'S');
            if (tmp.Contains('T'))
                swap('إ','T');
            tmp = tmp.Replace('‘', 'U');
            tmp = tmp.Replace('{', 'V');
            tmp = tmp.Replace('ً', 'W');
            tmp = tmp.Replace('ْ', 'X');
            tmp = tmp.Replace('إ', 'Y');
            tmp = tmp.Replace('~', 'Z');
            tmp = tmp.Replace('ج', '[');
            tmp = tmp.Replace('د', ']');
            tmp = tmp.Replace('ك', ';');
            tmp = tmp.Replace('ط', '\'');
            tmp = tmp.Replace('و', ',');
            tmp = tmp.Replace('ز', '.');
            tmp = tmp.Replace('ظ', '/');
            tmp = tmp.Replace('<', '{');
            tmp = tmp.Replace('>', '}');
            tmp = tmp.Replace(':', ':');
            tmp = tmp.Replace('"', '"');
            tmp = tmp.Replace(',', '<');
            tmp = tmp.Replace('.', '>');
            tmp = tmp.Replace('؟', '?');
            tmp = tmp.Replace('ذ', '`');
            tmp = tmp.Replace('ّ', '~');
        }

        private void Capital()
        {
            tmp = tmp.ToUpper();
        }

        private void Small()
        {
            tmp = tmp.ToLower();
        }

        private void swap(char old, string New)
        {
            string[] str = tmp.Split(old);
            tmp = null;
            for (int i = 0; i < str.Length - 1; i++)
                tmp = String.Concat(tmp, str[i], New);
            tmp = String.Concat(tmp, str[str.Length - 1]);
        }

        private void swap(char old, char New)
        {
            string[] str = tmp.Split('ل');
            tmp = null;
            for (int i = 0; i < str.Length; i++)
                if (str[i].Length > 0 && str[i][0].Equals(old))
                    str[i].Remove(0, 1);
            for (int i = 0; i < str.Length - 1; i++)
                tmp = String.Concat(tmp, str[i], New);
            tmp = String.Concat(tmp, str[str.Length - 1]);
        }

    }
}
