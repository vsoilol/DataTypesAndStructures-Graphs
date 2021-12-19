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
        /// <summary>
        /// IEnumerable обозначает что мы можем перебирать эти данные (в нашем случае result) с помощью foreach
        /// </summary>
        /// <param name="node">Узел с которого начинается обход</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public IEnumerable<int> Traversal(Node node)
        {
            // Если узел не содержит связных узлов, то генерируем исключение об ошибке
            if (!node.Edges.Any())
            {
                throw new ArgumentException("Данный узел не содержит потомков");
            }

            var result = new List<int>(); // результат обхода
            var visited = new HashSet<int>(); // значение посещенных узлов (используем множество, потому что значение узлов не должно повторяться)
            var queue = new Queue<Node>(); // Используем очередь для поиска в ширину
            queue.Enqueue(node); // Добавляем значение узла в очередь

            while (queue.Count > 0) // Пока количество элементов в очереди больше 0
            {
                var current = queue.Dequeue(); // Вытягиваем узел из очереди

                // Добавляем в множество значений посещенных узлов, значение текущего узла
                // если такой значение нету в множестве, то добавляем его и возвращаем true
                // иначе, если такое значение уже есть в множестве, то возвращаем false
                if (visited.Add(current.Value))
                {
                    // Добавляем в result значение узла
                    result.Add(current.Value);
                }

                // .Where(_ => !visited.Contains(_.Value)) означает что мы берем все связные узлы которые не содержаться в множестве visited
                // .OrderBy(_ => _.Value) сортируем выбранные узлы по значению узла, по возрастани.
                var neighbours = current.Edges
                    .Where(_ => !visited.Contains(_.Value))
                    .OrderBy(_ => _.Value);

                // Проходимся по выбранным узлам и добаляем их в очередь
                foreach (var neighbour in neighbours)
                {
                    queue.Enqueue(neighbour);
                }
            }

            return result;
        }
    }
}