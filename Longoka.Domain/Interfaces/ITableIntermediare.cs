
namespace Longoka.Domain.Interfaces
{
    /// <summary>
    /// Interface lié au model de classe intermediare : T et U représentent des Ids
    /// </summary>
    public interface ITableIntermediare<T> where T : class
    {
        Task<bool> InsertDataOfIntermediareTable(T classe);
    }
}
