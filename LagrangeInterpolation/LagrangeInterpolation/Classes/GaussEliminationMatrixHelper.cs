using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagrangeInterpolation.Classes
{
    internal static class GaussEliminationMatrixHelper
    {
        public static Polynomial Solve(this double[,] M)
        {
            // input checks
            int rowCount = M.GetUpperBound(0) + 1;
            if (M == null || M.Length != rowCount * (rowCount + 1))
                throw new ArgumentException("The algorithm must be provided with a (n x n+1) matrix.");
            if (rowCount < 1)
                throw new ArgumentException("The matrix must at least have one row.");

            // pivoting
            for (int col = 0; col + 1 < rowCount; col++) if (M[col, col] == 0)
                // check for zero coefficients
                {
                    // find non-zero coefficient
                    int swapRow = col + 1;
                    for (; swapRow < rowCount; swapRow++) if (M[swapRow, col] != 0) break;

                    if (M[swapRow, col] != 0) // found a non-zero coefficient?
                    {
                        // yes, then swap it with the above
                        double[] tmp = new double[rowCount + 1];
                        for (int i = 0; i < rowCount + 1; i++)
                        { tmp[i] = M[swapRow, i]; M[swapRow, i] = M[col, i]; M[col, i] = tmp[i]; }
                    }
                    else throw new Exception();
                }

            // elimination
            for (int sourceRow = 0; sourceRow + 1 < rowCount; sourceRow++)
            {
                for (int destRow = sourceRow + 1; destRow < rowCount; destRow++)
                {
                    double df = M[sourceRow, sourceRow];
                    double sf = M[destRow, sourceRow];
                    for (int i = 0; i < rowCount + 1; i++)
                        M[destRow, i] = M[destRow, i] * df - M[sourceRow, i] * sf;
                }
            }

            // back-insertion
            for (int row = rowCount - 1; row >= 0; row--)
            {
                double f = M[row, row];
                if (f == 0) throw new Exception();

                for (int i = 0; i < rowCount + 1; i++) M[row, i] /= f;
                for (int destRow = 0; destRow < row; destRow++)
                { M[destRow, rowCount] -= M[destRow, row] * M[row, rowCount]; M[destRow, row] = 0; }
            }
            double[] coeff = new double[M.GetLength(1)];
            for (int i = 0; i < M.GetLength(0); i++)
            {
                coeff[i] = M[i, M.GetLength(1) - 1];
            }
            return new Polynomial(coeff);
        }
    }
}
