using Longoka.BL.Interfaces;
using Longoka.Domain.DAO;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Longoka.Api2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EtablissementsController : ControllerBase
    {
        private readonly IEtablissementManager _manager;

        public EtablissementsController(IEtablissementManager etablisementManager)
        {
            _manager = etablisementManager;
        }

        /// <summary>
        /// Liste des établissements
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Etablissement>>> GetAll()
        {
            try
            {
                var result = await _manager.GetEtablissementList();
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
        /// Sélectionner un établissement via son id
        /// </summary>
        /// <param name="id">id</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Etablissement>> GetById(int id)
        {
            try
            {
                var result = await _manager.GetEtablissementById(id);
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
      /// Enrégistrer un établissement
      /// </summary>
      /// <param name="value"></param>
      /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Etablissement value)
        {
            try
            {
                var result = await _manager.CreateEtablissement(value);
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
     /// Modifier un établissement
     /// </summary>
     /// <param name="value"></param>
     /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] Etablissement value)
        {
            try
            {
                var result = await _manager.UpdateEtablissement(value);
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
   /// Supprimer un établissement
   /// </summary>
   /// <param name="id"></param>
   /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var result = await _manager.DeleteEtablissement(id);
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
