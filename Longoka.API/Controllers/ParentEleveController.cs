using Longoka.BL.Interfaces;
using Longoka.Domain.DAO;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Longoka.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParentEleveController : ControllerBase
    {
        private readonly IParentEleveManager _parentEleveManager;

        public ParentEleveController(IParentEleveManager parentEleveManager)
        {
            _parentEleveManager = parentEleveManager;
        }

        // GET: api/<ParentEleveController>
        [HttpGet]
        public ActionResult<IEnumerable<ParentEleve>> GetAll()
        {
            try
            {
                return Ok(_parentEleveManager.GetParentList());
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // GET api/<ParentEleveController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ParentEleve>> GetById(int id)
        {
            try
            {
                var result = await Task.Run(() => _parentEleveManager.GetParentById(id));
                if (result !=  null)
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

        // POST api/<ParentEleveController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ParentEleve parent)
        {
            await Task.Run(() => _parentEleveManager.CreateParent(parent));
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

        // PUT api/<ParentEleveController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] ParentEleve parent)
        {
            try
            {
                await Task.Run(() => _parentEleveManager.UpdateParent(parent));
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<ParentEleveController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await Task.Run(() => _parentEleveManager.DeleteParent(id));
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
