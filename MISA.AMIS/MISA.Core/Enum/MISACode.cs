using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Enum
{
    /// <summary>
    /// các loại mã
    /// </summary>
    /// CreatedBy TuanNV (17/6/2021)
    public enum MISACode
    {
        /// <summary>
        /// Mã thành công
        /// </summary>
        /// CreatedBy TuanNV (17/6/2021)
        Success = 200,

        /// <summary>
        /// Mã giá trị không hợp lệ
        /// </summary>
        /// CreatedBy TuanNV (17/6/2021)
        InvalidValue = 400,

        /// <summary>
        /// Mã dữ liệu bị trùng
        /// </summary>
        /// CreatedBy TuanNV (17/6/2021)
        DuplicateValue = 600,

        /// <summary>
        /// Mã không có nội dung
        /// </summary>
        /// CreatedBy TuanNV (17/6/2021)
        NoContent = 204,

        /// <summary>
        /// Mã thể hiện trường bắt buộc nhập bị bỏ trống
        /// </summary>
        /// CreatedBy TuanNV (17/6/2021)
        ValueRequiredEmpty = 700,

        /// <summary>
        /// Mã lỗi thể hiện thao tác với csdl thất bại
        /// </summary>
        ErrorAccessDB = 550

    }
}
