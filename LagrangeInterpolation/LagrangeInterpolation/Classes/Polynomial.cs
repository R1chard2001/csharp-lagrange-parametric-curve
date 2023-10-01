using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagrangeInterpolation
{
    public class Polynomial
    {
        public Polynomial() : this(new double[] { .0, 1.0 })
        { }
        public Polynomial(double[] coefficientArray)
        {
            Coefficients = (double[])coefficientArray.Clone();
        }
        public double[] Coefficients;
        public int Degree
        {
            get { return Coefficients.Length - 1; }
        }

        public double Calculate(double x)
        {
            double result = 0;
            for (int i = 0; i < Coefficients.Length; i++)
            {
                double subResult = Coefficients[i];
                for (int j = 1; j <= i; j++)
                {
                    subResult *= x;
                }
                result += subResult;
            }
            return result;
        }
    }
}
