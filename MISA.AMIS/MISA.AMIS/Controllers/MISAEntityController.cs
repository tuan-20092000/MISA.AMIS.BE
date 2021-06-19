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
        // GET: api/<MISAEntityController>
        [HttpGet]
        public IActionResult Get()
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

        // GET api/<CustomerController>/5
        [HttpGet("{entityId}")]
        public IActionResult Get(Guid entityId)
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

        // POST api/<CustomerController>
        [HttpPost]
        public IActionResult Post([FromBody] MISAEntity entity)
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

        // PUT api/<CustomerController>/5
        [HttpPut]
        public IActionResult Put([FromBody] MISAEntity entity)
        {
            var result = _baseService.Update(entity);
            if (result.isValid == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{entityId}")]
        public IActionResult Delete(Guid entityId)
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

        #endregion
    }
}
