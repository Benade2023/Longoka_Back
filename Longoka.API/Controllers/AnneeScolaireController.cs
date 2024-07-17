using Longoka.BL.BL;
using Longoka.BL.Interfaces;
using Longoka.Domain.DAO;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Longoka.API.Controllers
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

        // GET: api/<AnneeScolaireController>
        [HttpGet]
        public ActionResult<IEnumerable<AnneeScolaires>> GetAll()
        {
            try
            {
                return Ok(_anneeScolaireManager.GetAnneeScolaireList());
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // GET api/<AnneeScolaireController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AnneeScolaires>> GetById(int id)
        {
            try
            {
                var result = await Task.Run(() => _anneeScolaireManager.GetAnneeScolaireById(id));
                if (result != null)
                {
                    return Ok(result);
                }
                return NoContent();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // POST api/<AnneeScolaireController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] AnneeScolaires annee)
        {
            await Task.Run(() => _anneeScolaireManager.CreateAnneeScolaire(annee));
            try
            {
                await Task.Run(() => NoContent());
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            return Ok();
        }

        // PUT api/<AnneeScolaireController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] AnneeScolaires annee)
        {
            try
            {
                await Task.Run(() => _anneeScolaireManager.UpdateAnneeScolaire(annee));
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<AnneeScolaireController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await Task.Run(() => _anneeScolaireManager.DeleteAnneeScolaire(id));
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
