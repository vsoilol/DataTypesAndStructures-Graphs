using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Graphs.Structure.Traversals;

namespace Graphs.Structure
{
    public class Graph
    {
        private ITraversalStrategy _traversalStrategy;

        private List<Node> nodes;

        public ITraversalStrategy TraversalStrategy
        {
            get => _traversalStrategy ??= new BreadthFirstSearchTraversal();
            set => _traversalStrategy = value ?? throw new ArgumentNullException(nameof(value));
        }

        public Graph()
        {
            nodes = new List<Node>();
        }

        public bool AddNode(int nodeValue)
        {
            var node = nodes.FirstOrDefault(_ => _.Value == nodeValue);

            if (node is not null)
            {
                return false;
            }

            var createdNode = new Node(nodeValue);
            nodes.Add(createdNode);
            return true;
        }

        public bool CreateEdge(int firstValue, int secondValue)
        {
            var firstNode = nodes.FirstOrDefault(_ => _.Value == firstValue);
            var secondNode = nodes.FirstOrDefault(_ => _.Value == secondValue);

            if (firstNode is null || secondNode is null)
            {
                return false;
            }

            firstNode.Edges.Add(secondNode);
            secondNode.Edges.Add(firstNode);

            return true;
        }

        public IEnumerable<int> GetAllValueNodes()
        {
            return nodes.Select(_ => _.Value);
        }

        public void Clear()
        {
            nodes = new List<Node>();
        }

        public bool IsGraphConnected()
        {
            return nodes.Any() && nodes.All(node => node.Edges.Any());
        }

        public IEnumerable<int>? Traversal(int nodeValue)
        {
            if (!IsGraphConnected())
            {
                throw new ArgumentException("Граф не связный");
            }

            var node = nodes.FirstOrDefault(_ => _.Value == nodeValue);

            return node is null ? null : TraversalStrategy.Traversal(node);
        }
    }
}
