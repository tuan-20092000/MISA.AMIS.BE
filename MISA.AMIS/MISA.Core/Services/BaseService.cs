using MISA.Core.Entities;
using MISA.Core.Interfaces.Ifarstructures;
using MISA.Core.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Services
{
    public class BaseService<MISAEntity> : IBaseService<MISAEntity>
    {
        #region fields
        IBaseRepository<MISAEntity> _baseRepository;

        // kết quả trả về cho controller
        ServiceResult serviceResult = new ServiceResult();
        #endregion


        #region Constructor
        public BaseService(IBaseRepository<MISAEntity> baseRepository)
        {
            _baseRepository = baseRepository;
        }
        #endregion

        #region Methods

        // hàm thêm mới nhân viên
        public virtual ServiceResult Insert(MISAEntity entity)
        {
            return _baseRepository.Insert(entity);
        }


        // hàm update thông tin nhân viên
        public virtual ServiceResult Update(MISAEntity entity)
        {
            return _baseRepository.Update(entity);
        }
        #endregion
    }
}
