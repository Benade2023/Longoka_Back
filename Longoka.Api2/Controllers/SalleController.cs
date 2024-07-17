using Longoka.BL.BL;
using Longoka.BL.Interfaces;
using Longoka.Domain.DAO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Longoka.Api2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalleController : ControllerBase
    {
        private readonly ISalleManager _salleManager;

        public SalleController(ISalleManager salleManager)
        {
            _salleManager = salleManager;
        }
        // GET: api/<EcoleController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Salle>>> GetAll()
        {
            try
            {
                var result = await _salleManager.GetSalleList();
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

        // GET api/<EcoleController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Salle>> GetById(int id)
        {
            try
            {
                var result = await _salleManager.GetSalleById(id);
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

        // POST api/<EcoleController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Salle value)
        {
            try
            {
                var result = await _salleManager.CreateSalle(value);
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

        // PUT api/<EcoleController>/5
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] Salle value)
        {
            try
            {
                var result = await _salleManager.UpdateSalle(value);
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

        // DELETE api/<EcoleController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var result = await _salleManager.DeleteSalle(id);
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
