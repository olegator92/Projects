using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShapesApp3
{
    public partial class DialogForm : Form
    {

        public DialogForm(Square square)
        {
            InitializeComponent();

            label1.Text = "Имя фигуры: " + square.ShapeName;
            label2.Text = "A = " + square.A;
            label3.Text = "S = " + square.S;
            label4.Hide();
        }

        public DialogForm(Rectangle rectangle)
        {
            InitializeComponent();

            label1.Text = "Имя фигуры: " + rectangle.ShapeName;
            label2.Text = "A = " + rectangle.A;
            label3.Text = "B = " + rectangle.B;
            label4.Text = "S = " + rectangle.S;
        }

        public DialogForm(RightTriangle rightTrectangle)
        {
            InitializeComponent();

            label1.Text = "Имя фигуры: " + rightTrectangle.ShapeName;
            label2.Text = "A = " + rightTrectangle.A;
            label3.Text = "B = " + rightTrectangle.B;
            label4.Text = "S = " + rightTrectangle.S;
        }

        public DialogForm(Circle circle)
        {
            InitializeComponent();

            label1.Text = "Имя фигуры: " + circle.ShapeName;
            label2.Text = "R = " + circle.R;
            label3.Text = "S = " + circle.S;
            label4.Hide();
        }
    }
}
