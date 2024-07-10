using Longoka.BL.Interfaces;
using Longoka.Domain.DAO;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Longoka.API.Controllers
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

        // GET: api/<MatiereController>
        [HttpGet]
        public ActionResult<IEnumerable<Matieres>> GetAll()
        {
            try
            {
                return Ok(_matiereManager.GetMatiereList());
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // GET api/<MatiereController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Matieres>> GetById(Guid id)
        {
            try
            {
                var result = await Task.Run(() => _matiereManager.GetMatiereById(id));
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

        // POST api/<MatiereController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Matieres matiere)
        {
            await Task.Run(() => _matiereManager.CreateMatiere(matiere));
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

        // PUT api/<MatiereController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(Guid id, [FromBody] Matieres matiere)
        {
            try
            {
                await Task.Run(() => _matiereManager.UpdateMatiere(matiere));
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<MatiereController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                await Task.Run(() => _matiereManager.DeleteMatiere(id));
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
