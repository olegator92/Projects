using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using ShapesApp3.Enums;

namespace ShapesApp3
{
    
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public abstract class ShapeClass
        {
            public string ShapeName { get; set; }
            public double S { get; set; }

            public virtual void DisplayShape()
            {
            }
        }

        class Square : ShapeClass
        {
            public double A { get; set; }

            public override void DisplayShape()
            {
                S = A * A; //Get area
                
                var form = new DialogForm(ShapeName, A.ToString(), "", "", S.ToString());
                form.ShowDialog();
            }
        }

        class Rectangle : ShapeClass
        {
            public double A { get; set; }
            public double B { get; set; }

            public override void DisplayShape()
            {
                S = A * B; //Get area

                var form = new DialogForm(ShapeName, A.ToString(), B.ToString(), "", S.ToString());
                form.ShowDialog();
            }
        }

        class RightTriangle : ShapeClass
        {
            public double A { get; set; }
            public double B { get; set; }

            public override void DisplayShape()
            {
                S = A * B / 2; //Get area

                var form = new DialogForm(ShapeName, A.ToString(), B.ToString(), "", S.ToString());
                form.ShowDialog();
            }
        }

        class Circle : ShapeClass
        {
            public double R { get; set; }

            public override void DisplayShape()
            {
                S = Math.Round((R * R * 3.14), 2); //Get area

                var form = new DialogForm(ShapeName, "", "", R.ToString(), S.ToString());
                form.ShowDialog();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'shapesDBDataSet.ShapeTypes' table. You can move, or remove it, as needed.
            this.shapeTypesTableAdapter.Fill(this.shapesDBDataSet.ShapeTypes);

  
            var db = new ShapesDBDataContext();
            var shapes = db.Shapes;
            var shapesList = new List<ShapeClass>();
            foreach (var shape in shapes)
            {
                switch (shape.ShapeTypeId)
                {
                    case (int)EnumShapeTypes.Square:
                        shapesList.Add(new Square
                        {
                            ShapeName = shape.Name,
                            A = shape.A ?? default(double)
                        });
                        break;

                    case (int)EnumShapeTypes.Rectangle:
                        shapesList.Add(new Rectangle
                        {
                            ShapeName = shape.Name,
                            A = shape.A ?? default(double),
                            B = shape.B ?? default(double)
                        });
                        break;

                    case (int)EnumShapeTypes.RightTriangle:
                        shapesList.Add(new RightTriangle
                        {
                            ShapeName = shape.Name,
                            A = shape.A ?? default(double),
                            B = shape.B ?? default(double)
                        });
                        break;
                    case (int)EnumShapeTypes.Circle:
                        shapesList.Add(new Circle
                        {
                            ShapeName = shape.Name,
                            R = shape.R ?? default(double),
                        });
                        break;
                }
                
            }
            listBox1.DataSource = shapesList;
            listBox1.DisplayMember = "ShapeName";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Insert shape
            var shapeTypeId = int.Parse(comboBox1.SelectedValue.ToString());
            var shapeName = textBox1.Text;
            
            var shape = new Shape
            {
                ShapeTypeId = shapeTypeId,
                Name = shapeName,
            };

            switch (shapeTypeId)
            {
                case (int)EnumShapeTypes.Square:
                     shape.A = double.Parse(textBox2.Text);
                     break;

                case (int)EnumShapeTypes.Rectangle:
                case (int)EnumShapeTypes.RightTriangle:
                     shape.A = double.Parse(textBox2.Text);
                     shape.B = double.Parse(textBox3.Text);
                     break;

                case (int)EnumShapeTypes.Circle:
                     shape.R = double.Parse(textBox2.Text);
                     break;
            }
            
            var db = new ShapesDBDataContext();
            db.Shapes.InsertOnSubmit(shape);
            db.SubmitChanges();
            //-----//

            //Refresh data of the form
            var shapesList = new List<ShapeClass>();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();

            foreach (var item in db.Shapes)
            {
                switch (item.ShapeTypeId)
                {
                    case (int)EnumShapeTypes.Square:
                        shapesList.Add(new Square
                        {
                            ShapeName = item.Name,
                            A = item.A ?? default(double)
                        });
                        break;

                    case (int)EnumShapeTypes.Rectangle:
                        shapesList.Add(new Rectangle
                        {
                            ShapeName = item.Name,
                            A = item.A ?? default(double),
                            B = item.B ?? default(double)
                        });
                        break;

                    case (int)EnumShapeTypes.RightTriangle:
                        shapesList.Add(new RightTriangle
                        {
                            ShapeName = item.Name,
                            A = item.A ?? default(double),
                            B = item.B ?? default(double)
                        });
                        break;
                    case (int)EnumShapeTypes.Circle:
                        shapesList.Add(new Circle
                        {
                            ShapeName = item.Name,
                            R = item.R ?? default(double),
                        });
                        break;
                }
            }
            listBox1.DataSource = shapesList;
            listBox1.DisplayMember = "ShapeName";
            //------//
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {
           var shape = (ShapeClass)listBox1.SelectedItem;
           shape.DisplayShape();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch ((int)comboBox1.SelectedValue)
            {
                case (int) EnumShapeTypes.Square:
                    textBox3.Hide();
                    label4.Hide();
                    label3.Text = "A";
                    break;
                
                case (int)EnumShapeTypes.Rectangle: 
                case (int)EnumShapeTypes.RightTriangle:
                    textBox3.Show();
                    label4.Show();
                    label3.Text = "A";
                    break;

                case (int)EnumShapeTypes.Circle:
                    textBox3.Hide();
                    label4.Hide();
                    label3.Text = "R";
                    break;
            }
            
        }
    }
}
