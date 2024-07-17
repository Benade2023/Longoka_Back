
using Longoka.Domain.DAO;

namespace Longoka.BL.Interfaces
{
    public interface IContactManager
    {
        Task<StatusResponse> CreateContact(Contact contact);
        Task<IEnumerable<Contact>> GetContactList();
        Task<StatusResponse> DeleteContact(int id);
        Task<StatusResponse> UpdateContact(Contact contact);
        Task<Contact> GetContactById(int id);
    }
}
