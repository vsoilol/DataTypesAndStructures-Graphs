using System.Collections.Generic;

namespace Graphs.Structure.Traversals
{
    public interface ITraversalStrategy
    {
        IEnumerable<int> Traversal(Node node);
    }
}