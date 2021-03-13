using System.Collections.Generic;

namespace ChainOfResponsability
{
    public class Chain
    {
        private List<Handler> handlers;

        public Chain()
        {
            handlers = new List<Handler>();
        }

        public void Add<T>(T newHandler) where T : Handler
        {
            newHandler.Order = CurrentOrder();
            handlers.Add(newHandler);
            SetSuccessor();
        }

        public void Remove<T>(T newHandler) where T : Handler
        {
            handlers.Remove(newHandler);
        }

        public void ProcessRequest(int handlerNumber, object extraParam = null)
        {
            handlers[0].ProcessRequest(handlerNumber, extraParam);
        }

        private int CurrentOrder()
        {
            return handlers.Count + 1;
        }

        private void SetSuccessor()
        {
            if (handlers.Count >= 2)
            {
                int indexPrevious = handlers.Count - 2;
                int indexLast = handlers.Count - 1;
                handlers[indexPrevious].SetSuccessor(handlers[indexLast]);
            }
        }
    }
}
