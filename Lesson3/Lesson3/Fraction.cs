using System;
using System.Linq;

namespace Lesson3
{
    public class Fraction
    {
        private int numerator;
        private int denominator;
        private int wholePart = 0;

        public int Numerator
        {
            get { return numerator; }
            set { numerator = value; }
        }

        public int Denominator
        {
            get { return denominator; }
            set { this.denominator = value; }
        }

        public double Decimal
        {
            get { return (double)this.numerator/this.denominator; }
        }

        public Fraction(int num, int denum)
        {
            if (denum == 0)
                throw new Exception("Denominator can't be 0");

            if (num > denum) {
                this.wholePart = num / denum;
                this.numerator = num % denum;
            } else
            {
                this.numerator = num;
            }
            
            this.denominator = denum;
        }

        private int getLeastCommonMultiplier(int val1, int val2)
        {
            int greaterVal = val1 > val2 ? val1 : val2;

            while (true)
            {
                if (greaterVal % val1 == 0 && greaterVal % val2 == 0)
                    return greaterVal;

                greaterVal++;
            }
        }

        private int getLowestCommonDivisor(int val1, int val2)
        {
            if (val2 == 0)
            {
                return val1;
            }

            return getLowestCommonDivisor(val2, val1 % val2);
        }

        public Fraction Plus(Fraction f)
        {
            if (this.denominator == f.Denominator)
            {
                return new Fraction(this.numerator + f.Numerator, this.denominator);
            } else
            {
                int lcm = getLeastCommonMultiplier(this.denominator, f.Denominator);
                int firstMultiplier = lcm / this.denominator;
                int secondMultiplier = lcm / f.Denominator;

                return new Fraction(this.numerator * firstMultiplier + f.Numerator * secondMultiplier, this.denominator * firstMultiplier);
            }
        }

        public Fraction Subtract(Fraction f)
        {
            if (this.denominator == f.Denominator)
            {
                return new Fraction(this.numerator - f.Numerator, this.denominator);
            }
            else
            {
                int lcm = getLeastCommonMultiplier(this.denominator, f.Denominator);
                int firstMultiplier = lcm / this.denominator;
                int secondMultiplier = lcm / f.Denominator;

                return new Fraction(this.numerator * firstMultiplier - f.Numerator * secondMultiplier, this.denominator * firstMultiplier);
            }
        }

        public Fraction Multiply(Fraction f)
        {
            return new Fraction(this.numerator * f.Numerator, this.denominator * f.Denominator);
        }

        public Fraction DivideBy(Fraction f)
        {
            return new Fraction(this.numerator * f.Denominator, this.denominator * f.Numerator);
        }

        public override string ToString()
        {
            if (numerator == 0)
                return "0";

            if (numerator == denominator)
                return "1";

            // Выделяем целую часть
            string whole = "";
            if (wholePart != 0)
                whole = $"{wholePart}";

            //Сокращение дробей
            int lcd = getLowestCommonDivisor(this.numerator, this.denominator);
            if (lcd != 1)
            {
                Numerator = this.numerator / lcd;
                Denominator = this.denominator / lcd;
            }

            return string.Format("{0}{1}/{2}", whole, numerator, denominator);
        }
    }
}
