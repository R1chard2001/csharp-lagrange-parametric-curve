using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagrangeInterpolation
{
    public class LagrangePolynomial
    {
        public LagrangePolynomial(List<PointF> points)
        {
                Points = points;
        }
        public List<PointF> Points { get; set; } = new List<PointF>();

        public double Calculate(double x)
        {
            double res = 0;
            for (int i = 0; i < Points.Count; i++)
            {
                double subRes = Points[i].Y;
                double a = 1;
                double b = 1;
                for (int j = 0; j < i; j++)
                {
                    a *= (x - Points[j].X);
                    b *= (Points[i].X - Points[j].X);
                }
                for (int j = i + 1; j < Points.Count; j++)
                {
                    a *= (x - Points[j].X);
                    b *= (Points[i].X - Points[j].X);
                }
                res += subRes * (a / b);
            }
            return res;
        }
    }
}
