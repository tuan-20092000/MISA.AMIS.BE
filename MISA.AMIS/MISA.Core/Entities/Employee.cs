using MISA.Core.AttributeEntity;
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
        [MISARequired]
        [MISALength(8)]
        public string EmployeeCode { get; set; }

        /// <summary>
        /// tên nhân viên
        /// </summary>
        [MISARequired]
        [MISALength(100)]
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
        [MISARequired]
        public string DepartmentName { get; set; }

        /// <summary>
        /// số chứng minh nhân dân
        /// </summary>
        [MISALength(12)]
        public string IdentityNumber { get; set; }

        /// <summary>
        /// ngày cấp chứng minh nhân dân
        /// </summary>
        public DateTime? IdentityDate { get; set; } = null;

        /// <summary>
        /// nơi cấp chứng minh nhân dân
        /// </summary>
        [MISALength(255)]
        public string IdentityPlace { get; set; }

        /// <summary>
        /// chức vụ nhân viên
        /// </summary>
        [MISALength(255)]
        public string EmployeePosition { get; set; }

        /// <summary>
        /// địa chỉ
        /// </summary>
        [MISALength(255)]
        public string Address { get; set; }

        /// <summary>
        /// số tài khoản
        /// </summary>
        [MISALength(20)]
        public string BankAccountNumber { get; set; }

        /// <summary>
        /// tên ngân hàng
        /// </summary>
        [MISALength(255)]
        public string BankName { get; set; }

        /// <summary>
        /// chi nhánh
        /// </summary>
        [MISALength(255)]
        public string BankBranchName { get; set; }

        /// <summary>
        /// tỉnh
        /// </summary>
        [MISALength(255)]
        public string BankProvinceName { get; set; }

        /// <summary>
        /// số điện thoại di động
        /// </summary>
        [MISALength(13)]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// số điện thoại cố định
        /// </summary>
        [MISALength(13)]
        public string TelephoneNumber { get; set; }

        /// <summary>
        /// email
        /// </summary>
        [MISALength(50)]
        public string Email { get; set; }

    }
}
