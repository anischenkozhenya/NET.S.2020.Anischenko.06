using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polynomial
{
    public sealed class Polynomial
    {
        double[] coefficients;
        public Polynomial()
        {
            this.coefficients = new double[1];
        }

        public Polynomial(params double[] coefficients)
        {
            this.coefficients = coefficients;
        }
        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            int degree  = coefficients.Length-1;
            foreach (var item in coefficients)
            {
                if (item!=0)
                {
                    str.Append($"{item}*X^{degree}+");
                }
                degree--;
            }
            return str.ToString().Substring(0,str.Length-1);
        }

        public override bool Equals(object obj)
        {
            var temp = obj as Polynomial;
            for (int i = 0; i < this.coefficients.Length; i++)
            {
                if (this.coefficients[i]!=temp.coefficients[i])
                {
                    return false;
                }
            }
            return true;
        }
        public override int GetHashCode()
        {
            int hash=0;
            foreach (var item in coefficients)
            {
                hash ^= item.GetHashCode();
            }            
            return base.GetHashCode();
        }
    }
}
