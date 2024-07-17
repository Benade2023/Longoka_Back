using Longoka.BL.Interfaces;
using Longoka.Domain.DAO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Longoka.Api2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactManager _contactManager;

        public ContactController(IContactManager contactManager)
        {
            _contactManager = contactManager;
        }


       /// <summary>
       /// Selectionner la liste des contacts
       /// </summary>
       /// <returns>Une liste de contacts</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contact>>> GetAll()
        {
            try
            {
                var result = await _contactManager.GetContactList();
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

      /// <summary>
      /// Selectionner un contact par son id
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Contact>> GetById(int id)
        {
            try
            {
                var result = await _contactManager.GetContactById(id);
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

       /// <summary>
       /// Enrégistrer un contact
       /// </summary>
       /// <param name="value">id</param>
       /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Contact value)
        {
            try
            {
                var result = await _contactManager.CreateContact(value);
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

        /// <summary>
        /// Modiffier un contact
        /// </summary>
        /// <param name="value">Contact</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] Contact value)
        {
            try
            {
                var result = await _contactManager.UpdateContact(value);
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

       /// <summary>
       /// Supprimer un contact
       /// </summary>
       /// <param name="id">id</param>
       /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var result = await _contactManager.DeleteContact(id);
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
