using LagrangeInterpolation.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LagrangeInterpolation
{
    public partial class CanvasForm : Form
    {
        static float tDiv = 20;
        int lastSelectedIndex = -1;
        int grabbedIndex = -1;
        int CanvasWidthDiff = 17;
        int pointLimit = 15;
        int pointSize = 10;
        Pen blackW2 = new Pen(Color.Black, 2);
        Pen redW2 = new Pen(Color.Red, 2);
        public CanvasForm()
        {
            InitializeComponent();
            Redraw();
        }

        private void MainCanvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            try
            {
                if (Settings.Points.Count > 1)
                {
                    if (LagrangeOrGaussCB.Checked)
                    {
                        DrawParametricLagrange(g, n: 500);
                    }
                    else
                    {
                        DrawParametricLagrangeGauss(g, n: 500);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("An error occurred while calculating the curve!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lastSelectedIndex = -1;
                grabbedIndex = -1;
                grabbedTIndex = -1;
            }
            
            for (int i = 0; i < Settings.Points.Count; i++)
            {
                PointF p = Settings.Points[i];
                if (lastSelectedIndex == i)
                {
                    g.FillRectangle(Brushes.Red, p.X - pointSize/2, p.Y - pointSize/2, pointSize, pointSize);
                }
                else
                {
                    g.FillRectangle(Brushes.White, p.X - pointSize / 2, p.Y - pointSize / 2, pointSize, pointSize);
                }
                g.DrawRectangle(Pens.Black, p.X - pointSize / 2, p.Y - pointSize / 2, pointSize, pointSize);
            }
            
        }
        private void Redraw()
        {
            TCanvas.Invalidate();
            MainCanvas.Invalidate();
        }

        private void TCanvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            int middleY = TCanvas.Height / 2;
            int startX = CanvasWidthDiff;
            int endX = TCanvas.Width - CanvasWidthDiff;
            g.DrawLine(Pens.Black, startX, middleY, endX, middleY);
            float diff = (float) (endX - startX) / tDiv;
            float val = 0;
            float valDiff = 1f / tDiv;
            for (float i = startX; i <= endX + 0.05; i+= diff)
            {
                g.DrawLine(Pens.Black, i, middleY + 5, i, middleY - 5);
                g.DrawString(val.ToString("0.00"), DefaultFont, Brushes.Black, i - 10, middleY + 7);
                val += valDiff;
            }

            if (Settings.UseChordLengths)
            {
                DrawChordTValues(g, startX, endX, middleY);
            }
            else
            {
                DrawTValues(g, startX, endX, middleY, Settings.TValues);
            }
        }

        void DrawChordTValues(Graphics g, int startX, int endX, int middleY)
        {
            DrawTValues(g, startX, endX, middleY, Settings.ChordTValues);
        }

        void DrawTValues(Graphics g, int startX, int endX, int middleY, List<double> tVals) 
        {
            float xLength = endX - startX;
            float tX = startX;
            for (int i = 0; i < tVals.Count; i++)
            {
                tX = startX + xLength * (float)tVals[i];
                if (lastSelectedIndex == i)
                {
                    g.DrawLine(redW2, tX - pointSize / 2, middleY - pointSize / 2,
                        tX + pointSize / 2, middleY + pointSize / 2);
                    g.DrawLine(redW2, tX + pointSize / 2, middleY - pointSize / 2,
                        tX - pointSize / 2, middleY + pointSize / 2);
                }
                else
                {
                    g.DrawLine(blackW2, tX - pointSize / 2, middleY - pointSize / 2,
                        tX + pointSize / 2, middleY + pointSize / 2);
                    g.DrawLine(blackW2, tX + pointSize / 2, middleY - pointSize / 2,
                        tX - pointSize / 2, middleY + pointSize / 2);
                }

            }
        }
        

        private void Form1_Resize(object sender, EventArgs e)
        {
            Redraw();
        }
        private int GetPointCaptured(Point point)
        {
            for (int i = 0; i < Settings.Points.Count; i++)
            {
                if (Settings.Points[i].X + pointSize / 2 >= point.X && Settings.Points[i].Y + pointSize / 2 >= point.Y &&
                    Settings.Points[i].X - pointSize / 2 <= point.X && Settings.Points[i].Y - pointSize / 2 <= point.Y)
                {
                    return i;
                }
            }

            return -1;
        }

        private void AddNewPoint(Point point)
        {
            if (Settings.Points.Count >= pointLimit)
            {
                MessageBox.Show($"Point limit is {pointLimit}!");
                return;
            }
            Settings.Points.Add(point);
            int Count = Settings.TValues.Count;
            if (Count == 0)
            {
                Settings.TValues.Add(0.0);
            }
            else if (Count == 1)
            {
                Settings.TValues.Add(1.0);
            }
            else
            {
                Settings.TValues = Settings.ChordTValues;
            }
            grabbedIndex = Settings.Points.Count - 1;
            lastSelectedIndex = grabbedIndex;
        }

        private void MainCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            int loc;
            switch (e.Button)
            { 
                case MouseButtons.Left:
                    loc = GetPointCaptured(e.Location);
                    if (loc == -1)
                    {
                        AddNewPoint(e.Location);
                    }
                    else
                    {
                        grabbedIndex = loc;
                        lastSelectedIndex = loc;
                    }
                    break;
                case MouseButtons.Right:
                    loc = GetPointCaptured(e.Location);
                    lastSelectedIndex = -1;
                    if (loc == -1) break;
                    Settings.Points.RemoveAt(loc);
                    Settings.TValues.RemoveAt(loc);
                    Settings.TValues = Settings.ChordTValues;
                    break;
                default: break;
            }
            Redraw();
        }
        private void MainCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            grabbedIndex = -1;
        }

        int grabbedTIndex = -1;
        private void GetTCaptured(Point point)
        {
            int startX = CanvasWidthDiff;
            int endX = TCanvas.Width - CanvasWidthDiff;
            float xLength = endX - startX;
            float tX = startX;
            int middleY = TCanvas.Height / 2;
            for (int i = 1; i < Settings.TValues.Count - 1; i++)
            {
                tX = startX + xLength * (float)Settings.TValues[i];
                if (tX + pointSize / 2 >= point.X && tX - pointSize / 2 <= point.X)
                {
                    lastSelectedIndex = i;
                    Redraw();
                    grabbedTIndex = i; return;
                }
            }
            grabbedTIndex = -1;
        }
        private void TCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    GetTCaptured(e.Location);
                    break;
                default: break;
            }
        }

        private void TCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            grabbedTIndex = -1;
        }

        private void MainCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (grabbedIndex == -1) return;
            int newX = e.X;
            if (newX < 0) newX = 0;
            if (newX > MainCanvas.Width) newX = MainCanvas.Width;
            int newY = e.Y;
            if (newY < 0) newY = 0;
            if (newY > MainCanvas.Height) newY = MainCanvas.Height;
            Settings.Points[grabbedIndex] = new PointF(newX, newY);
            Redraw();
        }
        private void TCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (grabbedTIndex == -1) return;
            int fullLength = TCanvas.Width - 2 * CanvasWidthDiff;
            int length = e.X - CanvasWidthDiff;
            /*
            if (length < 0) length = 0;
            else if (length > TCanvas.Width - 2 * CanvasWidthDiff) length = TCanvas.Width - 2 * CanvasWidthDiff;*/
            double t = (double)length / fullLength;

            if (t <= Settings.TValues[grabbedTIndex - 1])
            {
                return;
            }
            if (t >= Settings.TValues[grabbedTIndex + 1])
            {
                return;
            }
            
            Settings.TValues[grabbedTIndex] = t;
            Redraw();
        }

        private void ChordLCB_CheckedChanged(object sender, EventArgs e)
        {
            Settings.UseChordLengths = ChordLCB.Checked;
            Redraw();
        }

        private void DrawParametricLagrange(Graphics g, int n = 100)
        {
            int c = Settings.Points.Count;
            List<PointF> pointsX = new List<PointF>();
            List<PointF> pointsY = new List<PointF>();
            List<double> TValues = Settings.UseChordLengths ? Settings.ChordTValues : Settings.TValues;
            for (int i = 0; i < c; i++)
            {
                pointsX.Add(new PointF((float)TValues[i], Settings.Points[i].X));
                pointsY.Add(new PointF((float)TValues[i], Settings.Points[i].Y));
            }

            LagrangePolynomial FX = new LagrangePolynomial(pointsX);
            LagrangePolynomial FY = new LagrangePolynomial(pointsY);
            
            double t = 0;
            double d = 1.0 / n;

            PointF p0 = new PointF((float)FX.Calculate(t), (float)FY.Calculate(t));
            while (t <= 1.0)
            {
                t += d;
                PointF p1 = new PointF((float)FX.Calculate(t), (float)FY.Calculate(t));
                g.DrawLine(blackW2, p0, p1);
                p0 = p1;
            }
        }

        private void DrawParametricLagrangeGauss(Graphics g, int n = 100)
        {
            int c = Settings.Points.Count;
            List<PointF> pointsX = new List<PointF>();
            List<PointF> pointsY = new List<PointF>();
            List<double> TValues = Settings.UseChordLengths ? Settings.ChordTValues : Settings.TValues;

            double[,] xMatrix = new double[c,c+1];
            double[,] yMatrix = new double[c,c+1];

            for (int i = 0; i < c; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    xMatrix[i, j] = Math.Pow(TValues[i],j);
                    yMatrix[i, j] = Math.Pow(TValues[i],j);
                }
                xMatrix[i, c] = Settings.Points[i].X;
                yMatrix[i, c] = Settings.Points[i].Y;
            }
            Polynomial FX = xMatrix.Solve();
            Polynomial FY = yMatrix.Solve();
            

            double t = 0;
            double d = 1.0 / n;

            PointF p0 = new PointF((float)FX.Calculate(t), (float)FY.Calculate(t));
            while (t <= 1.0)
            {
                t += d;
                PointF p1 = new PointF((float)FX.Calculate(t), (float)FY.Calculate(t));
                g.DrawLine(blackW2, p0, p1);
                p0 = p1;
            }
        }

        private void CLBtn_Click(object sender, EventArgs e)
        {
            Settings.TValues = Settings.ChordTValues;
            Redraw();
        }

        private void LagrangeOrGaussCB_CheckedChanged(object sender, EventArgs e)
        {
            Redraw();
        }

        private void ClearBTN_Click(object sender, EventArgs e)
        {
            Settings.Points.Clear();
            Settings.TValues.Clear();
            Redraw();
        }
    }
}
