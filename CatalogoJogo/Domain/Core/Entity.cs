using System;

namespace CatalogoJogo.Domain.Core
{
    public abstract class Entity
    {
        public Guid Id { get; protected set; }
    }
}