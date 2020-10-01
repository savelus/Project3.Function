using System;
using System.Security.Cryptography.X509Certificates;

namespace Project_3._Function
{
    class Program
    {
        static double Func (double x)
        {
            return (x*x+5*x+4);
        }
        static int Lenght (double x)
        {
            string col = x.ToString();
            int lenx = col.Length;
            return lenx;
        }
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Введите минимальный х: ");
                double minx = double.Parse(Console.ReadLine());
                Console.WriteLine("Введите максимальный х: ");
                double maxx = double.Parse(Console.ReadLine());
                Console.WriteLine("Введите шаг изменения: ");

                double stepx = double.Parse(Console.ReadLine());
                int count = (int) (Math.Abs(maxx - minx) / stepx);
                double[,] function = new double[4, count];
                
                int maxlenx = 1, maxleny = 1;
                for (int i = 0; i < count; i++)
                {
                    function[0, i] = minx;
                    function[1, i] = Math.Round(Func(minx), 5);
                    function[2, i] = Lenght(function[0, i]);
                    function[3, i] = Lenght(function[1, i]);
                    if (function[2, i] > maxlenx)
                    { maxlenx = (int)function[2, i]; }
                    if (function[3, i] > maxleny)
                    { maxleny = (int)function[3, i]; }
                    minx += stepx;
                }
                
                
                Console.WriteLine($"| {new string (' ', ((maxlenx-1)/2))}" +
                    $" x {new string(' ', (maxlenx - 1 - (maxlenx - 1) / 2))} |" +
                    $"{new string(' ', ((maxleny - 1) / 2))} y" +
                    $" {new string(' ', (maxleny - 1 - (maxleny - 1) / 2))} |");
               
                for (int i = 0; i < count; i++)
                {
                    int spacex = (maxlenx - (int)function[2, i]) / 2;
                    int spacey = (maxleny - (int)function[3, i]) / 2;
                    Console.WriteLine($"|  {new string (' ', spacex)} {function[0, i]}" +
                        $"{new string(' ', (maxlenx - (int)function[2, i] - spacex))}" +
                        $" |{new string (' ', spacey)} {function[1,i]}" +
                        $"{new string(' ', (maxleny - (int)function[3, i] - spacey))}  | ");
                }
                
                Console.ReadLine();
                continue;

            }
        }
    }
}
