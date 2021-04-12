using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestHttp
{
    public interface ISecondInstanceInaCall
    {
       IOperationTransient _transientOperation { get; set; }
       IOperationScoped _scopedOperation { get; set; }
        IOperationSingleton _singletonOperation { get; set; }
    }

    public class SecondInstanceInaCall : ISecondInstanceInaCall
    {
        public SecondInstanceInaCall(IOperationTransient transientOperation, 
                                        IOperationScoped scopedOperation, 
                                        IOperationSingleton singletonOperation)
        {
            _transientOperation = transientOperation;
            _scopedOperation = scopedOperation;
            _singletonOperation = singletonOperation;
        }

        public IOperationTransient _transientOperation { get; set; }
        public IOperationScoped _scopedOperation { get; set; }
        public IOperationSingleton _singletonOperation { get; set; }
    }
}
