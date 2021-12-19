using System.Collections.Generic;

namespace Graphs.Structure.Traversals
{
    // Интерфейс обхода, нужен для того чтобы мы могли подставить любую реализацию обхода
    public interface ITraversalStrategy
    {
        IEnumerable<int> Traversal(Node node);
    }
}