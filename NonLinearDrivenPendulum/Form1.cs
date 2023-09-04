using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NonLinearDrivenPendulum
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int size = 3000;
            double[] w = new double[size];
            double[] th = new double[size];
            double[] t = new double[size];

            //w[0] = 0.1;
            th[0] = 0.2;


            //double g = 9.8, l = 9.8, dt = 0.04, q = 0.5, od = (2.0/3.0), fd = 1.2;
            double g = 9.8, l = 9.8, dt = 0.04, q = 0.5, od = (2.0 / 3.0);
            double fd = double.Parse(textBox1.Text);

            for (int i = 0; i < size - 1; i++)
            {
                w[i + 1] = w[i] - (g / l) * Math.Sin(th[i]) * dt - q * w[i] * dt + fd * Math.Sin(od * t[i]) * dt;
                th[i + 1] = th[i] + w[i + 1] * dt;
                t[i + 1] = t[i] + dt;
            }

            Graphics gg = CreateGraphics();
            SolidBrush sb = new SolidBrush(Color.Blue);


            for (int i = 0; i < size - 1; i++)
            {
                    gg.FillEllipse(sb, 50 + (float)t[i] * 5, 150 - (float)th[i] * 10, 5, 5);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            int size = 3000;
            double[] w = new double[size];
            double[] th = new double[size];
            double[] t = new double[size];

            //w[0] = 0.1;
            th[0] = 0.2;

            //double g = 9.8, l = 9.8, dt = 0.04, q = 0.5, od = (2.0 / 3.0), fd = 1.2;
            double g = 9.8, l = 9.8, dt = 0.04, q = 0.5, od = (2.0 / 3.0);
            double fd = double.Parse(textBox1.Text);

            for (int i = 0; i < size - 1; i++)
            {
                w[i + 1] = w[i] - (g / l) * Math.Sin(th[i]) * dt - q * w[i] * dt + fd * Math.Sin(od * t[i]) * dt;
                th[i + 1] = th[i] + w[i + 1] * dt;

                if (th[i + 1] > Math.PI)
                {
                    th[i + 1] = th[i + 1] - 2 * Math.PI;
                }
                if (th[i + 1] < Math.PI)
                {
                    th[i + 1] = th[i + 1] + 2 * Math.PI;
                }

                t[i + 1] = t[i] + dt;
            }

            Graphics gg = CreateGraphics();
            SolidBrush sb = new SolidBrush(Color.Red);


            for (int i = 1; i < size - 1; i++)
            {
                gg.FillEllipse(sb, 50 + (float)t[i] * 5, 250 - (float)th[i] * 10, 5, 5);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int size = 3000;
            double[] w = new double[size];
            double[] th = new double[size];
            double[] t = new double[size];

            //w[0] = 0.1;
            th[0] = 0.2;

            //double g = 9.8, l = 9.8, dt = 0.04, q = 0.5, od = (2.0 / 3.0), fd = 1.2;
            double g = 9.8, l = 9.8, dt = 0.04, q = 0.5, od = (2.0 / 3.0);
            double fd = double.Parse(textBox1.Text);

            PointF pf;
            List<PointF> gp = new List<PointF>();

            for (int i = 0; i < size - 1; i++)
            {
                w[i + 1] = w[i] - (g / l) * Math.Sin(th[i]) * dt - q * w[i] * dt + fd * Math.Sin(od * t[i]) * dt;
                th[i + 1] = th[i] + w[i + 1] * dt;

                if (th[i + 1] > Math.PI)
                {
                    th[i + 1] = th[i + 1] - 2 * Math.PI;
                }
                if (th[i + 1] < Math.PI)
                {
                    th[i + 1] = th[i + 1] + 2 * Math.PI;
                }

                t[i + 1] = t[i] + dt;

                pf = new PointF(50 + (float)t[i] * 5, 450 - (float)th[i] * 10);
                gp.Add(pf);
            }

            Graphics gg = CreateGraphics();
            Pen p = new Pen(Color.Green, 5);

            for (int i = 1; i < size - 2; i++)
            {
                gg.DrawLine(p, gp[i], gp[i + 1]);
            }
        }
    }
}
