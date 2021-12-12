using System.Collections.Generic;

namespace Graphs.Structure
{
    public class Node
    {
        /// <summary>
        /// Name of the vertex
        /// </summary>
        public int Value { get; }

        /// <summary>
        /// All the edges connected to the given vertex
        /// </summary>
        public List<Node> Edges { get; }

        public Node(int value)
        {
            Value = value;
            Edges = new List<Node>();
        }
    }
}