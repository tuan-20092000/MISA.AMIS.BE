using Microsoft.AspNetCore.Mvc;
using MISA.Core.Entities;
using MISA.Core.Interfaces.Ifarstructures;
using MISA.Core.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.AMIS.Controllers
{
    public class EmployeeController : MISAEntityController<Employee>
    {
        #region Fields
        IEmployeeRepository _employeeRepository;
        IEmployeeService _employeeService;
        #endregion

        #region Constructor
        public EmployeeController(IEmployeeRepository employeeRepository, IEmployeeService employeeService)
            :base(employeeRepository, employeeService)
        {
            _employeeRepository = employeeRepository;
            _employeeService = employeeService;
        }
        #endregion


        #region API

        /// <summary>
        /// API lấy ra tổng số bản ghi tìm được theo từ khóa tìm kiếm
        /// </summary>
        /// <param name="keySearch">từ khóa tìm kiếm</param>
        /// <returns>số lượng bản ghi tìm thấy</returns>
        /// CreatedBy TuanNV (17/6/2021)
        [HttpPost("GetTotalRecord")]
        public IActionResult GetTotalRecord([FromBody]string keySearch)
        {
            try
            {
                var res = _employeeRepository.GetTotalRecord(keySearch);
                return Ok(res);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// API lấy ra mã nhân viên lớn nhất trong csdl
        /// </summary>
        /// <returns>mã nhân viên lớn nhất</returns>
        /// CreatedBy TuanNV (17/6/2021)
        [HttpGet("GetMaxCode")]
        public IActionResult GetMaxCode()
        {
            try
            {
                var res = _employeeRepository.GetMaxEmployeeCode();
                return Ok(res);
            }
            catch (Exception) 
            { 
                throw; 
            }
        }


        /// <summary>
        /// API lấy ra nhân viên theo trang, số lương bản ghi và từ khóa tìm kiếm
        /// </summary>
        /// <param name="page">trang</param>
        /// <param name="count">số lượng bản ghi/trang</param>
        /// <param name="keySearch">từ khóa tìm kiếm</param>
        /// <returns>list nhân viên</returns>
        /// CreatedBy TuanNV (17/6/2021)
        [HttpPost("GetPage")]
        public IActionResult GetEmployeePage(int page, int count, [FromBody]string keySearch)
        {
            try
            {
                var res = _employeeRepository.GetEmployeePage(page, count, keySearch);
                if (res.Count > 0)
                {
                    return Ok(res);
                }
                return NoContent();
            }
            catch (Exception) 
            { 
                throw; 
            }
        }

        /// <summary>
        /// API lấy ra tất cả các bản ghi theo từ khóa tìm kiếm
        /// </summary>
        /// <param name="keySearch">từ khóa tìm kiếm</param>
        /// <returns>list các bản ghi</returns>
        /// CreatedBy TuanNV (17/6/2021)
        [HttpPost("GetAllData")]
        public IActionResult GetAllData([FromBody] string keySearch)
        {
            try
            {
                var res = _employeeRepository.GetAllDataRecord(keySearch);
                if (res.Count > 0)
                {
                    return Ok(res);
                }
                return NoContent();
            }
            catch (Exception) 
            { 
                throw; 
            }
        }
        #endregion
    }
}
