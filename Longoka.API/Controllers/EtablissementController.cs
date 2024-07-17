using Longoka.BL.Interfaces;
using Longoka.Domain.DAO;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Longoka.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EtablissementController : ControllerBase
    {
        private readonly IEtablissementManager _manager;

        public EtablissementController(IEtablissementManager etablisementManager)
        {
            _manager = etablisementManager;
        }

        // GET: api/<EcoleController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Etablissement>>> GetAll()
        {
            try
            {
                var result = await _manager.GetEtablissementList();
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
        public async Task<ActionResult<Etablissement>> GetById(int id)
        {
            try
            {
                var result = await _manager.GetEtablissementById(id);
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
        public async Task<ActionResult> Post([FromBody] Etablissement value)
        {
            try
            {
                var result = await _manager.CreateEtablissement(value);
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
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Etablissement value)
        {
            try
            {
                var result = await _manager.UpdateEtablissement(value);
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
                var result = await _manager.DeleteEtablissement(id);
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
