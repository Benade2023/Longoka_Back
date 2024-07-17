using Longoka.BL.BL;
using Longoka.BL.Interfaces;
using Longoka.Domain.DAO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Longoka.Api2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursController : ControllerBase
    {
        private readonly ICoursManager _coursManager;

        public CoursController(ICoursManager coursManager)
        {
            _coursManager = coursManager;
        }

       /// <summary>
       /// Liste des cours
       /// </summary>
       /// <returns>Une liste de cours</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cours>>> GetAll()
        {
            try
            {
                var result = await _coursManager.GetCoursList();
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
      /// Selectionner un cours par son id
      /// </summary>
      /// <param name="id">id</param>
      /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Cours>> GetById(int id)
        {
            try
            {
                var result = await _coursManager.GetCoursById(id);
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
        /// Créer un cours
        /// </summary>
        /// <param name="value">Cours</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Cours value)
        {
            try
            {
                var result = await _coursManager.CreateCours(value);
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
        /// Modiffier un cours
        /// </summary>
        /// <param name="value">Cours</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] Cours value)
        {
            try
            {
                var result = await _coursManager.UpdateCours(value);
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
        /// Supprimer un cours
        /// </summary>
        /// <param name="id">id</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var result = await _coursManager.DeleteCours(id);
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
