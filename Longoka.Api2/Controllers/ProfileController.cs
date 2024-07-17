using Longoka.BL.BL;
using Longoka.BL.Interfaces;
using Longoka.Domain.DAO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Longoka.Api2.Controllers
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
        // GET: api/<EcoleController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Profile>>> GetAll()
        {
            try
            {
                var result = await _profileManager.GetProfileList();
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
        public async Task<ActionResult<Profile>> GetById(int id)
        {
            try
            {
                var result = await _profileManager.GetProfileById(id);
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
        public async Task<ActionResult> Post([FromBody] Profile value)
        {
            try
            {
                var result = await _profileManager.CreateProfile(value);
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
        public async Task<ActionResult> Put([FromBody] Profile value)
        {
            try
            {
                var result = await _profileManager.UpdateProfile(value);
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
                var result = await _profileManager.DeleteProfile(id);
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
