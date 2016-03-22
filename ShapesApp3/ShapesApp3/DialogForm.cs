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
        public DialogForm(string shapeName, string a, string b, string r, string s)
        {
            InitializeComponent();
            label1.Text = shapeName;
            if (r != "")
            {
                label2.Text = "r = " + r;
                label3.Text = "s = " + s;
                label4.Hide();
            }
            else if (b != "")
            {
                label2.Text = "a = " + a;
                label3.Text = "b = " + b;
                label4.Text = "s = " + s;
            }
            else
            {
                label2.Text = "a = " + a;
                label3.Text = "s = " + s;
                label4.Hide();
            }
        }
    }
}
