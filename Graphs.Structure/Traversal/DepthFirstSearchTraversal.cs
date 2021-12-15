using System;
using System.Collections.Generic;
using System.Linq;

namespace Graphs.Structure.Traversals
{
    /// <summary>
    /// Поиск в глубину
    /// </summary>
    public class DepthFirstSearchTraversal : ITraversalStrategy
    {
        public IEnumerable<int> Traversal(Node node)
        {
            if (!node.Edges.Any())
            {
                throw new ArgumentException("Данный узел не содержит потомков");
            }

            var result = new List<int>();
            var visited = new HashSet<int>();
            var stack = new Stack<Node>();

            stack.Push(node);

            while (stack.Count != 0)
            {
                var current = stack.Pop();

                if (visited.Add(current.Value))
                {
                    result.Add(current.Value);
                }

                var neighbours = current.Edges
                    .Where(_ => !visited.Contains(_.Value))
                    .OrderBy(_ => _.Value)
                    .Reverse();

                foreach (var neighbour in neighbours)
                {
                    stack.Push(neighbour);
                }
            }

            return result;
        }
    }
}