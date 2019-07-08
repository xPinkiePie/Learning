using System;
using System.IO;
using System.Globalization;

//23.8976,12.3218 25.7639,11.9463 24.8293,12.2134

namespace Black
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите текст:\n");
            string line = Console.ReadLine();

            line = line.Replace(' ', ',');

            Console.WriteLine("\n");
            Console.WriteLine(line);

            string[] Black = line.Split(',');

            for (int j = 0; j < Black.Length; j++)
            {
                Console.WriteLine("\n {0}:  {1}", j, Black[j]);
            }
            Console.WriteLine("\n");
 
            double[] Pink = new double[Black.Length];

            using (FileStream fstream = new FileStream(@"C:\Users\icc\Desktop\Black.txt", FileMode.Create))

            {
                byte[] array = System.Text.Encoding.Default.GetBytes(line);
                fstream.Write(array, 0, array.Length);
                Console.WriteLine("Текст записан в файл!\n");
            }
            for (int j = 0; j < Black.Length; j += 2)
            {
                Pink[j] = double.Parse(Black[j], CultureInfo.GetCultureInfo("en-US"));
                Pink[j + 1] = double.Parse(Black[j + 1], CultureInfo.GetCultureInfo("en-US"));
                Console.WriteLine($"X:  {Pink[j].ToString(CultureInfo.GetCultureInfo("ru-RU"))}\t  Y:  {Pink[j+1].ToString(CultureInfo.GetCultureInfo("ru-RU"))}\n", Pink[j], Pink[j + 1]);
            }
            Console.ReadLine();
        }
    }
}