namespace Graphs.UI.Providers
{
    internal interface IUIProvider
    {
        int GetIntData(string message);
        
        void ShowMessage(string message);
    }
}