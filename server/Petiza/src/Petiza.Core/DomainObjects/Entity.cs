using System;
using System.Collections.Generic;
using System.Text;

namespace Petiza.Core.DomainObjects
{
    public class Entity
    {
        public Guid Id { get; set; }
        public Entity()
        {
            Id = Guid.NewGuid();
        }
    }
}
