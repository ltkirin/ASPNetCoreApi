using ASPNetCoreApi.Models.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCoreApi.Models.Factory.interfaces
{
    public interface IModelFactory<T>
        where T : BaseModel
    {
        T Get(IList<string> props);

        T Get(int id, IList<string> props);
    }
}
