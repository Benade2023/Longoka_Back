using Longoka.BL.Interfaces;
using Longoka.Domain.DAO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Longoka.Api2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EleveCoursController : ControllerBase
    {
        private readonly IEleveCoursManager _manager;

        public EleveCoursController(IEleveCoursManager manager)
        {
            _manager = manager;
        }

        /// <summary>
        /// Table intermediare réliant un élève à un cours
        /// </summary>
        /// <param name="value">id de eleve et id du cours</param>
        /// <returns></returns>
        [HttpPost("Eleve_cours")]
        public async Task<ActionResult<bool>> EleveCoursIdInsert(Eleve_Cours value)
        {
            try
            {
                var status = await _manager.InsertIDEleveAndCours(value);
                return Ok(status);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
