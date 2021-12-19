using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Graphs.Structure.Traversals;

namespace Graphs.Structure
{
    public class Graph
    {
        /// <summary>
        /// Проход графа
        /// </summary>
        private ITraversalStrategy _traversalStrategy;

        /// <summary>
        /// Все узлы которые есть в графе
        /// </summary>
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

        /// <summary>
        /// Добавление узла
        /// </summary>
        /// <param name="nodeValue">Значение узла</param>
        /// <returns></returns>
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

        /// <summary>
        /// Создать связь между двумя узлами
        /// </summary>
        /// <param name="firstValue">Значение первого узла</param>
        /// <param name="secondValue">Значение второго узла</param>
        /// <returns></returns>
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

        /// <summary>
        /// Получить значения всех узлов
        /// </summary>
        /// <returns></returns>
        public IEnumerable<int> GetAllValueNodes()
        {
            // Select переобразует список узлов в список значений узлов (в нашем случае список int)
            return nodes.Select(_ => _.Value);
        }

        /// <summary>
        /// Очистить граф
        /// </summary>
        public void Clear()
        {
            nodes = new List<Node>();
        }
    
        /// <summary>
        /// Является ли граф связным
        /// </summary>
        /// <returns></returns>
        public bool IsGraphConnected()
        {
            // Any() возвращает true если есть эелементы в списке nodes, если элементов нет, то возвращает false
            // All(node => node.Edges.Any()), возвращает true если каждый узел, из списка nodes, содержит связные узлы
            return nodes.Any() && nodes.All(node => node.Edges.Any());
        }

        /// <summary>
        /// Возвращает список после обхода
        /// </summary>
        /// <param name="nodeValue">Узел с которого нужно начать обход</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public IEnumerable<int>? Traversal(int nodeValue)
        {
            // Если граф не связный, генерируется исключение об ошибку
            if (!IsGraphConnected())
            {
                throw new ArgumentException("Граф не связный");
            }

            // Получаем узел у которого значение равно nodeValue
            var node = nodes.FirstOrDefault(_ => _.Value == nodeValue);

            // Если узел не найден, то возвращаем  null, иначе делаем обход
            return node is null ? null : TraversalStrategy.Traversal(node);
        }
    }
}
