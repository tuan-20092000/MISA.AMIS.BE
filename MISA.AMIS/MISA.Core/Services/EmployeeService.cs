using Dapper;
using MISA.Core.Entities;
using MISA.Core.Interfaces.Ifarstructures;
using MISA.Core.Interfaces.IServices;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Services
{
    public class EmployeeService : BaseService<Employee>, IEmployeeService
    {
        #region Fields
        IEmployeeRepository _employeeRepository;
        ServiceResult serviceResult = new ServiceResult();
        #endregion

        #region Constructor
        public EmployeeService(IEmployeeRepository employeeRepository) :base(employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        #endregion

        #region Methods

        /// <summary>
        /// hàm thêm mới nhân viên 
        /// </summary>
        /// <param name="employee">nhân viên/param>
        /// <returns>service result có isValid = true nếu thêm mới thành công, false nếu không thành công</returns>
        public override ServiceResult Insert(Employee employee)
        {
            var employeeCode = employee.EmployeeCode;
            //ktra mã tồn tại hay chưa, nếu rồi thì trả về isValid = false
            if (CheckEmployeeCodeExist(employeeCode))
            {
                serviceResult.isValid = false;
                serviceResult.Messengers.Add($"Mã nhân viên <{employeeCode}> đã tồn tại, vui lòng kiểm tra lại.");
                serviceResult.Data.Add(employee);
                serviceResult.VFieldError = "Mã nhân viên";
                serviceResult.EFieldError = "EmployeeCode";
                return serviceResult;
            }
            // nếu chưa tồn tại mã thì gọi đến repo
            return _employeeRepository.Insert(employee);
        }

        // hàm check mã nhân viên tồn tại hay chưa trước khi thêm mới
        public bool CheckEmployeeCodeExist(string EmployeeCode)
        {
            return _employeeRepository.CheckEmployeeCodeExist(EmployeeCode);
        }

        // hàm check mã nhân viên tồn tại hay chưa trước sửa
        public bool CheckEmployeeBeforeUpdate(Employee employee)
        {
            return _employeeRepository.CheckEmployeeBeforeUpdate(employee);
        }


        /// <summary>
        /// hàm update thông tin nhân viên
        /// </summary>
        /// <param name="employee">nhân viên</param>
        /// <returns>service result có isValid = true nếu thêm mới thành công, false nếu không thành công</returns>
        public override ServiceResult Update(Employee employee)
        {
            var employeeCode = employee.EmployeeCode;
            // ktra mã tồn tại hay chưa trước khi cất, nếu rồi thì trả về isValid service result = false
            if (CheckEmployeeBeforeUpdate(employee))
            {
                serviceResult.isValid = false;
                serviceResult.Messengers.Add($"Mã nhân viên <{employeeCode}> đã tồn tại, vui lòng kiểm tra lại.");
                serviceResult.Data.Add(employee);
                serviceResult.VFieldError = "Mã nhân viên";
                serviceResult.EFieldError = "EmployeeCode";
                return serviceResult;
            }

            // nếu chưa thì gọi tới repo
            return _employeeRepository.Update(employee);
        }

        #endregion
    }


}
