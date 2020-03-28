using System;
using System.Text;

namespace Polynomials
{
    /// <summary>
    /// Class Polynomial
    /// </summary>
    public sealed class Polynomial
    {
        /// <summary>
        /// Array of coefficients
        /// </summary>
        private double[] coefficients;
        /// <summary>
        /// Constructor without parameters creates a polinomial "0"
        /// </summary>
        public Polynomial()
        {
            this.coefficients = new double[1];
        }
        /// <summary>
        /// Constructor creates polynomial with count = max degree, all coefficient = null 
        /// </summary>
        /// <param name="maxDegree">max degree</param>
        public Polynomial(int maxDegree)
        {
            coefficients = new double[maxDegree];
        }
        /// <summary>
        /// Constructor creates polynome with coefficients array
        /// </summary>
        /// <param name="coefficients"></param>
        public Polynomial(params double[] coefficients)
        {
            foreach (var item in coefficients)
            {
                if (Double.IsNaN(item) || Double.IsInfinity(item))
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
            this.coefficients = coefficients;
        }
        /// <summary>
        /// Returns polynomial as math formule view
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            int degree = this.Length - 1;
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
                            str.Append($"-{Math.Abs(item)}X");
                        }
                        else if (degree == 0)
                        {
                            str.Append($"-{Math.Abs(item)}");
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
        /// <summary>
        /// Returns true ifpolynomial equals
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            var temp = obj as Polynomial;
            for (int i = 0; i < this.Length; i++)
            {
                if (this[i] != temp[i])
                {
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// Returns hash code
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            int hash = 0;
            foreach (var item in coefficients)
            {
                hash ^= item.GetHashCode();
            }
            return base.GetHashCode();
        }
        /// <summary>
        /// Returns Length coefficients
        /// </summary>
        public int Length { get { return this.coefficients.Length; } }
        /// <summary>
        /// Indexer
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public double this[int index]
        {
            get
            {
                if (index < 0 || index >= this.Length)
                {
                    throw new ArgumentOutOfRangeException();
                }
                return coefficients[index];
            }
            set
            {
                if (index < 0 || index >= this.Length)
                {
                    throw new ArgumentOutOfRangeException();
                }
                if (Double.IsNaN(value) || Double.IsInfinity(value))
                {
                    throw new ArgumentOutOfRangeException();
                }
                coefficients[index] = value;
            }
        }
        /// <summary>
        /// Returns sumary by two polynomials
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns>New polynomial</returns>
        public static Polynomial operator +(Polynomial first, Polynomial second)
        {
            var maxDegree = 0;
            var Length = 0;
            Polynomial result;
            Polynomial min;
            if (first.Length <= second.Length)
            {
                maxDegree = first.Length;
                Length = second.Length;
                result = second.MemberwiseClone() as Polynomial;
                min = first;
            }
            else
            {
                maxDegree = second.Length;
                Length = first.Length;
                result = first.MemberwiseClone() as Polynomial;
                min = second;
            }

            for (int i = Length - maxDegree, j = 0; i < Length; i++, j++)
            {
                result[i] += min[j];
            }
            return result;
        }
        /// <summary>
        /// Returns sumary number and polynomial
        /// </summary>
        /// <param name="number"></param>
        /// <param name="polynomial"></param>
        /// <returns> New polynomial</returns>
        public static Polynomial operator +(double number, Polynomial polynomial)
        {
            Polynomial temp = new Polynomial(number);
            return polynomial + temp;
        }
        /// <summary>
        /// Returns sumary number and polynomial
        /// </summary>
        /// <param name="polynomial"></param>
        /// <param name="number"></param>
        /// <returns> New polynomial</returns>
        public static Polynomial operator +(Polynomial polynomial, double number)
        {
            Polynomial temp = new Polynomial(number);
            return polynomial + temp;
        }
        /// <summary>
        /// Returns subtract by two polynomials
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns> New polynomial</returns>
        public static Polynomial operator -(Polynomial first, Polynomial second)
        {
            return first + ((-1) * second);
        }
        /// <summary>
        /// Returns subtract number and polynomial
        /// </summary>
        /// <param name="number"></param>
        /// <param name="polynomial"></param>
        /// <returns> New polynomial</returns>
        public static Polynomial operator -(double number, Polynomial polynomial)
        {
            Polynomial temp = new Polynomial(number);
            return temp - polynomial;
        }
        /// <summary>
        /// Returns subtract number and polynomial
        /// </summary>
        /// <param name="polynomial"></param>]
        /// <param name="number"></param>
        /// <returns> New polynomial</returns>
        public static Polynomial operator -(Polynomial polynomial, double number)
        {
            Polynomial temp = new Polynomial(number);
            return polynomial - temp;
        }
        /// <summary>
        /// Returns multyplication number and polynomial
        /// </summary>
        /// <param name="number"></param>
        /// <param name="polynomial"></param>
        /// <returns>New polynomial</returns>
        public static Polynomial operator *(double number, Polynomial polynomial)
        {
            var result = polynomial.MemberwiseClone() as Polynomial;
            for (int i = 0; i < polynomial.Length; i++)
            {
                polynomial[i] *= number;
            }
            return result;
        }
        /// <summary>
        /// Returns multiplication number and polynomial
        /// </summary>
        /// <param name="polynomial"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        public static Polynomial operator *(Polynomial polynomial, double number)
        {
            var result = polynomial.MemberwiseClone() as Polynomial;
            for (int i = 0; i < polynomial.Length; i++)
            {
                polynomial[i] *= number;
            }
            return result;
        }
        /// <summary>
        /// Returns multiplication by twopolynomials
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static Polynomial operator *(Polynomial first, Polynomial second)
        {
            var result = new Polynomial(first.Length + second.Length - 1);
            for (int i = 0; i < first.Length; i++)
            {
                for (int j = 0; j < second.Length; j++)
                {
                    result[i + j] += (first[i] * second[j]);
                }
            }
            return result;
        }
        /// <summary>
        /// Returns divisionpolynomial by number
        /// </summary>
        /// <param name="polynomial"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        public static Polynomial operator /(Polynomial polynomial, double number)
        {
            if (number == 0)
            {
                throw new ArgumentException();
            }
            var result = polynomial.MemberwiseClone() as Polynomial;
            for (int i = 0; i < polynomial.Length; i++)
            {
                polynomial[i] /= number;
            }
            return result;
        }
        /// <summary>
        /// Returns true if polinomials equal
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static bool operator ==(Polynomial first, Polynomial second)
        {
            if (first.Length != second.Length)
            {
                return false;
            }
            for (int i = 0; i < first.Length; i++)
            {
                if (first[i] != second[i])
                {
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// Returns false if polinomials equal
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static bool operator !=(Polynomial first, Polynomial second)
        {
            if (first.Length != second.Length)
            {
                return true;
            }
            for (int i = 0; i < first.Length; i++)
            {
                if (first[i] != second[i])
                {
                    return true;
                }
            }
            return false;
        }
    }
}
