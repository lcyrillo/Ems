using System;
using System.Collections.Generic;
using System.Text;

namespace CS.Ems.Domain.Interfaces.UoW
{
    public interface IUnityOfWork : IDisposable
    {
        bool Commit();
    }
}
