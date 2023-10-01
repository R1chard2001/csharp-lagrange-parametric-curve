using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace LagrangeInterpolation
{
    internal static class Settings
    {
        public static List<PointF> Points = new List<PointF>();
        public static List<double> TValues = new List<double>();
        public static bool UseChordLengths = false;
        public static List<double> ChordTValues
        {
            get { 
                List<double> result = new List<double>();
                int count = Points.Count;
                if (count == 0)
                {
                    return new List<double>();
                }
                

                List<double> lengths = new List<double>() { 0 };
                
                double fullLength = 0;
                for (int i = 1; i < Points.Count; i++)
                {
                    double length = Math.Sqrt(Math.Pow(Points[i - 1].X - Points[i].X, 2) + Math.Pow(Points[i - 1].Y - Points[i].Y, 2));
                    fullLength += length;
                    lengths.Add(lengths[i - 1] + length);
                }

                if (fullLength == 0)
                {
                    return lengths;
                }

                foreach (double length in lengths)
                {
                    result.Add(length / fullLength);
                }

                return result; 
            }
        }
    }
}
