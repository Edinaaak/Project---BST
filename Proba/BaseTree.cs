using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Proba
{
    public abstract class BaseTree
    {
        protected treeConf treeC;
        protected Node _root;

        public BaseTree(treeConf C)
        {
            treeC = C;
        }
        public abstract void Insert(int value);
        public abstract void Remove(int value);
        public abstract void Search(int value);
        public  abstract ICollection<Node> GetAllNodes();
        public void GetAllNodes(Node root, List<Node> collection)
        {
            if (root == null)
            {
                return;
            }
            collection.Add(root);
            GetAllNodes(root.LeftNode, collection);
            GetAllNodes(root.RightNode, collection);
        }
        protected int CalculateNodePositions(Node root, IDictionary<Node, Node> nodeInfos, int offset, int depth)
        {
            if (root == null)
            {
                return 0;
            }

            int circleDiameterOffset = treeC.width - (int)(treeC.width / Math.PI);

            int left = CalculateNodePositions(root.LeftNode, nodeInfos, offset, depth + 1);
            int right = CalculateNodePositions(root.RightNode, nodeInfos, offset + left + circleDiameterOffset, depth + 1);

            nodeInfos[root].Parent =
                new Point
                {
                    Y = depth * treeC.width,
                    X = left + offset
                };
            return left + right + circleDiameterOffset;
        }
        protected void AggregateChildNotePositions(Node root, Node parent, IDictionary<Node, Node> nodeInfos)
        {
            if (root == null)
            {
                return;
            }

            AggregateChildNotePositions(root.LeftNode, root, nodeInfos);
            AggregateChildNotePositions(root.RightNode, root, nodeInfos);

            if (parent != null)
            {
                nodeInfos[root].IsRight = parent.RightNode == root;
                nodeInfos[root].IsLeft = parent.LeftNode == root;
            }

            if (root.LeftNode != null)
                nodeInfos[root].LeftChild =
                    new Point
                    {
                        X = nodeInfos[root.LeftNode].Parent.X,
                        Y = nodeInfos[root.LeftNode].Parent.Y
                    };
            if (root.RightNode != null)
                nodeInfos[root].RightChild =
                    new Point
                    {
                        X = nodeInfos[root.RightNode].Parent.X,
                        Y = nodeInfos[root.RightNode].Parent.Y
                    };
        }
        protected void GetAllNodes(Node root, ICollection<Node> collection)
        {
            if (root == null)
            {
                return;
            }
            collection.Add(root);
            GetAllNodes(root.LeftNode, collection);
            GetAllNodes(root.RightNode, collection);
        }
    }
}
