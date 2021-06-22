using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Exceptions
{
    public class EntityException : Exception
    {
        public EntityException(string msg):base(msg)
        {

        }
    }
}
