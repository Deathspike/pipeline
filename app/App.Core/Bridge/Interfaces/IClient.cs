namespace App.Core.Bridge
{
    public interface IClient
    {
        void Submit(string functionName, SubmitData data);
    }
}