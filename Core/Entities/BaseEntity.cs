using System;

namespace Core.Entities
{
    public abstract class BaseEntity<TKey>
    {
        public TKey Id {get;set;}
    }
}