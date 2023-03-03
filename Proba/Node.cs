using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Proba
{

    public class Node : INotifyPropertyChanged
    {

        private Node leftNode;
        private Node rightNode;
        private Point parent;
        private Point leftChild;
        private Point rightChild;
        private bool isLeaf;
        private bool isRight;
        private bool isLeft;
        private int value;
        public SolidColorBrush myBrush = new SolidColorBrush(Colors.Beige);

        public Node LeftNode {
            get { return leftNode; }
            set { leftNode = value;
                OnPropertyChanged();
            }
        }
        public Node RightNode {
            get { return rightNode; }
            set { rightNode = value;
                OnPropertyChanged();
            }
        }
        public Point Parent {
            get { return parent; } 
            set { parent = value;
                OnPropertyChanged();
            }
        }
        public Point LeftChild
        {
            get { return leftChild; }
            set { leftChild = value;
                OnPropertyChanged();
            }
        }
        public Point RightChild { 
            get { return rightChild; }
            set { rightChild = value;
                OnPropertyChanged();
            }
        }
        public bool IsLeaf {
            get { return isLeaf; }
            set { isLeaf = value;
                OnPropertyChanged();    
            }
        }
        public bool IsRight {
            get { return isRight; }
            set { isRight = value;
                OnPropertyChanged();    
            }
        }
        public bool IsLeft {
            get { return isLeft; }
            set { isLeft = value;
                OnPropertyChanged();
                
            }
        }
        public int Value
        {
            get { return value; }
            set { this.value = value;
                OnPropertyChanged();
            }
        }
        public int Width { get; set; } = 40;

        public Node (int value)
        {

            Value = value;
        }
       public Node()
        { }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
