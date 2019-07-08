using System.Windows;
using System.IO;
using System.Globalization;

namespace WPFpink
{
    public partial class MainWindow : Window
    {
        string Sun = "Black.txt";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button1Button_Click(object sender, RoutedEventArgs e)
        {

            string line = textBox1.Text;

            if (line != "")
            {

                line = line.Replace(' ', ',');
                MessageBox.Show("Сохранено...");
                File.WriteAllText(Sun, line);
            }

        }
        private void button2Button_Click(object sender, RoutedEventArgs e)
        { 
            using (FileStream fstream = File.OpenRead(@"C:\Users\icc\source\repos\WPFpink\WPFpink\bin\Debug\Black.txt"))
            {
                var Run = File.ReadAllText(Sun);

                string[] Black = Run.Split(',');

                NumberFormatInfo numberFormatInfo = new NumberFormatInfo()
                {
                    NumberDecimalSeparator = ",",
                };

                double[] Pink = new double[Black.Length];

                for (int j = 0; j < Black.Length; j += 2)
                {
                    Pink[j] = double.Parse(Black[j], CultureInfo.GetCultureInfo("en-US"));
                    Pink[j + 1] = double.Parse(Black[j + 1], CultureInfo.GetCultureInfo("en-US"));
                    txt.Text += $"X:  {Pink[j].ToString(CultureInfo.GetCultureInfo("ru-RU"))}\t  Y:  {Pink[j + 1].ToString(CultureInfo.GetCultureInfo("ru-RU"))}\n";
                }
            }
        }
    }
}