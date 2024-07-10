using Longoka.BL.Interfaces;
using Longoka.Domain.DAO;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Longoka.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserManager _userManager;

        public UserController(IUserManager userManager)
        {
            _userManager = userManager;
        }

        // GET: api/<UserController>
        [HttpGet]
        public ActionResult<IEnumerable<Users>> GetAll()
        {
            try
            {
                return Ok(_userManager.GetUserList());
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Users>> GetById(Guid id)
        {
            try
            {
                var result = await Task.Run(() => _userManager.GetUserById(id));
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

        // POST api/<UserController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Users user)
        {
            await Task.Run(() => _userManager.CreateUser(user));
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

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(Guid id, [FromBody] Users user)
        {
            try
            {
                await Task.Run(() => _userManager.UpdateUser(user));
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                await Task.Run(() => _userManager.DeleteUser(id));
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
