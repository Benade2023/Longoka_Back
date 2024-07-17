using Longoka.BL.Interfaces;
using Longoka.Domain.DAO;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Longoka.API.Controllers
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

        // GET: api/<EleveController>
        [HttpGet]
        public ActionResult<IEnumerable<Eleve>> Get()
        {
            try
            {
                return Ok(_eleveManager.GetEleveList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<EleveController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Eleve>> GetById(int id)
        {
            try
            {
                var result = await Task.Run(() => _eleveManager.GetEleveById(id));
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

        // POST api/<EleveController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Eleve eleve)
        {
            await Task.Run(() => _eleveManager.CreateEleve(eleve));
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

        // PUT api/<EleveController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Eleve eleve)
        {
            try
            {
                await Task.Run(() => _eleveManager.UpdateEleve(eleve));
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<EleveController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await Task.Run(() => _eleveManager.DeleteEleve(id));
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
