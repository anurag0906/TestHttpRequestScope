using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestHttp
{
    public interface ISomeOperation
    {
        Guid SomeGuid { get; set; }
    }

    public interface IOperationTransient : ISomeOperation
    {
    }

    public interface IOperationScoped : ISomeOperation
    {
    }

    public interface IOperationSingleton : ISomeOperation
    {
    }

}
