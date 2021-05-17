using System;
namespace Lesson3
{
    /// <summary>
    /// Структура Complex описывает и предоставляет методы для работы с комплексными числами
    /// </summary>
    public struct ComplexStruct
    {
        /// <summary>
        /// Мнимая часть комплексного числа
        /// </summary>
        public double im;

        /// <summary>
        /// Действительная часть комплексного числа
        /// </summary>
        public double re;

        /// <summary>
        /// Сложение комплексных чисел
        /// </summary>
        /// <param name="x">Второе комплексное число</param>
        /// <returns>Результат сложения (Комплексное число)</returns>
        public ComplexStruct Add(ComplexStruct x)
        {
            ComplexStruct y;
            y.im = im + x.im;
            y.re = re + x.re;
            return y;
        }

        /// <summary>
        /// Вычитание комплексных чисел
        /// </summary>
        /// <param name="x">Второе комплексное число</param>
        /// <returns>Результат вычитания (Комплексное число)</returns>
        public ComplexStruct Subtract(ComplexStruct x)
        {
            ComplexStruct y;
            y.im = im - x.im;
            y.re = re - x.re;
            return y;
        }

        public override string ToString()
        {
            return $"{re} + {im}i";
        }

    }
}

