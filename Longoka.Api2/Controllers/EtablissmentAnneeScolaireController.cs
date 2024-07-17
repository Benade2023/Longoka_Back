using Longoka.BL.Interfaces;
using Longoka.Domain.DAO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Longoka.Api2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EtablissmentAnneeScolaireController : ControllerBase
    {
        private readonly IEtablissementAnneeScolaireManager _manager;

        public EtablissmentAnneeScolaireController(IEtablissementAnneeScolaireManager manager)
        {
            _manager = manager;
        }

        /// <summary>
        /// Insertion des identifiants de l'année scolaire et de l'etablissement dans la table intermediare
        /// </summary>
        /// <param name="anneeId">Id de l'année scolaire</param>
        /// <param name="etablissementId">id de l'établissement</param>
        /// <returns>true</returns>

        [HttpPost("Etablissement_anneeScolaire")]
        public async Task<ActionResult<bool>> InertIDEtablissmentAndAnneeScolaire(AnneeScolaire_Etablissement value)
        {
            try
            {
               var status = await _manager.InertIDEtablissmentAndAnneeScolaire(value);
               return Ok(status);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
