using Longoka.BL.Interfaces;
using Longoka.Domain.DAO;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Longoka.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileManager _profileManager;

        public ProfileController(IProfileManager profileManager)
        {
            _profileManager = profileManager;
        }

        // GET: api/<ProfileController>
        [HttpGet]
        public ActionResult<IEnumerable<Profiles>> GetAll()
        {
            try
            {
                return Ok(_profileManager.GetProfileList());
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // GET api/<ProfileController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Profiles>> GetById(Guid id)
        {
            try
            {
                var result = await Task.Run(() => _profileManager.GetProfileById(id));
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

        // POST api/<ProfileController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Profiles profile)
        {
            await Task.Run(() => _profileManager.CreateProfile(profile));
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

        // PUT api/<ProfileController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(Guid id, [FromBody] Profiles profile)
        {
            try
            {
                await Task.Run(() => _profileManager.UpdateProfile(profile));
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<ProfileController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                await Task.Run(() => _profileManager.DeleteProfile(id));
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
