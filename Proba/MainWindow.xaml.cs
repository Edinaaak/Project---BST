using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using static System.Net.Mime.MediaTypeNames;

namespace Proba
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
       
        private ICollection<Node> Nodes;
        private BinarySearchTree Bst;
        public int vrednost { get; set; }
        public ICollection<Node> empty { get; set; }
        public BinarySearchTree bst { get{ return Bst; } 
            set { Bst = value; OnPropertyChanged("bst"); } }
        public ICollection<Node> nodes { get { return Nodes; }

            set { Nodes = value; OnPropertyChanged("nodes"); } }
        public DispatcherTimer dt { get; set; } = new DispatcherTimer();

        private treeConf t = new treeConf();
        public Db database { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public BaseTree bt { get; set; }

        public MainWindow()
        {
            
            InitializeComponent();
            database = new Db();
            bst = new BinarySearchTree(t);
            empty = null;

        }
        private void insertdugme_Click(object sender, RoutedEventArgs e)
        {
            if (insert.Text != "")
            {
                bst.Insert(int.Parse(insert.Text));
                nodes = bst.GetAllNodes();
                OnPaint(nodes);
                database.Brojac(nodes.Count, float.Parse(insert.Text));
                database.AlInsert(nodes.FirstOrDefault().Value, float.Parse(insert.Text));
                insert.Text = "";
            }
            else
            {
                System.Windows.MessageBox.Show("Enter a number");
            }
        }



        private void deletedugme_Click(object sender, RoutedEventArgs e)
        {
            if (delete.Text != "")
            {
                bst.Remove(int.Parse(delete.Text));
                nodes = bst.GetAllNodes();
                OnPaint(nodes);
                database.AlDeLete(nodes.FirstOrDefault().Value, float.Parse(delete.Text));
                delete.Text = "";
            }
            else
            {
                System.Windows.MessageBox.Show("Enter a number");
            }

        }

        private void searchdugme_Click(object sender, RoutedEventArgs e)
        {

            if (search.Text != "")
            {
               
                    int i = int.Parse(search.Text);
                    nodes.Where(x => x.Value == i).FirstOrDefault().myBrush = new SolidColorBrush(Colors.LightBlue);
                    nodes.Where(x => x.Value == i).FirstOrDefault().myBrush = new SolidColorBrush(Colors.LightBlue);
                    OnPaint(nodes);
                    nodes.Where(x => x.Value == i).FirstOrDefault().myBrush = new SolidColorBrush(Colors.Beige);
                    database.AlSearch(nodes.FirstOrDefault().Value, float.Parse(search.Text));
               
                
                
            }
            else
            {
                System.Windows.MessageBox.Show("Enter a number");
            }
        }
        public void DrawLine(Point fromNodePosition, Point toNodePosition, double Offset)
        {
            Line l = new Line();
            l.X1 = fromNodePosition.X + t.width / 2 + Offset;
            l.Y1 = fromNodePosition.Y + t.width / 2;
            l.X2 = toNodePosition.X + t.width / 2 + Offset;
            l.Y2 = toNodePosition.Y + t.width / 2;
            l.Stroke = Brushes.Black;
            l.StrokeThickness = 2;
            l.Fill = Brushes.Black;
            podloga.Children.Add(l);



        }
        public void DrawNode(Node node, double offset, SolidColorBrush  c)
        {
            Ellipse krug = new Ellipse();
            TextBlock broj = new TextBlock();
            broj.Foreground = Brushes.Black;
            broj.Text = node.Value.ToString();
            int iHeight = TextRenderer.MeasureText(node.Value.ToString(), new System.Drawing.Font("Arial", 25)).Height;
            int iWidth = TextRenderer.MeasureText(node.Value.ToString(), new System.Drawing.Font("Arial", 25)).Width;
            krug.Height = t.width;
            krug.Width = t.width;
            krug.Fill = c;
            krug.Stroke = Brushes.LightBlue;
            krug.StrokeThickness = 2;
            double X = node.Parent.X + offset;
            double Y = node.Parent.Y ;
            double X1 = node.Parent.X + (t.width / 2) - (iWidth/8) +1   + offset;
            double Y1 = node.Parent.Y + (t.width / 2) - (iHeight/6);
            Canvas.SetLeft(krug, X);
            Canvas.SetTop(krug, Y);
            Canvas.SetLeft(broj, X1);
            Canvas.SetTop(broj, Y1);
            podloga.Children.Add(krug);
            podloga.Children.Add(broj);
        }

        public void OnPaint(ICollection<Node> _nodes)
        {
            podloga.Children.Clear();
         
                double baseOffset = (Width / 2 - t.width / 2 - _nodes.FirstOrDefault().Parent.X);


            foreach (var node in _nodes)
            {
                if (node.LeftNode != null)
                {
                    
                    DrawLine(node.Parent, node.LeftChild, baseOffset);
                }
                if (node.RightNode != null)
                {
                    
                    DrawLine(node.Parent, node.RightChild, baseOffset);
                }
                
                DrawNode(node, baseOffset, node.myBrush);
                
            }

            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string path = @"..\..\PDF\Teorija.pdf";
            Process.Start(path);
        
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("Insert:\n1.Start from the root.\n2.Compare the inserting element with root, if less than root, then recursively call right subtree.\n3.After reaching the end, just insert that node at left(if less than current) or else right.\n" +
                "Delete:\n1.Start from the root.\n2.Compare the element that we want delete with root, if less than root, then recursively call left subtree, else recursively call right subtree.\n3.If an element with that value is found, it is deleted.There are three types of deletion depending on whether a given node has one child, two or none.\n" +
                "Search:\n1.Start from the root.\n2.Compare the searching element with root, if less than root, then recursively call left subtree, else recursively call right subtree.\n3.If the element to search is found anywhere, return true, else return false. "
                );
        }
    }
}
