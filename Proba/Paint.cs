using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Proba
{
    public class Paint
    {

        private treeConf t = new treeConf();
        public object TextBlock { get; private set; }

        public void DrawLine (Point fromNodePosition, Point toNodePosition, int Offset)
        {
            Line l = new Line();
            l.X1 = fromNodePosition.X + t.width/2 + Offset;
            l.Y1 = fromNodePosition.Y + t.width / 2;
            l.X2 = toNodePosition.X + t.width / 2 + Offset;
            l.Y2 = toNodePosition.Y + t.width / 2;
            l.Stroke = Brushes.Black;
            l.StrokeThickness = 2;
            l.Fill = Brushes.Black;

            
            
        }
        public void DrawNode (Node node, int offset)
        {
            Ellipse krug = new Ellipse();
            TextBlock broj = new TextBlock();
            broj.Foreground = Brushes.Black;
            broj.Text = node.Value.ToString();
            int iHeight = TextRenderer.MeasureText(node.Value.ToString(), new System.Drawing.Font("Arial", 20)).Height;
            int iWidth = TextRenderer.MeasureText(node.Value.ToString(), new System.Drawing.Font("Arial", 20)).Width;
            krug.Height = t.width;
            krug.Width = t.width;
            krug.Fill = Brushes.Beige;
            krug.Stroke = Brushes.Black;
            krug.StrokeThickness = 2;
            double X = node.Parent.X + offset;
            double Y = node.Parent.Y;
            double X1 = node.Parent.X + t.width / 2 - (iWidth/2) + 1 + offset;
            double Y1 = node.Parent.X + t.width / 2 - (iHeight / 2) + 1; 
            Canvas.SetLeft(krug, X);
            Canvas.SetTop(krug, Y);
            Canvas.SetLeft(broj, X1);
            Canvas.SetTop(broj, Y1);
        }

        public void OnPaint (List<Node>_nodes)
        {
            int baseOffset = (int)(800 / 2 - t.width / 2 - _nodes.FirstOrDefault().Parent.X);
            foreach(var node in _nodes)
            {
                if(node.LeftNode != null)
                {
                    DrawLine(node.Parent, node.LeftChild, baseOffset);
                }  
                if(node.RightNode!= null)
                {
                    DrawLine(node.Parent, node.RightChild, baseOffset);
                }
                DrawNode(node, baseOffset);
            }

        }


    }
}
