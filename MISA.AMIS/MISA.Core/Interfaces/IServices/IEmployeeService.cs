using MISA.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Interfaces.IServices
{
    public interface IEmployeeService : IBaseService<Employee>
    {
        /// <summary>
        /// hàm check trùng mã trước khi cất
        /// </summary>
        /// <param name="employee">thông tin nhân viên</param>
        /// <returns>true nếu trùng, false nếu không trùng</returns>
        /// CreatedBy TuanNV (17/6/2021)
        bool CheckEmployeeCodeExist(Employee employee);

        /// <summary>
        /// hàm validate dữ liệu trước khi cất
        /// </summary>
        /// <param name="employee">thông tin nhân viên</param>
        /// <returns>true nếu hợp lệ, false nếu không hợp lệ</returns>
        /// CreatedBy TuanNV (17/6/2021)
    }
}
