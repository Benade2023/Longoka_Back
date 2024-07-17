using Longoka.BL.Interfaces;
using Longoka.Domain.DAO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Longoka.Api2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EtablissmentMatiereEnseignantController : ControllerBase
    {
        private readonly IEtablissementMatiereEnseignantManager _manager;

        public EtablissmentMatiereEnseignantController(IEtablissementMatiereEnseignantManager manager)
        {
            _manager = manager;
        }

        /// <summary>
        /// Insertion des identifiants de l'etablissement, matiere et enseignant dans la table intermediare
        /// </summary>
        /// <param name="matiereId">id de matiere</param>
        /// <param name="etablissementId">id de établissemet</param>
        /// <param name="enseignantId">id de enseignant</param>
        /// <returns>true</returns>

        [HttpPost("Etablissement_matiere_enseignant")]
        public async Task<ActionResult<bool>> InertIDs(Etablissement_Enseignant_Matiere value)
        {
            try
            {
                var status = await _manager.InertIDEtablissmentMatiereEnseignant(value);
                return Ok(status);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
