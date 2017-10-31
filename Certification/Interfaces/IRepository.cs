using System.Collections.Generic;

namespace Certification.Interfaces
{
    interface IRepository<T>
    {
        T FindById(int id);
        IEnumerable<T> All();
    }
}
