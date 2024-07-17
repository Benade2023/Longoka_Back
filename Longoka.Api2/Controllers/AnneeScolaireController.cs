using Longoka.BL.Interfaces;
using Longoka.Domain.DAO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Longoka.Api2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnneeScolaireController : ControllerBase
    {
        private readonly IAnneeScolaireManager _anneeScolaireManager;

        public AnneeScolaireController(IAnneeScolaireManager anneeScolaireManager)
        {
            _anneeScolaireManager = anneeScolaireManager;
        }

        /// <summary>
        /// Liste des années scolaires
        /// </summary>
        /// <returns>Une liste d'années scolaires</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnneeScolaires>>> GetAll()
        {
            try
            {
                var result = await _anneeScolaireManager.GetAnneeScolaireList();
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
       /// Selectionner une année scolaire
       /// </summary>
       /// <param name="id">id</param>
       /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<AnneeScolaires>> GetById(int id)
        {
            try
            {
                var result = await _anneeScolaireManager.GetAnneeScolaireById(id);
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
       /// Créer une année scolaire
       /// </summary>
       /// <param name="value">une adresse</param>
       /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] AnneeScolaires value)
        {
            try
            {
                var result = await _anneeScolaireManager.CreateAnneeScolaire(value);
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
       /// Modifier l'année scolaire
       /// </summary>
       /// <param name="value">une année scolaire</param>
       /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] AnneeScolaires value)
        {
            try
            {
                var result = await _anneeScolaireManager.UpdateAnneeScolaire(value);
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
       /// Supprimer une adresse
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var result = await _anneeScolaireManager.DeleteAnneeScolaire(id);
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
