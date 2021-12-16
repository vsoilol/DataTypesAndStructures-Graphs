using System.Linq;
using Graphs.Structure;
using Graphs.Structure.Traversals;
using Graphs.UI.Extensions;
using Graphs.UI.Providers;
using Graphs.UI.Resources;

namespace Graphs.UI.Presenters
{
    internal class GraphPresenter : IGraphPresenter
    {
        private readonly Graph _graph;
        private readonly IUIProvider _uiProvider;

        public GraphPresenter(IUIProvider uiProvider)
        {
            _uiProvider = uiProvider;
            _graph = new Graph();
        }

        public void CreateNode()
        {
            var value = _uiProvider.GetIntData(UIResources.EnterValueNodeToAdd);
            
            if (!_graph.AddNode(value))
            {
                _uiProvider.ShowMessage(UIResources.NodeIsAlreadyExist);
                return;
            }

            _uiProvider.ShowMessage(UIResources.NodeSuccessfullyAdded);
        }

        public void CreateEdge()
        {
            var firstValue = _uiProvider.GetIntData(UIResources.EnterValueNodeToAdd);
            var secondValue = _uiProvider.GetIntData(UIResources.EnterValueNodeToAdd);

            if (!_graph.CreateEdge(firstValue, secondValue))
            {
                _uiProvider.ShowMessage(UIResources.ErrorCreateEdge);
                return;
            }

            _uiProvider.ShowMessage(UIResources.EdgeSuccessfullyAdded);
        }

        public void DisplayNodes()
        {
            var nodes = _graph.GetAllValueNodes();

            if (!nodes.Any())
            {
                _uiProvider.ShowMessage(UIResources.NodesIsEmpty);
                return;
            }
            
            var nodesText = nodes.GetArrayStringWithMessage(UIResources.AllNodes);
            _uiProvider.ShowMessage(nodesText);
        }

        public void DisplayGraph(ITraversalStrategy traversalStrategy)
        {
            _graph.TraversalStrategy = traversalStrategy;
            
            var nodeValue = _uiProvider.GetIntData(UIResources.EnterValueNodeToAdd);
            var values = _graph.Traversal(nodeValue);

            if (values is null || !values.Any())
            {
                _uiProvider.ShowMessage(UIResources.ErrorTraversal);
                return;
            }
            
            var valuesText = values.GetArrayStringWithMessage(UIResources.AfterTraversal);
            _uiProvider.ShowMessage(valuesText);
        }

        public void CreateDefaultGraph()
        {
            _graph.Clear();

            for (var i = 1; i <= 8; i++)
            {
                _graph.AddNode(i);
            }

            _graph.CreateEdge(1, 3);
            _graph.CreateEdge(1, 4);
            
            _graph.CreateEdge(6, 8);
            _graph.CreateEdge(6, 2);

            _graph.CreateEdge(8, 1);
            _graph.CreateEdge(8, 2);
            
            _graph.CreateEdge(2, 4);
            
            _graph.CreateEdge(7, 1);
            _graph.CreateEdge(7, 3);
            _graph.CreateEdge(7, 5);
            
            _uiProvider.ShowMessage(UIResources.GraphSuccessfullyCreated);
        }

        public void IsGraphConnected()
        {
            _uiProvider
                .ShowMessage(_graph.IsGraphConnected() ? UIResources.GraphConnected : UIResources.GraphNotConnected);
        }

        public void ClearGraph()
        {
            _graph.Clear();
            _uiProvider.ShowMessage(UIResources.GraphSuccessfullyClear);
        }
    }
}