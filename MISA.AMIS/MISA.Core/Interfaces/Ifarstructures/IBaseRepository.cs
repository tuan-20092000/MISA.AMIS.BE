using MISA.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Interfaces.Ifarstructures
{
    public interface IBaseRepository<MISAEntity>
    {

        /// <summary>
        /// lấy tất cả bản ghi
        /// </summary>
        /// <returns>tất cả bản ghi trong bảng csdl</returns>
        /// CreatedBy TuanNV (17/6/2021)
        List<MISAEntity> GetAll();

        /// <summary>
        /// lấy ra thực thể có mã là entityId
        /// </summary>
        /// <param name="entityId">ID thực thể</param>
        /// <returns>trả về thực thể có Id là entityId</returns>
        /// CreatedBy TuanNV (17/6/2021)
        MISAEntity GetById(Guid entityId);

        /// <summary>
        /// thêm 1 thực thể
        /// </summary>
        /// <param name="entity">thực thể</param>
        /// <returns>trả về số lượng bản ghi bị ảnh hưởng (thêm được)</returns>
        /// CreatedBy TuanNV (17/6/2021)
        ServiceResult Insert(MISAEntity entity);

        /// <summary>
        /// hàm update thực thể
        /// </summary>
        /// <param name="entity">thực thể</param>
        /// <param name="entityId">id của thực thể</param>
        /// <returns>số lượng bản ghi update được </returns>
        /// CreatedBy TuanNV (17/6/2021)
        ServiceResult Update(MISAEntity entity);

        /// <summary>
        /// xóa 1 thực thể
        /// </summary>
        /// <param name="entityId">Id của thực thể</param>
        /// <returns>số lượng bản ghi xóa được</returns>
        /// CreatedBy TuanNV (17/6/2021)
        ServiceResult Delete(Guid entityId);
    }
}
