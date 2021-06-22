using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.AttributeEntity
{
    [AttributeUsage(AttributeTargets.Property)]

    public class MISARequired : Attribute
    {
        
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class MISALength : Attribute
    {
        public int MaxLength = 0;
        public MISALength(int maxLength = 0)
        {
            MaxLength = maxLength;
        }
    }
}
