using Longoka.BL.Interfaces;
using Longoka.Domain.DAO;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Longoka.API.Controllers
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

        // GET: api/<ClasseController>
        [HttpGet]
        public ActionResult<IEnumerable<Classe>> GetAll()
        {
            try
            {
                return Ok(_classeManager.GetClasseList());
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // GET api/<ClasseController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Classe>> GetById(int id)
        {
            try
            {
                var result = await Task.Run(() => _classeManager.GetClasseById(id));
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

        // POST api/<ClasseController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Classe classe)
        {
            await Task.Run(() => _classeManager.CreateClasse(classe));
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

        // PUT api/<ClasseController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Classe classe)
        {
            try
            {
                await Task.Run(() => _classeManager.UpdateClasse(classe));
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<ClasseController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await Task.Run(() => _classeManager.DeleteClasse(id));
                return Ok();    
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
