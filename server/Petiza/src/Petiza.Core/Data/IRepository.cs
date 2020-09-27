using System;
using System.Collections.Generic;
using System.Text;

namespace Petiza.Core.Data
{
    public interface IRepository<T> : IDisposable
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
