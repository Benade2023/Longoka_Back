using Longoka.BL.Interfaces;
using Longoka.Domain.DAO;
using Longoka.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace Longoka.BL.BL
{
    public class MatiereManager : IMatiereManager
    {
        private readonly IProvider<Matiere, int> _provider;

        public MatiereManager(IProvider<Matiere, int> provider)
        {
            _provider = provider;
        }

        public async Task<StatusResponse> CreateMatiere(Matiere matiere)
        {
            if (string.IsNullOrEmpty(matiere.MatiereName))
            {
                throw new Exception("Le nom de la matière est obligatoire");
            }
            try
            {
                var statut = await _provider.Create(matiere);
                if (statut.Success)
                {
                    return statut;
                }
                return new StatusResponse()
                {
                    Success = false,
                    Message = "Échec d'enrégistrement.",
                };
            }
            catch (Exception ex)
            {
                return new StatusResponse()
                {
                    Success = false,
                    Message = ex.Message,
                };
            }
        }
        public async Task<StatusResponse> DeleteMatiere(int id)
        {
            try
            {
                var statut = await _provider.Delete(id);
                if (statut.Success)
                {
                    return statut;
                }
                return new StatusResponse() { Success = false, Message = "Echec de supression" };
            }
            catch (Exception ex)
            {
                return new StatusResponse()
                {
                    Success = false,
                    Message = ex.Message,
                };
            }

        }

        public async Task<Matiere> GetMatiereById(int id)
        {
            try
            {
                var result = await _provider.GetById(id);
                if (result != null)
                {
                    return result;
                }
                return null!;

            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<IEnumerable<Matiere>> GetMatiereList()
        {
            try
            {
                var result = await _provider.GetAll();
                if (result == null)
                {
                    return [];
                }
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<StatusResponse> UpdateMatiere(Matiere matiere)
        {
            try
            {
                var statut = await _provider.Update(matiere);
                if (statut.Success)
                {
                    return statut;
                }
                return new StatusResponse() { Success = false, Message = "Echèc de mise à jour." };
            }
            catch (Exception ex)
            {
                return new StatusResponse() { Success = false, Message = ex.Message };
            }

        }
    }
}
