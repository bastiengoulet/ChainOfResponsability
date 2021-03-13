using System;

namespace ChainOfResponsability
{
    public abstract class AbstractHandler : IChainOfResponsibility, IExtraParamUser
    {
        public int Order { get; set; }
        public IChainOfResponsibility Successor { get; private set; }

        public void SetSuccessor(IChainOfResponsibility successor)
        {
            Successor = successor;
        }

        public bool ExtraParamOfRightType<T>(object extraParam)
        {
            return extraParam is T;
        }

        public T ConvertExtraParam<T>(object extraParam)
        {
            if (ExtraParamOfRightType<T>(extraParam))
            {
                return (T)extraParam;
            }

            try
            {
                return (T)Convert.ChangeType(extraParam, typeof(T));
            }
            catch (InvalidCastException)
            {
                return default(T);
            }
        }

        public abstract void ProcessRequest(int problemNumber, object extraParam = null);
    }
}
