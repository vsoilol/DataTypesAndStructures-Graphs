using Graphs.Structure.Traversals;

namespace Graphs.UI.Presenters
{
    public interface IGraphPresenter
    {
        void CreateNode();

        void CreateEdge();

        void DisplayNodes();

        void DisplayGraph(ITraversalStrategy traversalStrategy);
        
        void CreateDefaultGraph();
        
        void IsGraphConnected();
        
        void ClearGraph();
    }
}