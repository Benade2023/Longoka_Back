using Longoka.BL.BL;
using Longoka.BL.Interfaces;
using Longoka.Domain.DAO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Longoka.Api2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParentEleveController : ControllerBase
    {
        private readonly IParentEleveManager _parentEleveManager;

        public ParentEleveController(IParentEleveManager parentEleveManager)
        {
            _parentEleveManager = parentEleveManager;
        }

        /// <summary>
        /// Obtenire la listes des parents d'élèves
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ParentEleve>>> GetAll()
        {
            try
            {
                var result = await _parentEleveManager.GetParentList();
                if (result is null)
                {
                    return NoContent();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

       /// <summary>
       /// Sélectionner un parent d'élève
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ParentEleve>> GetById(int id)
        {
            try
            {
                var result = await _parentEleveManager.GetParentById(id);
                if (result is null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

   /// <summary>
   /// Enrégistrer un parent d'élève
   /// </summary>
   /// <param name="value"></param>
   /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ParentEleve value)
        {
            try
            {
                var result = await _parentEleveManager.CreateParent(value);
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    /// <summary>
    /// Modiffier le parent d'élève
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] ParentEleve value)
        {
            try
            {
                var result = await _parentEleveManager.UpdateParent(value);
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

   /// <summary>
   /// Supprimer un parent d'élève
   /// </summary>
   /// <param name="id"></param>
   /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var result = await _parentEleveManager.DeleteParent(id);
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
