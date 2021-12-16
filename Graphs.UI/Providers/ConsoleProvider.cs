using System;
using Graphs.UI.Resources;

namespace Graphs.UI.Providers
{
    internal class ConsoleProvider : IUIProvider
    {
        public int GetIntData(string message)
        {
            Console.Write(message);

            int result;
            while (!int.TryParse(Console.ReadLine(), out result))
            {
                Console.WriteLine(UIResources.ErrorFormat);
                Console.Write(message);
            }

            return result;
        }

        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}