using System;
using System.Collections.Generic;
using System.Text;

namespace TavSystem.Entities.BaseClass
{
    public interface IEntity
    {
    }

    public abstract class BaseEntity<TKey> : IEntity
    {
        public TKey Id { get; set; }
    }
}
