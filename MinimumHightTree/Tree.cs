using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimumHightTree
{
    class Connection
    {
        Node _node;
        int _weight;
        bool _counted;

        public Connection(Node node)
        {
            _node = node;
            _weight = -1;
            _counted = false;
        }

        public int Weight
        {
            set
            {
                _weight = value;
            }
            get
            {
                return _weight;
            }
        }

        Node Node
        {
            get
            {
                return _node;
            }
        }

        public void Count(Node parentNode)
        {
            if (_counted) return;
            _weight = 0;
            foreach (Connection con in _node.Connections)
            {
                if (con.Node != parentNode)
                {
                    if (!con._counted)
                    {
                        con.Count(_node);
                    }
                    if (_weight < con.Weight)
                    {
                        Weight = con.Weight;
                    }
                }
            }
            _weight+=1;
            _counted = true;
            return;
        }
    }
    class Node
    {
        int _number;
        bool _counted;
        List<Connection> _connections;
        int _length;

        public Node(int number)
        {
            _connections=new List<Connection>();
            _number = number;
            _counted = false;
            _length = 0;
        }

        public int Number
        {
            get
            {
                return _number;
            }
        }

        public int Length
        {
            get
            {
                return _length;
            }
        }

        public List<Connection> Connections
        {
            get
            {
                return _connections;
            }
        }

        public void AddConnection(Node conNode)
        {
            _connections.Add(new Connection(conNode));
            conNode._connections.Add(new Connection(this));
        }

        public void Count()
        {
            if (_counted) return;
            foreach (Connection con in _connections)
            {
                if (_length < con.Weight)
                    _length = con.Weight;
            }
            _counted = true;
            return;
        }
    }

    class Tree
    {
        Node _root;
        List<Node> _allNodes;

        public Tree(int n, int[,] edges)
        {
            Hashtable nodes = new Hashtable();
            _allNodes = new List<Node>();
            for (int i = 0; i < n; ++i)
            {
                Node newnode=new Node(i);
                nodes.Add(i, newnode);
                _allNodes.Add(newnode);
            }

            for (int i = 0; i < edges.GetLength(0); ++i)
            {
                ((Node)nodes[edges[i, 0]]).AddConnection((Node)nodes[edges[i, 1]]);
            }

        }

        public List<int> GetMinimumHeight()
        {
            int minLength = -1;
            List<int> result=new List<int>();
            foreach (Node node in _allNodes)
            {
                node.Count();
                if (minLength > node.Length || minLength==-1)
                {
                    result.Clear();
                    minLength = node.Length;
                }
                if(minLength==node.Length)
                {
                    result.Add(node.Number);
                }
            }

            return result;
        }
    }
}
