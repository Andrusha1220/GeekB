using System;

namespace Lesson3
{
    class MainClass
    {
        public static void Main(string[] args)
        {   
            selectTask();
        }

        #region Task selection and performance
        static void selectTask()
        {
            Console.Write("Enter task number from 1 to 3 or type 0 to quit: ");
            int taskNumber;
            bool inputResult = int.TryParse(Console.ReadLine(), out taskNumber);

            if (inputResult) {
                if (taskNumber > 3)
                {
                    Console.WriteLine("There are only 3 tasks available. Try again.");
                    selectTask();
                }
                else if (taskNumber == 0)
                {
                    Console.WriteLine("Bye!");
                    Console.ReadLine();
                }
                else
                {
                    openTask(taskNumber);
                }
            } else
            {
                Console.WriteLine("Type Error: Only numbers are acceptable.");
                selectTask();
            }
        }

        static void openTask(int taskNumber)
        {
            switch (taskNumber)
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
                default:
                    break;

            }
        }

        static void openTask1()
        {
            selectSubtask();

            switchTask();
            selectTask();
        }

        static void openTask2()
        {
            Console.WriteLine("2. С клавиатуры вводятся числа, пока не будет введён 0 (каждое число в новой строке). Требуется подсчитать сумму всех нечётных положительных чисел. Сами числа и сумму вывести на экран, используя tryParse.");
            int inputedNumber = 1;
            int sum = 0;

            do
            {
                promtUser();
            }
            while (inputedNumber > 0);

            Console.WriteLine($"Сумма всех нечетных положительных чисел: {sum}");

            void promtUser()
            {
                Console.Write("Введите любое число от 0 до 9: ");
                int x;
                bool parseResult = int.TryParse(Console.ReadLine(), out x);

                if (parseResult)
                {
                    inputedNumber = x;
                    Console.WriteLine($"Вы ввели {x}");
                    if (x % 2 != 0 && x > 0)
                    {
                        sum += x;
                    }
                }
                else
                {
                    Console.Write("Вы ввели недопустимый символ. Попробуйте еще раз");
                    promtUser();
                }

            }

            switchTask();
            selectTask();
        }

        static void openTask3()
        {
            Console.WriteLine("*Описать класс дробей — рациональных чисел, являющихся отношением двух целых чисел. Предусмотреть методы сложения, вычитания, умножения и деления дробей. Написать программу, демонстрирующую все разработанные элементы класса.");  
            Console.WriteLine("Добавить свойства типа int для доступа к числителю и знаменателю;");  
            Console.WriteLine("Добавить свойство типа double только на чтение, чтобы получить десятичную дробь числа;");  
            Console.WriteLine("** Добавить проверку, чтобы знаменатель не равнялся 0. Выбрасывать исключение ArgumentException(\"Знаменатель не может быть равен 0\");");
            Console.WriteLine("*** Добавить упрощение дробей.");

            Fraction fraction1 = new Fraction(4, 16);
            Fraction fraction2 = new Fraction(2, 16);
            Console.WriteLine($"Addition: {fraction1.Plus(fraction2)}");
            Console.WriteLine($"Subtraction: {fraction1.Subtract(fraction2)}");
            Console.WriteLine($"Multiplation: {fraction1.Multiply(fraction2)}");
            Console.WriteLine($"Division: {fraction1.DivideBy(fraction2)}");
            Console.WriteLine($"Decimal notation of {fraction1}: {fraction1.Decimal}");

            switchTask();
            selectTask();
        }
        #endregion


        #region Subtask selection and performance
        static void selectSubtask()
        {
            Console.Write("Enter subtask char (a or b) or put any symbol to quit: ");
            char subtaskChar = Console.ReadLine().ToLower()[0];

            if (subtaskChar == 'a' || subtaskChar == 'b') {
                openSubtask(subtaskChar);
            } else
            {
                selectTask();
            }


        }

        static void openSubtask(char subtaskChar)
        {
            switch (subtaskChar)
            {
                case 'a':
                    openSubtask1A();
                    break;
                case 'b':
                    openSubtask1B();
                    break;
                default:
                    selectTask();
                    break;
            }
        }

        static void openSubtask1A()
        {
            Console.WriteLine("Дописать структуру Complex, добавив метод вычитания комплексных чисел. Продемонстрировать работу структуры.");
            Console.ReadKey();
            Console.WriteLine("Дано: ");
            ComplexStruct complexStr01;
            complexStr01.im = 2;
            complexStr01.re = 3;
            Console.WriteLine($"Комплексное число 1: {complexStr01}");

            ComplexStruct complexStr02;
            complexStr02.im = 3;
            complexStr02.re = 1;
            Console.WriteLine($"Комплексное число 2: {complexStr02}");
            Console.WriteLine($"Применяем метод Subtract...");
            Console.ReadKey();
            ComplexStruct complexStr03 = complexStr01.Subtract(complexStr02);
            Console.WriteLine($"Результат применения метода Subtract с использованием структуры ComplexStruct: {complexStr03}");
            Console.ReadLine();
        }

        static void openSubtask1B()
        {
            Console.WriteLine("Дописать класс Complex, добавив методы вычитания и произведения чисел. Проверить работу класса.");
            Console.ReadKey();
            Console.WriteLine("Дано: ");
            Complex complex01 = new Complex(2, 3);
            Console.WriteLine($"Комплексное число 1: {complex01}");

            Complex complex02 = new Complex(3, 1);
            Console.WriteLine($"Комплексное число 2: {complex02}");
            Console.ReadKey();
            Console.WriteLine($"Применяем метод Subtract...");
            Complex complex03 = complex01.Subtract(complex02);
            Console.WriteLine($"Результат применения метода Subtract с использованием класса Complex: {complex03}");
            Console.ReadKey();

            Console.WriteLine($"Применяем метод Multiply...");
            Complex complex04 = complex01.Multiply(complex02);
            Console.WriteLine($"Результат применения метода Multiply с использованием класса Complex: {complex04}");
            Console.ReadLine();
        }
        #endregion

        static void switchTask()
        {
            Console.WriteLine("Push Enter to continue");
            Console.ReadLine();
        }
    }

    
}
