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
            var stack = new Stack<Node>(); // Используем стэк для поиска в глубину

            stack.Push(node); // Добавляем узел в стэк

            while (stack.Count != 0) // Пока количество элементов в стэке не равно 0
            {
                var current = stack.Pop(); // Вытягиваем узел из стэка

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
                // .Reverse() переворачиваем отсортированный массив (то есть делаем его по убыванию)
                var neighbours = current.Edges
                    .Where(_ => !visited.Contains(_.Value))
                    .OrderBy(_ => _.Value)
                    .Reverse();

                // Проходимся по выбранным узлам и добаляем их в стэк
                foreach (var neighbour in neighbours)
                {
                    stack.Push(neighbour);
                }
            }

            return result;
        }
    }
}