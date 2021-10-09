using System;

namespace CatalogoJogo.Domain.Core
{
    public class DomainCoreException : Exception
    {
        public DomainCoreException(string message) : base(message) { }
    }
}