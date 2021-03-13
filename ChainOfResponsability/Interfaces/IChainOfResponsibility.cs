namespace ChainOfResponsability
{
    public interface IChainOfResponsibility
    {
        int Order { get; }
        IChainOfResponsibility Successor { get; }
        void SetSuccessor(IChainOfResponsibility successor);
        void ProcessRequest(int problemNumber, object extraParam = null);
    }
}
