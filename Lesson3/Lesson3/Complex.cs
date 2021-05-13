using System;
namespace Lesson3
{
    public class Complex
    {
        private double im;
        private double re;

        public Complex(double im, double re)
        {
            this.im = im;
            this.re = re;
        }

        public double Im
        {
            get { return im; }
            set
            {
                if (value == 0)
                    throw new Exception("Can't assign 0");
                im = value;
            }
        }

        public double Re
        {
            get { return re; }
            set { re = value; }
        }

        public Complex Add(Complex x)
        {
            Complex y = new Complex(this.im + x.im, this.re + x.re);
            return y;
        }

        public Complex Subtract(Complex x)
        {
            Complex y = new Complex(this.im - x.im, this.re - x.re);
            return y;
        }

        public Complex Multiply(Complex x)
        {
            Complex y = new Complex(this.im * x.im, this.re * x.re);
            return y;
        }

        public override string ToString()
        {
            return $"{re} + {im}i";
        }
    }
}
