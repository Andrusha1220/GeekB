using System;
using System.Linq;

namespace Lesson2
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            chooseTask();
        }

        static void chooseTask()
        {
            Console.Write("Enter task number from 1 to 7 or 0 to quit: ");
            int task = int.Parse(Console.ReadLine());

            openTask(task);
        }

        static void openTask(int task)
        {
            switch (task)
            {
                case 1:
                    openTask1();
                    break;
                case 2:
                    openTask2();
                    break;
                case 3:
                    openTask3();
                    break;
                case 4:
                    openTask4();
                    break;
                case 5:
                    openTask5();
                    break;
                case 6:
                    openTask6();
                    break;
                case 7:
                    openTask7();
                    break;
                default:
                    break;

            }
        }

        static void switchTask()
        {
            Console.WriteLine("Push Enter to continue");
            Console.ReadLine();
        }

        static void openTask1()
        {
            //1.Написать метод, возвращающий минимальное из трёх чисел.

            Console.WriteLine(findMinValue(3, 3, 4));
            switchTask();
            chooseTask();
        }

        static void openTask2()
        {
            // 2. Написать метод подсчета количества цифр числа.

            Console.WriteLine(countDigits(0));
            Console.WriteLine(countDigits(10));
            Console.WriteLine(countDigits(200));

            switchTask();
            chooseTask();
        }

        static void openTask3()
        {
            //3.С клавиатуры вводятся числа, пока не будет введен 0.Подсчитать сумму всех нечетных положительных чисел.
            int x;
            int sum = 0;
            do
            {
                Console.Write("Введите числа от 0 до 9: ");
                x = int.Parse(Console.ReadLine());
                Console.WriteLine($"Вы ввели {x}");
                if (x % 2 != 0 && x > 0)
                {
                    sum += x;
                }
            }
            while (x != 0);
            Console.WriteLine($"Сумма всех нечетных положительных чисел: {sum}");

            switchTask();
            chooseTask();
        }

        static void openTask4()
        {
            //4.Реализовать метод проверки логина и пароля.На вход метода подается логин и пароль.
            //На выходе истина, если прошел авторизацию, и ложь, если не прошел(Логин: root, Password: GeekBrains).
            //Используя метод проверки логина и пароля, написать программу: пользователь вводит логин и пароль, программа пропускает его дальше или не пропускает.
            //С помощью цикла do while ограничить ввод пароля тремя попытками.

            int attemptsCount = 3;
            string correctLogin = "root";
            string correctPswd = "GeekBrains";

            do
            {
                Console.Write("Введите логин: ");
                string login = Convert.ToString(Console.ReadLine());
                Console.Write("Введите пароль: ");
                string pswd = Convert.ToString(Console.ReadLine());

                if (login == correctLogin && pswd == correctPswd)
                {
                    Console.WriteLine($"Добро пожаловать! Вы успешно вошли в систему!");
                    break;
                }
                else
                {
                    attemptsCount--;
                    if (attemptsCount != 0)
                    {
                        Console.WriteLine($"Неверный логин или пароль. Осталось {attemptsCount} попыток: ");
                    }
                    else
                    {
                        Console.WriteLine($"Неверный логин или пароль. У вас не осталось попыток ввода");
                    }
                }

            } while (attemptsCount != 0);

            switchTask();
            chooseTask();
        }

        static void openTask5()
        {
            //а) Написать программу, которая запрашивает массу и рост человека, вычисляет его индекс массы и сообщает, нужно ли человеку похудеть, набрать вес или всё в норме.
            //б) *Рсчитать, на сколько кг похудеть или сколько кг набрать для нормализации веса.

            //I = m / (h * h);

            Console.Write("Введите ваш вес: ");
            double w = Convert.ToDouble(Console.ReadLine());

            Console.Write("Введите ваш рост: ");
            double h = Convert.ToDouble(Console.ReadLine());

            double wIndex = weightIndex(w, h);

            Console.WriteLine($"Индекс массы вашего тела ${wIndex:F2}");

            if (wIndex < 18.5)
            {
                Console.WriteLine("У вас недостаток массы тела");
                giveAdvice(wIndex);
            }
            else if (wIndex >= 18.6 && wIndex <= 25)
            {
                Console.WriteLine("Масса вашего тела в пределах нормы");

            }
            else if (wIndex >= 25.1 && wIndex <= 30)
            {
                Console.WriteLine("Существует избыток массы вашего тела");
                giveAdvice(wIndex);

            }
            else
            {
                Console.WriteLine("Ожирение");
                giveAdvice(wIndex);
            }

            switchTask();
            chooseTask();
        }

        static void openTask6()
        {
            int goodNumbersCount = 0;
            int i = 1;
            DateTime startedAt = DateTime.Now;


            while (i <= 1000000000)
            {
                int digitsSum = Convert.ToString(i).Length;
                if (i % digitsSum == 0)
                {
                    Console.WriteLine(i);
                    goodNumbersCount++;
                }
                i++;
            }
            DateTime finishedAt = DateTime.Now;

            Console.WriteLine($"goodNumbersCount: {goodNumbersCount}");
            Console.WriteLine($"Time passed: {finishedAt.Subtract(startedAt).TotalMilliseconds} ms");

            switchTask();
            chooseTask();
        }

        static void openTask7()
        {
            //a) Разработать рекурсивный метод, который выводит на экран числа от a до b(a < b).
            //б) *Разработать рекурсивный метод, который считает сумму чисел от a до b.

            writeNumbersRecursivelyA(1, 100);
            writeNumbersRecursivelyB(1, 100);

            switchTask();
            chooseTask();
        }

        static double weightIndex(double weight, double height)
        {
            return height / (weight * weight);
        }

        static int findMinValue(int x, int y, int z)
        {
            int min = x < y ? x : y;
            return z < min ? z : min;
        }

        static int countDigits(int x)
        {
            //return Convert.ToString(x).Length;

            int count = 0;
            string numberStr = Convert.ToString(x);

            // Способ 1:
            //for (int i = 1; i <= numberStr.Length; i++) {
            //    count++;
            //}

            // Способ 2:
            foreach (char i in numberStr) {
                count++;
            }

            return count;
        }

        static void giveAdvice(double wIndex)
        {
            if (wIndex < 18.6)
            {
                Console.WriteLine($"Для нормализации массы тела Вам следует набрать {(18.6 - wIndex):F2} килограм");
                return;
            }

            if (wIndex > 25)
            {
                Console.WriteLine($"Для нормализации массы тела Вам следует сбросить {(wIndex - (wIndex - 25)):F2} килограм");
                return;
            }
        }

        static void writeNumbersRecursivelyA(int a, int b)
        {
            
            Console.WriteLine(a);

            if (a < b)
            {
                writeNumbersRecursivelyA(a + 1, b);
            }
        }

        static int writeNumbersRecursivelyB(int a, int b)
        {
            int result = 0;
            if (b == 0)
            {
                return (a);
            }
            else
            {
                result = writeNumbersRecursivelyB(a + 1, b - 1);
            }
            return result;
        }
    }
}
