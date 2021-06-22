using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.Core.Entities;
using MISA.Core.Interfaces.Ifarstructures;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Ifarstructure.Repository
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        #region Constructor
        public EmployeeRepository(IConfiguration configuration) : base(configuration)
        {

        }
        #endregion

        #region Methods

        /// <summary>
        /// hàm check mã nhân viên trước khi thêm mới
        /// </summary>
        /// <param name="EmployeeCode">mã nhân viên</param>
        /// <returns>true nếu đã tồn tại, false nếu chưa tồn tại</returns>
        public bool CheckEmployeeCodeExist(Employee employee)
        {
              // procedure check mã nhân viên trước khi sửa
              var procedure = $"Proc_Check{ClassName}CodeExist";

              // tạo dynamic và thêm tham số
              DynamicParameters dynamic = new DynamicParameters();
              dynamic.Add("@EmployeeId", employee.EmployeeId.ToString());
              dynamic.Add("@EmployeeCode", employee.EmployeeCode);

              // truy vấn và trả về kết quả
              var res = DbConnection.Query<bool>(procedure, dynamic, commandType: CommandType.StoredProcedure).FirstOrDefault();
              return res;
           
        }

        /// <summary>
        /// hàm lấy số lượng bản ghi theo từ khóa
        /// </summary>
        /// <param name="keySearch">từ khóa tìm kiếm</param>
        /// <returns>số bản ghi tìm thấy được</returns>
        public int GetTotalRecord(string keySearch)
        {
              // procedure lấy số lượng bản ghi theo từ khóa tìm kiếm
              var procedure = $"Proc_GetToTalRecord";

              // tạo dynamic và thêm tham số
              DynamicParameters dynamic = new DynamicParameters();
              dynamic.Add("@keySearch", keySearch);

              // truy vấn và trả về kết quả
              var res = DbConnection.Query<int>(procedure, dynamic, commandType: CommandType.StoredProcedure).FirstOrDefault();
              return res;
        }

        /// <summary>
        /// hàm lấy ra mã nhân viên lớn nhất
        /// </summary>
        /// <returns>mã nhân viên lớn nhất</returns>
        /// Createdby TuanNV (17/6/2021)
        public string GetMaxEmployeeCode()
        {
              // procedure lấy ra mã nhân viên lớn nhất
              var procedure = $"Proc_GetMaxEmployeeCode";

              // truy vấn và trả về kết quả
              var res = DbConnection.Query<string>(procedure, commandType: CommandType.StoredProcedure).FirstOrDefault();
              return res;
        }

        /// <summary>
        /// hàm lấy ra nhân viên theo trang, số lượng bản ghi/trang và từ khóa tìm kiếm
        /// </summary>
        /// <param name="page">trang</param>
        /// <param name="countPerPage">số lượng bản ghi/trang</param>
        /// <param name="keySearch">từ khóa tìm kiếm</param>
        /// <returns>list employee</returns>
        /// Createdby TuanNV (17/6/2021)
        public List<Employee> GetEmployeePage(int page, int countPerPage, string keySearch)
        {
              // tiền xử lý
              if (page < 1 || countPerPage < 1) return null;
              var startIndex = (page - 1) * countPerPage;

              // procedure lấy ra nhân viên theo điều kiện
              var procedure = "Proc_GetEmployeePage";

              // tạo dynamic param và thêm tham số
              DynamicParameters dynamic = new DynamicParameters();
              dynamic.Add("@startIndex", startIndex);
              dynamic.Add("@countPerPage", countPerPage);
              dynamic.Add("@keySearch", keySearch);

              // truy vấn và trả về kết quả
              var res = DbConnection.Query<Employee>(procedure, dynamic, commandType: CommandType.StoredProcedure).ToList();
              return res;
        }

        /// <summary>
        /// lấy tất cả bản ghi theo từ khóa tìm kiếm
        /// </summary>
        /// <param name="keySearch">từ khóa tìm kiếm</param>
        /// <returns>tất cả bản ghi phù hợp</returns>
        /// Createdby TuanNV (17/6/2021)
        public List<Employee> GetAllDataRecord(string keySearch)
        {
              var procedure = "Proc_GetAllData";
              DynamicParameters dynamic = new DynamicParameters();
              dynamic.Add("@keySearch", keySearch);

              var res = DbConnection.Query<Employee>(procedure, dynamic, commandType: CommandType.StoredProcedure).ToList();
              return res;
            
        }

        #endregion
    }
}
