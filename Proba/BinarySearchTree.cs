using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Proba
{
    public class BinarySearchTree : BaseTree
    {
        
        public BinarySearchTree(treeConf conf) : base(conf) { }
        private Node Insert(Node root, int value)
        {
            if (root == null)
                root = new Node(value);
            else if (root.Value > value)
                root.LeftNode = Insert(root.LeftNode, value);
            else
                root.RightNode = Insert(root.RightNode, value);
            return root;
        }


        private Node Search(Node root, int value)
        {
            if (root.Value == value || root == null)
            {

                root = new Node(value);
                root.myBrush = new SolidColorBrush(Colors.Red);
                return root;
            }
            if (root.Value < value)
            {
                return Search(root.RightNode, value);
            }
            else
            {
                return Search(root.LeftNode, value);
            }



        }
        private Node Remove(Node cvor, int key)
        {
            if (cvor == null)
            {
                return cvor;
            }
            if (cvor.Value > key)
                cvor.LeftNode = Remove(cvor.LeftNode, key);
            else if (cvor.Value > key)
            {
                cvor.RightNode = Remove(cvor.RightNode, key);
            }
            else
            {
                if (cvor.LeftNode == null && cvor.RightNode == null)
                {
                    cvor = null;

                }
                else if (cvor.LeftNode != null && cvor.RightNode != null)
                {
                    var MaxNode = NaciMax(cvor.RightNode);
                    cvor.Value = MaxNode.Value;
                    cvor.RightNode = Remove(cvor.RightNode, MaxNode.Value);
                }
                else
                {
                    var Child = cvor.LeftNode != null ? cvor.LeftNode : cvor.RightNode;

                    cvor = Child;
                }
            }
            return cvor;

        }
        public void PreOrder(Node root)
        {
            if (root != null)
            {
               
                PreOrder(root.LeftNode);
                MessageBox.Show($"{root.Value}");
                PreOrder(root.RightNode);
            }
        }
       
        private Node NaciMax(Node cvor)
        {
            while (cvor.RightNode != null)
            {
                cvor = cvor.RightNode;
            }
            return cvor;
        }
        public override void Insert (int value)
        {
            
            _root = Insert(_root, value);

        }

        public  override void Remove (int value)
        {
             _root = Remove(_root, value);
        }
       
        public override void Search(int value)
        {
            
            _root = Search(_root, value);
            _root.myBrush = new SolidColorBrush(Colors.Red);
        }

        public override  ICollection<Node> GetAllNodes()
        {
            var nodeCollection = new List<Node>();

            GetAllNodes(_root, nodeCollection);

            var nodeInfos = nodeCollection.ToDictionary(
                x => x,
                y => new Node
                {
                    Value = y.Value,
                    RightNode = y.RightNode,
                    LeftNode = y.LeftNode,
                    IsLeaf = y.LeftNode == null && y.RightNode == null


                }
            );

            CalculateNodePositions(_root, nodeInfos, offset: 0, depth: 0);
            AggregateChildNotePositions(_root, null, nodeInfos);

            return nodeInfos.Values;
        }
        public int maxDepth(Node node)
        {
            if (node == null)
                return -1;
            else
            {
                /* compute the depth of each subtree */
                int lDepth = maxDepth(node.LeftNode);
                int rDepth = maxDepth(node.RightNode);

                /* use the larger one */
                if (lDepth > rDepth)
                    return (lDepth + 1);
                else return (rDepth + 1);
            }
        }
    }
    }
