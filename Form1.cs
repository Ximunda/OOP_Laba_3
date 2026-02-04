using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_Laba_3
{
    public partial class mainForm : Form
    {
        public Container container = new Container();
        public mainForm()
        {
            InitializeComponent();
            
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void mainForm_MouseClick(object sender, MouseEventArgs e)
        {
            CCircle circle = new CCircle(e.X, e.Y);
            container.add(circle);
            Invalidate();
        }

        private void mainForm_Paint(object sender, PaintEventArgs e)
        {
            container.drawAll(e.Graphics);
        }

        private void mainForm_Resize(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void clear_btn_Click(object sender, EventArgs e)
        {
            container.clear();
            Invalidate();
        }
    };
    public class CCircle
    {
        private int X { get; }
        private int Y { get; }
        private Color Circle_color { get; set; }
        private int Radius;
        public CCircle(int x, int y, int radius, Color color)
        {
            Radius = radius;
            X = x;
            Y = y;
            Circle_color = color;
        }
        public CCircle(int x, int y)
        {
            Radius = 20;
            X = x;
            Y = y;
            Circle_color = Color.Black;
        }
        public void draw(Graphics g)
        {
            using (Pen pen = new Pen(Circle_color, 2))
            {
                g.DrawEllipse(pen, X - Radius, Y - Radius, Radius * 2, Radius * 2);
            }
        }
    }
    public class Container
    {
        private List<CCircle> Circles = new List<CCircle>();

        public void add(CCircle circle)
        {
            Circles.Add(circle);
        }
        public void remove(CCircle circle)
        {
            Circles.Remove(circle);
        }
        public void clear()
        {
            
            Circles.Clear();
           
        }
        public void drawAll(Graphics g)
        {
            foreach (CCircle circle in Circles)
            {
                circle.draw(g);
            }
        }
    }
}
