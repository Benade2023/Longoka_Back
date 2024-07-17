using Longoka.BL.Interfaces;
using Longoka.Domain.DAO;
using Microsoft.AspNetCore.Mvc;

namespace Longoka.Api2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnseignantController : ControllerBase
    {
        private readonly IPersonnelEnseignantManager _enseignatManager;

        public EnseignantController(IPersonnelEnseignantManager enseignatManager)
        {
            _enseignatManager = enseignatManager;
        }

        /// <summary>
        /// Liste des enseignants
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Enseignant>>> GetAll()
        {
            try
            {
                var result = await _enseignatManager.GetEnseignantList();
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
       /// Sélectionner un enseignant par son id
       /// </summary>
       /// <param name="id">id</param>
       /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Enseignant>> GetById(int id)
        {
            try
            {
                var result = await _enseignatManager.GetEnseignantById(id);
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
      /// Enrégistrer un enseignant
      /// </summary>
      /// <param name="value"></param>
      /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Enseignant value)
        {
            try
            {
                var result = await _enseignatManager.CreateEnseignant(value);
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
        /// Mettre à jour un les données d'un enseignant
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] Enseignant value)
        {
            try
            {
                var result = await _enseignatManager.UpdateEnseignant(value);
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
        /// Supprimer un enseignant
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var result = await _enseignatManager.DeleteEnseignant(id);
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
