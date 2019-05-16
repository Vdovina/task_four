using System;

namespace task_four
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Уравнение:   x^5 - x - 0,2 = 0\nИнтервал: [ 1; 1,1 ]\n");
            Console.ResetColor();
            Console.WriteLine("Введите е:");
            double e = EnterANumber();

            Console.WriteLine("Корень уравнения: " + IntervalMethod(e, 1, 1.1));
            Console.ReadLine();
        }

        static double EnterANumber() //ввод числа
        {
            bool ok = false;
            double number = 0;
            do
            {
                Console.Write("Ввод:   ");
                try
                {
                    number = Convert.ToDouble(Console.ReadLine());
                    if (number == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Введите е, отличное от 0.");
                        Console.ResetColor();
                    }
                    else ok = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Введите действительное число!");
                }
            } while (!ok);
            return number;
        }

        static double IntervalMethod(double e, double a, double b) // метод интервалов
        {
            double x = 0;
            while (Math.Abs(a - b) > e) // пока разница между границами рассматриваемого интервала больше заданного е
            {
                x = (a + b) / 2; // найти середину отрезка
                if (Function(a) * Function(x) < 0) b = x; // если функция на первой половине меняет знак, то рассматривается только она
                else if (Function(x) * Function(b) < 0) a = x; // иначе рассматривается вторая половина отрезка
            }
            return x;
        }

        static double Function(double x) // функция
        {
            return Math.Pow(x, 5) - x - 0.2;
        }
    }
}
