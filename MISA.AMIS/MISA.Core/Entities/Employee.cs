using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Entities
{
    public class Employee
    {
        /// <summary>
        /// id nhân viên
        /// </summary>
        public Guid EmployeeId { get; set; }

        /// <summary>
        /// mã nhân viên
        /// </summary>
        public string EmployeeCode { get; set; }

        /// <summary>
        /// tên nhân viên
        /// </summary>
        public string EmployeeName { get; set; }

        /// <summary>
        /// giới tính
        /// </summary>
        public int Gender { get; set; }

        /// <summary>
        /// ngày sinh
        /// </summary>
        public DateTime? DateOfBirth { get; set; } = null;

        /// <summary>
        /// đơn vị
        /// </summary>
        public string DepartmentName { get; set; }

        /// <summary>
        /// số chứng minh nhân dân
        /// </summary>
        public string IdentityNumber { get; set; }

        /// <summary>
        /// ngày cấp chứng minh nhân dân
        /// </summary>
        public DateTime? IdentityDate { get; set; } = null;

        /// <summary>
        /// nơi cấp chứng minh nhân dân
        /// </summary>
        public string IdentityPlace { get; set; }

        /// <summary>
        /// chức vụ nhân viên
        /// </summary>
        public string EmployeePosition { get; set; }

        /// <summary>
        /// địa chỉ
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// số tài khoản
        /// </summary>
        public string BankAccountNumber { get; set; }

        /// <summary>
        /// tên ngân hàng
        /// </summary>
        public string BankName { get; set; }

        /// <summary>
        /// chi nhánh
        /// </summary>
        public string BankBranchName { get; set; }

        /// <summary>
        /// tỉnh
        /// </summary>
        public string BankProvinceName { get; set; }

        /// <summary>
        /// số điện thoại di động
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// số điện thoại cố định
        /// </summary>
        public string TelephoneNumber { get; set; }

        /// <summary>
        /// email
        /// </summary>
        public string Email { get; set; }

    }
}
