using Longoka.BL.Interfaces;
using Longoka.Domain.DAO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Longoka.Api2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdresseController : ControllerBase
    {
        private readonly IAdresseManager _adresseManager;

        public AdresseController(IAdresseManager adresseManager)
        {
            _adresseManager = adresseManager;
        }


       /// <summary>
       /// Obtenir la liste de toutes les adresses 
       /// </summary>
       /// <returns>Liste d'adresses</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Adresse>>> GetAll()
        {
            try
            {
                var result = await _adresseManager.GetAdresseList();
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
       /// Selectionner une adresse par son id
       /// </summary>
       /// <param name="id"></param>
       /// <returns>Une adresse</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Adresse>> GetById(int id)
        {
            try
            {
                var result = await _adresseManager.GetAdresseById(id);
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
        /// Ajouter une adresse
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Adresse value)
        {
            try
            {
                var result = await _adresseManager.CreateAdresse(value);
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
        /// Mettre à jour une adresse
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] Adresse value)
        {
            try
            {
                var result = await _adresseManager.UpdateAdresse(value);
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
                var result = await _adresseManager.DeleteAdresse(id);
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
