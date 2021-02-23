using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.FeeManagement.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BasesController<TEntity> : ControllerBase
    {
        #region DECLARE
        /// <summary>
        /// Khởi tạo Interface
        /// </summary>
        IBaseService<TEntity> _baseService;
        #endregion
        #region CONTRUCTOR
        /// <summary>
        /// Khởi tạo truyền tham số cho Interface
        /// </summary>
        /// <param name="baseService"></param>
        public BasesController(IBaseService<TEntity> baseService)
        {
            _baseService = baseService;
        }
        #endregion
        #region METHODS
        /// <summary>
        /// Phương thức Get để lấy dữ liệu
        /// </summary>
        /// <returns>Statuscode và data</returns>
        /// CreatedBy: PNTHANG(22/2/2021)
        [HttpGet]
        public IActionResult Get()
        {
            var result = _baseService.GetData();
            var datas = (List<TEntity>)result.Data;
            if (datas.Count == 0)
            {
                return StatusCode(204, result.Data);
            }

            return StatusCode(200, result.Data);
        }
        /// <summary>
        /// Phương thức Post để thêm mới dữ liệu
        /// </summary>
        /// <param name="entity">Đối tượng cần thêm</param>
        /// <returns>StatusCode và số bản dữ liệu thêm</returns>
        /// CreatedBy: PNTHANG(22/2/2021)
        [HttpPost]
        public IActionResult Post([FromBody] TEntity entity)
        {
            var result = _baseService.Post(entity);
            if (result.Success && (int)result.Data > 0)
            {
                return StatusCode(201, result.Data);
            }
            else if (result.Success)
                return StatusCode(204, result.Data);
            else
                return StatusCode(400, result.Data);
        }
        /// <summary>
        /// Cập nhật đối tượng
        /// </summary>
        /// <param name="entity">đối tượng sửa</param>
        /// <param name="entityCode">Mã đối tượng</param>
        /// <returns>StatusCode và số bản dữ liệu sửa</returns>
        /// CreatedBy: PNTHANG(22/2/2021)
        [HttpPut]
        public IActionResult Put([FromBody] TEntity entity, [FromQuery] string entityCode = null)
        {
            var result = _baseService.Put(entity, entityCode);
            if (result.Success && (int)result.Data > 0)
            {
                return StatusCode(201, result.Data);
            }
            else if (result.Success)
                return StatusCode(204, result.Data);
            else
                return StatusCode(400, result.Data);
        }
        /// <summary>
        /// Xóa đối tượng
        /// </summary>
        /// <param name="entityId">ID của đối tượng</param>
        /// <returns>StatusCode và số bản dữ liệu xóa</returns>
        [HttpDelete]
        public IActionResult Delete([FromQuery] string entityId)
        {
            var result = _baseService.Delete(entityId);
            if ((int)result.Data > 0)
                return StatusCode(200, result.Data);
            return StatusCode(204, result.Data);
        }
        #endregion
    }
}
