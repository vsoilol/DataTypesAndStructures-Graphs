using System;
using System.Collections.Generic;
using System.Linq;

namespace Graphs.Structure.Traversals
{
    /// <summary>
    /// Поиск в ширину
    /// </summary>
    public class BreadthFirstSearchTraversal : ITraversalStrategy
    {
        public IEnumerable<int> Traversal(Node node)
        {
            if (!node.Edges.Any())
            {
                throw new ArgumentException("Данный узел не содержит потомков");
            }

            var result = new List<int>();
            var visited = new HashSet<int>();
            var queue = new Queue<Node>();
            queue.Enqueue(node);

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();

                if (visited.Add(current.Value))
                {
                    result.Add(current.Value);
                }

                var neighbours = current.Edges
                    .Where(_ => !visited.Contains(_.Value))
                    .OrderBy(_ => _.Value);

                foreach (var neighbour in neighbours)
                {
                    queue.Enqueue(neighbour);
                }
            }

            return result;
        }
    }
}