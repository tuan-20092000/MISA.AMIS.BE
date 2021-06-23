using Dapper;
using MISA.Core.AttributeEntity;
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
        /// CreatedBy TuanNV (17/6/2021)
        public override ServiceResult Insert(Employee employee)
        {
            employee.EmployeeId = Guid.NewGuid();
            //ktra mã tồn tại hay chưa, nếu rồi thì trả về isValid = false
            if (!ValidateObject(employee))
            {
                return serviceResult;
            }
            // nếu chưa tồn tại mã thì gọi đến repo
            return _employeeRepository.Insert(employee);
        }

        // hàm check mã nhân viên tồn tại hay chưa trước khi thêm mới
        public bool CheckEmployeeCodeExist(Employee employee)
        {
            return _employeeRepository.CheckEmployeeCodeExist(employee);
        }


        /// <summary>
        /// hàm update thông tin nhân viên
        /// </summary>
        /// <param name="employee">nhân viên</param>
        /// <returns>service result có isValid = true nếu thêm mới thành công, false nếu không thành công</returns>
        /// CreatedBy TuanNV (17/6/2021)
        public override ServiceResult Update(Employee employee)
        {
            var employeeCode = employee.EmployeeCode;
            // ktra mã tồn tại hay chưa trước khi cất, nếu rồi thì trả về isValid service result = false
            if (!ValidateObject(employee))
            {
                return serviceResult;
            }

            // nếu chưa thì gọi tới repo
            return _employeeRepository.Update(employee);
        }

        /// <summary>
        /// override hàm validate object từ base service
        /// </summary>
        /// <param name="entity">thực thể cần validate</param>
        /// <returns>true nếu hợp lệ, false nếu không</returns>
        public override bool ValidateObject(Employee entity)
        {
            if (entity is Employee)
            {
                // lấy tất cả các property của class
                var properties = typeof(Employee).GetProperties();
                foreach (var property in properties)
                {
                    var requiredProperties = property.GetCustomAttributes(typeof(MISARequired), true);
                    if (requiredProperties.Length > 0)
                    {
                        // lấy giá trị
                        var propertyValue = property.GetValue(entity);
                        // kiểm tra giá trị
                        if (propertyValue == null || string.IsNullOrEmpty(propertyValue.ToString()))
                        {
                            serviceResult.MISACode = Enum.MISACode.ValueRequiredEmpty;
                            var fieldName = property.Name;
                            var fieldNameRequired = (requiredProperties[0] as MISARequired).PropertyName;
                            serviceResult.Messengers.Add($"{fieldNameRequired} {Properties.Resources.Msg_Error_Required}");
                            serviceResult.Data.Add(entity);
                            serviceResult.EFieldError = fieldName;
                            return false;
                        }
                    }
                }


                // check trùng mã
                if (CheckEmployeeCodeExist(entity))
                {
                    var employeeCode = entity.EmployeeCode;
                    serviceResult.MISACode = Enum.MISACode.DuplicateValue;
                    serviceResult.Messengers.Add($"{Properties.Resources.Msg_Employee} <{employeeCode}> {Properties.Resources.Msg_Duplicate_EmployeeCode}");
                    serviceResult.Data.Add(entity);
                    serviceResult.EFieldError = "EmployeeCode";
                    return false;
                }

                return true;
            }
            else
            {
                serviceResult.MISACode = Enum.MISACode.InvalidValue;
                serviceResult.Messengers.Add(Properties.Resources.Msg_Param_Error);
                serviceResult.Data.Add(entity);
                return false;
            }

            
        }

        #endregion
    }


}
