using System.Collections.Generic;

namespace Graphs.Structure
{
    public class Node
    {
        /// <summary>
        /// Значение узла
        /// </summary>
        public int Value { get; }

        /// <summary>
        /// Все узлы котороые связаны с данным узлом
        /// </summary>
        public List<Node> Edges { get; }

        public Node(int value)
        {
            Value = value;
            Edges = new List<Node>();
        }
    }
}