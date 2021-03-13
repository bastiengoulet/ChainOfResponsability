using System;

namespace ChainOfResponsability
{
    public abstract class Handler : AbstractHandler
    {
        public override void ProcessRequest(int problemNumber, object extraParam = null)
        {
            if (problemNumber == Order)
            {
                ProcessRequest(extraParam);
            }
            else if (Successor != null)
            {
                Successor.ProcessRequest(problemNumber);
            }
            else
            {
                Console.WriteLine("\nCe choix n'existe pas!");
            }
        }

        public abstract void ProcessRequest(object extraParam = null);
    }
}
