using Longoka.BL.Interfaces;
using Longoka.Domain.DAO;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Longoka.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonnelEnseignantController : ControllerBase
    {
        private readonly IPersonnelEnseignantManager _personnelEnseignantManager;

        public PersonnelEnseignantController(IPersonnelEnseignantManager personnelEnseignantManager)
        {
            _personnelEnseignantManager = personnelEnseignantManager;
        }

        // GET: api/<PersonnelEnseignantController>
        [HttpGet]
        public ActionResult<IEnumerable<Enseignant>> GetAll()
        {
            try
            {
                return Ok(_personnelEnseignantManager.GetEnseignantList());
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // GET api/<PersonnelEnseignantController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Enseignant>> GetById(int id)
        {
            try
            {
                var result = await Task.Run(() => _personnelEnseignantManager.GetEnseignantById(id));
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

        // POST api/<PersonnelEnseignantController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Enseignant enseignant)
        {
            await Task.Run(() => _personnelEnseignantManager.CreateEnseignant(enseignant));
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

        // PUT api/<PersonnelEnseignantController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Enseignant enseignant)
        {
            try
            {
                await Task.Run(() => _personnelEnseignantManager.UpdateEnseignant(enseignant));
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<PersonnelEnseignantController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await Task.Run(() => _personnelEnseignantManager.DeleteEnseignant(id));
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
