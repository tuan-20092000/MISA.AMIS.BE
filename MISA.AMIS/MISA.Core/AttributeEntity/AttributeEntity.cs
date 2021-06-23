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
        /// <summary>
        /// Tên của thuộc tính
        /// </summary>
        /// CreatedBy TuanNV (17/6/2021)
        public string PropertyName;

        public MISARequired(string propertyName = "")
        {
            PropertyName = propertyName;
        }
    }
}
