using Longoka.BL.BL;
using Longoka.BL.Interfaces;
using Longoka.Domain.DAO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Longoka.Api2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EleveController : ControllerBase
    {
        private readonly IEleveManager _eleveManager;

        public EleveController(IEleveManager eleveManager)
        {
            _eleveManager = eleveManager;
        }

       /// <summary>
       /// Liste de tous les éleves d'un établissement
       /// </summary>
       /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Eleve>>> GetAll()
        {
            try
            {
                var result = await _eleveManager.GetEleveList();
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
      /// Selectionner un élève par son id
      /// </summary>
      /// <param name="id">id</param>
      /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Eleve>> GetById(int id)
        {
            try
            {
                var result = await _eleveManager.GetEleveById(id);
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
       /// Enrégistrer un élève
       /// </summary>
       /// <param name="value">Elève</param>
       /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Eleve value)
        {
            try
            {
                var result = await _eleveManager.CreateEleve(value);
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
       /// Modifier les informations d'un élève
       /// </summary>
       /// <param name="value">Eleve</param>
       /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] Eleve value)
        {
            try
            {
                var result = await _eleveManager.UpdateEleve(value);
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
       /// Supprimer un élève
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var result = await _eleveManager.DeleteEleve(id);
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
