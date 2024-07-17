using Longoka.BL.Interfaces;
using Longoka.Domain.DAO;
using Microsoft.AspNetCore.Mvc;

namespace Longoka.Api2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClasseController : ControllerBase
    {
        private readonly IClasseManager _classeManager;

        public ClasseController(IClasseManager classeManager)
        {
            _classeManager = classeManager;
        }


       /// <summary>
       /// Obtenir la liste des classes
       /// </summary>
       /// <returns>Une liste de classes</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Classe>>> GetAll()
        {
            try
            {
                var result = await _classeManager.GetClasseList();
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
        /// Selectionner une classe par son id
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>une classe</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Classe>> GetById(int id)
        {
            try
            {
                var result = await _classeManager.GetClasseById(id);
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
       /// Créer une classe
       /// </summary>
       /// <param name="value">Classe</param>
       /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Classe value)
        {
            try
            {
                var result = await _classeManager.CreateClasse(value);
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
        /// Modiffier une classe
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] Classe value)
        {
            try
            {
                var result = await _classeManager.UpdateClasse(value);
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
        /// Supprimer une classe
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var result = await _classeManager.DeleteClasse(id);
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
