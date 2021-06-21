using Microsoft.AspNetCore.Mvc;
using MISA.Core.Interfaces.Ifarstructures;
using MISA.Core.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.AMIS.Controllers
{
    [Route("api/v1/[controller]s")]
    [ApiController]
    public class MISAEntityController<MISAEntity> : ControllerBase
    {
        #region Declare
        IBaseRepository<MISAEntity> _baseRepository;
        IBaseService<MISAEntity> _baseService;
        #endregion

        #region Constructor
        public MISAEntityController(IBaseRepository<MISAEntity> baseRepository, IBaseService<MISAEntity> baseService)
        {
            _baseRepository = baseRepository;
            _baseService = baseService;
        }
        #endregion

        #region Methods
        /// <summary>
        /// API lấy ra tất cả thực thể trong csdl
        /// </summary>
        /// <returns>tất cả các bản ghi</returns>
        /// CreatedBy TuanNV (17/6/2021)
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var entities = _baseRepository.GetAll();
                if (entities.Count > 0)
                {
                    return Ok(entities);
                }
                else
                {
                    return NoContent();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// API lấy ra thực thể theo id
        /// </summary>
        /// <param name="entityId">id thực thể</param>
        /// <returns>bản ghi có id trùng với id truyền vào</returns>
        /// CreatedBy TuanNV (17/6/2021)
        [HttpGet("{entityId}")]
        public IActionResult Get(Guid entityId)
        {
            try
            {
                var entity = _baseRepository.GetById(entityId);
                if (entity != null)
                {
                    return Ok(entity);
                }
                else
                {
                    return NoContent();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// API thêm mới 1 bản ghi
        /// </summary>
        /// <param name="entity">bản ghi</param>
        /// <returns>service result có isValid = true nếu thêm thành công, false nếu thêm thất bại</returns>
        /// CreatedBy TuanNV (17/6/2021)
        [HttpPost]
        public IActionResult Post([FromBody] MISAEntity entity)
        {
            try
            {
                var result = _baseService.Insert(entity);
                if (result.isValid == true)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest(result);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// API sửa thông tin 1 bản ghi
        /// </summary>
        /// <param name="entity">thực thể</param>
        /// <returns>service result có isValid = true nếu sửa thành công, false nếu sửa thất bại</returns>
        /// CreatedBy TuanNV (17/6/2021)
        [HttpPut]
        public IActionResult Put([FromBody] MISAEntity entity)
        {
            try
            {
                var result = _baseService.Update(entity);
                if (result.isValid == true)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }
            catch(Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// API xóa 1 bản ghi
        /// </summary>
        /// <param name="entityId">ID thực thể</param>
        /// <returns>1 nếu xóa thành công, 0 nếu xóa thất bại</returns>
        /// CreatedBy TuanNV (17/6/2021)
        [HttpDelete("{entityId}")]
        public IActionResult Delete(Guid entityId)
        {
            try
            {
                var rowAffect = _baseRepository.Delete(entityId);
                if (rowAffect > 0)
                {
                    return Ok(rowAffect);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion
    }
}
