using Longoka.BL.Interfaces;
using Longoka.Domain.DAO;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Longoka.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EcoleController : ControllerBase
    {
        private readonly IEcoleManager _ecoleManager;

        public EcoleController(IEcoleManager ecoleManager)
        {
            _ecoleManager = ecoleManager;
        }

        // GET: api/<EcoleController>
        [HttpGet]
        public ActionResult<IEnumerable<Ecoles>> GetAll()
        {
            try
            {
                return Ok(_ecoleManager.GetEcoleList());
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // GET api/<EcoleController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ecoles>> GetById(Guid id)
        {
            try
            {
                var result = await Task.Run(() => _ecoleManager.GetEcoleById(id));
                if(result != null)
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

        // POST api/<EcoleController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Ecoles ecole)
        {
            await Task.Run(() => _ecoleManager.CreateEcole(ecole));
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

        // PUT api/<EcoleController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(Guid id, [FromBody] Ecoles ecole)
        {
            try
            {
                await Task.Run(() => _ecoleManager.UpdateEcole(ecole));
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<EcoleController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                await Task.Run(() => _ecoleManager.DeleteEcole(id));
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
