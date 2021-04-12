using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestHttp
{
    public class ConcreteClass : IOperationTransient, IOperationScoped, IOperationSingleton
    {
        private Guid holdValue;

        public ConcreteClass()
        {
            holdValue = Guid.NewGuid();
        }

        public Guid SomeGuid
        {
            get { return holdValue; }
            set => holdValue = value;
        }
    }
}
