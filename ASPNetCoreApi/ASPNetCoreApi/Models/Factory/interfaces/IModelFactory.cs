using ASPNetCoreApi.Models.common;
using System.Collections.Generic;

namespace ASPNetCoreApi.Models.Factory.interfaces
{
    public interface IModelFactory<T>
        where T : BaseModel
    {
        T Get(IList<string> props);

        T Get(int id, IList<string> props);

        T GetEmpty();
    }
}
