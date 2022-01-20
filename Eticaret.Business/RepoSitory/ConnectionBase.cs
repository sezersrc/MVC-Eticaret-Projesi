using Eticaret.Entities;

namespace Eticaret.Business
{
    public class ConnectionBase
    {
        private static readonly object _lock = new object();
        public EntityContext context;

        public ConnectionBase()
        {
            if (context == null)
                lock (_lock)
                {
                    context = new EntityContext();
                }
        }

        ~ConnectionBase()
        {
            context.Dispose();
        }
    }
}