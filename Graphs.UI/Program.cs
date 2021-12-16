using System;
using ConsoleTools;
using Graphs.Structure.Traversals;
using Graphs.UI.Presenters;
using Graphs.UI.Providers;

namespace Graphs.UI
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            IGraphPresenter graphPresenter = new GraphPresenter(new ConsoleProvider());
            
            Console.ForegroundColor = ConsoleColor.Gray;
            var menu = new ConsoleMenu(args, level: 0)
                .Add("Добавить узел", graphPresenter.CreateNode)
                .Add("Является ли граф связным", graphPresenter.IsGraphConnected)
                .Add("Очистить граф", graphPresenter.ClearGraph)
                .Add("Создать связь между узлами", graphPresenter.CreateEdge)
                .Add("Показать все узлы", graphPresenter.DisplayNodes)
                .Add("Создать граф по умолчанию", graphPresenter.CreateDefaultGraph)
                .Add("Поиск в ширину", () => graphPresenter.DisplayGraph(new BreadthFirstSearchTraversal()))
                .Add("Поиск в глубину", () => graphPresenter.DisplayGraph(new DepthFirstSearchTraversal()))
                .Add("Выход", ConsoleMenu.Close)
                .Configure(config =>
                {
                    config.Selector = "--> ";
                    config.EnableFilter = false;
                    config.Title = "Операции с графом";
                    config.EnableWriteTitle = true;
                });

            menu.Show();
        }
    }
}