using Longoka.BL.BL;
using Longoka.BL.Interfaces;
using Longoka.Domain.DAO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Longoka.Api2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatiereController : ControllerBase
    {
        private readonly IMatiereManager _matiereManager;

        public MatiereController(IMatiereManager matiereManager)
        {
            _matiereManager = matiereManager;
        }
       
        /// <summary>
        /// Liste des matieres
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Matiere>>> GetAll()
        {
            try
            {
                var result = await _matiereManager.GetMatiereList();
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
       /// Selectionner une matière par son id
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Matiere>> GetById(int id)
        {
            try
            {
                var result = await _matiereManager.GetMatiereById(id);
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
        /// Créer une matière
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Matiere value)
        {
            try
            {
                var result = await _matiereManager.CreateMatiere(value);
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
       /// Mettre à jour une matière
       /// </summary>
       /// <param name="value"></param>
       /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] Matiere value)
        {
            try
            {
                var result = await _matiereManager.UpdateMatiere(value);
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
   /// Supprimer une matière
   /// </summary>
   /// <param name="id"></param>
   /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var result = await _matiereManager.DeleteMatiere(id);
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
