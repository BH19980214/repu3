using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace juli
{
  public partial class Form1 : Form
  {
    Graphics g;
    double startx = 0, starty = 0, endx = 0, endy = 0, midx, midy;
    int step = 0;
    double LineLength;
    bool d = false, f = false;
    public Form1()
    {
      InitializeComponent();
    }
    private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
    {
      if (d)
      {
        step += 1;
        if (step == 1)
        {
          startx = e.X;
          starty = e.Y;
          g = pictureBox1.CreateGraphics();
          g.FillEllipse(Brushes.Black, e.X, e.Y, 2, 2);
        }
        if (step == 2)
        {
          endx = e.X;
          endy = e.Y;
          g = pictureBox1.CreateGraphics();
          g.FillEllipse(Brushes.Black, e.X, e.Y, 2, 2);
          Pen p = new Pen(Color.White, 1);
          g.DrawLine(p, (int)startx, (int)starty, (int)endx, (int)endy);
          LineLength = Math.Sqrt((endx - startx) * (endx - startx) + (endy - starty) * (endy - starty));
          textBox1.Text = Convert.ToString(LineLength);
          step = 0;
        }
      }//画直线
      if (f)
      {
        midx = e.X;
        midy = e.Y;
        g = pictureBox1.CreateGraphics();
        g.FillEllipse(Brushes.Black, e.X, e.Y, 5, 5);
      }
    }
    // 计算两点之间的距离    
    private double lineSpace(double startx, double starty, double endx, double endy)
    {
      double lineLength = 0;
      lineLength = Math.Sqrt((endx - startx) * (endx - startx) + (endy - starty) * (endy - starty));
      return lineLength;
    }
    //点到线段距离  
    private void button1_Click(object sender, EventArgs e)
    {
      d = true;
      f = false;
      //LineLength = Math.Sqrt((endx - startx) * (endx - startx) + (endy - starty) * (endy - starty));
      //textBox1.Text = Convert.ToString(LineLength);
    }
    private void button3_Click(object sender, EventArgs e)
    {
      f = true;
      d = false;
    }
    private void button2_Click(object sender, EventArgs e)
    {
      d = false;
      f = false;
      LineLength = Math.Sqrt((endx - startx) * (endx - startx) + (endy - starty) * (endy - starty));
      double space = 0;
      double a, b, c;
      a = lineSpace(startx, starty, endx, endy);// 线段的长度    
      b = lineSpace(startx, starty, midx, midy);// (x1,y1)到点的距离    
      c = lineSpace(endx, endy, midx, midy);// (x2,y2)到点的距离    
      //if (c <= 0.000001 || b <= 0.000001)
      //{
      //  space = 0;
      //}
      //if (a <= 0.000001)
      //{
      //  space = b;
      //}
      //if (c * c >= a * a + b * b)
      //{
      //  space = b;
      //}
      //if (b * b >= a * a + c * c)
      //{
      //  space = c;
      //}
      double p = (a + b + c) / 2;// 半周长    
      double s = Math.Sqrt(p * (p - a) * (p - b) * (p - c));// 海伦公式求面积    
      space = 2 * s / a;// 返回点到线的距离（利用三角形面积公式求高)
      textBox2.Text = Convert.ToString(space);
    }
  }
}
