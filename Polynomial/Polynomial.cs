using System;
using System.Text;

namespace Polynomial
{
    public sealed class Polynomial
    {
        private double[] coefficients;
        public Polynomial()
        {
            this.coefficients = new double[1];
        }
        public Polynomial(int maxDegree)
        {
            coefficients = new double[maxDegree];
        }
        public Polynomial(params double[] coefficients)
        {
            this.coefficients = coefficients;
        }
        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            int degree = coefficients.Length - 1;
            foreach (var item in coefficients)
            {
                if (item != 0)
                {
                    if (item > 0)
                    {
                        if (degree == 1)
                        {
                            str.Append($"+{Math.Abs(item)}X");
                        }
                        else if (degree == 0)
                        {
                            str.Append($"+{Math.Abs(item)}");
                        }
                        else
                        {
                            str.Append($"+{Math.Abs(item)}X^{degree}");
                        }
                    }
                    else
                    {
                        if (degree == 1)
                        {
                            str.Append($"+{Math.Abs(item)}X");
                        }
                        else if (degree == 0)
                        {
                            str.Append($"+{Math.Abs(item)}");
                        }
                        else
                        {
                            str.Append($"-{Math.Abs(item)}X^{degree}");
                        }
                    }
                }
                degree--;
            }
            string result = str.ToString();
            if (result.StartsWith("+"))
            {
                result = result.Substring(1);
            }
            return result;
        }
        public override bool Equals(object obj)
        {
            var temp = obj as Polynomial;
            for (int i = 0; i < this.coefficients.Length; i++)
            {
                if (this.coefficients[i] != temp.coefficients[i])
                {
                    return false;
                }
            }
            return true;
        }
        public override int GetHashCode()
        {
            int hash = 0;
            foreach (var item in coefficients)
            {
                hash ^= item.GetHashCode();
            }
            return base.GetHashCode();
        }
        public double this[int index]
        {
            get
            {
                if (index < 0 || index >= coefficients.Length)
                {
                    throw new ArgumentOutOfRangeException();
                }
                return coefficients[index];
            }
            set
            {
                if (index < 0 || index >= coefficients.Length)
                {
                    throw new ArgumentOutOfRangeException();
                }
                coefficients[index] = value;
            }
        }
        public static Polynomial operator +(Polynomial first, Polynomial second)
        {
            var maxDegree = 0;
            var Length = 0;
            Polynomial result;
            Polynomial min;
            if (first.coefficients.Length <= second.coefficients.Length)
            {
                maxDegree = first.coefficients.Length;
                Length = second.coefficients.Length;
                result = second.MemberwiseClone() as Polynomial;
                min = first;
            }
            else
            {
                maxDegree = second.coefficients.Length;
                Length = first.coefficients.Length;
                result = first.MemberwiseClone() as Polynomial;
                min = second;
            }

            for (int i = Length - maxDegree, j = 0; i < Length; i++, j++)
            {
                result[i] += min[j];
            }
            return result;
        }
        public static Polynomial operator -(Polynomial first, Polynomial second)
        {
            return first + (-1) * second;
        }
        public static Polynomial operator *(double number, Polynomial polynomial)
        {
            var result = polynomial.MemberwiseClone() as Polynomial;
            for (int i = 0; i < polynomial.coefficients.Length; i++)
            {
                polynomial[i] *= number;
            }
            return result;
        }
        public static Polynomial operator *(Polynomial polynomial, double number)
        {
            var result = polynomial.MemberwiseClone() as Polynomial;
            for (int i = 0; i < polynomial.coefficients.Length; i++)
            {
                polynomial[i] *= number;
            }
            return result;
        }
        public static Polynomial operator *(Polynomial first, Polynomial second)
        {
            var result = new Polynomial(first.coefficients.Length + second.coefficients.Length - 1);
            for (int i = 0; i < first.coefficients.Length; i++)
            {
                for (int j = 0; j < second.coefficients.Length; j++)
                {
                    result.coefficients[i + j] += (first.coefficients[i] * second.coefficients[j]);
                }
            }
            return result;
        }
    }
}
