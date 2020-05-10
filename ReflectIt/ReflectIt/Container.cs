using System;
using System.Collections.Generic;
using System.Text;

namespace ReflectIt
{
    public class Container
    {
        public Container For<T>()
        {
            return this;
        }

        public void Use<T>()
        {
            throw new NotImplementedException();
        }

        public object Resolve<T>()
        {
            throw new NotImplementedException();
        }
    }
}
