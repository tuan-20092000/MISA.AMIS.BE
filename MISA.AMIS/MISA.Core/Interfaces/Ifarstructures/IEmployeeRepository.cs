using MISA.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Interfaces.Ifarstructures
{
    public interface IEmployeeRepository : IBaseRepository<Employee>
    {
        // hàm ktra mã nhân viên tồn tại hay chưa trước khi cất
        bool CheckEmployeeCodeExist(Employee employee);


        // hàm lấy ra số lượng bản ghi theo từ khóa
        int GetTotalRecord(string key);


        // hàm lấy ra mã nhân viên lớn nhất trong db
        string GetMaxEmployeeCode();

        // hàm lấy ra list nhân viên theo trang, số lương bản ghi và từ khóa
        List<Employee> GetEmployeePage(int page, int countPerPage, string keySearch);
    }
}
