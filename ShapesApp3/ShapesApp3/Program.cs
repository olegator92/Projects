using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShapesApp3
{
    public abstract class ShapeClass
    {
        public string ShapeName { get; set; }
        public double S { get; set; }

        public virtual void DisplayShape()
        {
        }
    }

    public class Square : ShapeClass
    {
        public double A { get; set; }

        public Square(string name, double a)
        {
            this.ShapeName = name;
            this.A = a;
            this.S = a * a;
        }

        public override void DisplayShape()
        {
            var form = new DialogForm(this);
            form.ShowDialog();
        }
    }

    public class Rectangle : ShapeClass
    {
        public double A { get; set; }
        public double B { get; set; }

        public Rectangle(string name, double a, double b)
        {
            this.ShapeName = name;
            this.A = a;
            this.B = b;
            this.S = a * b;
        }

        public override void DisplayShape()
        {
            var form = new DialogForm(this);
            form.ShowDialog();
        }
    }

    public class RightTriangle : ShapeClass
    {
        public double A { get; set; }
        public double B { get; set; }

        public RightTriangle(string name, double a, double b)
        {
            this.ShapeName = name;
            this.A = a;
            this.B = b;
            this.S = a * b / 2;
        }

        public override void DisplayShape()
        {
            var form = new DialogForm(this);
            form.ShowDialog();
        }
    }

    public class Circle : ShapeClass
    {
        public double R { get; set; }

        public Circle(string name, double r)
        {
            this.ShapeName = name;
            this.R = r;
            this.S = Math.Round((r * r * 3.14), 2);
        }

        public override void DisplayShape()
        {
            var form = new DialogForm(this);
            form.ShowDialog();
        }
    }
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
