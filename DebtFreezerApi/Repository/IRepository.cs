using Mysqlx.Crud;

namespace DebtFreezerApi.Repository
{
    public interface IRepository<T>
    {
       Task<T> GetByIdAsync(int id);

        Task<List<T>> GetAllAsync();

        Task<T>  CreateAsync(T entity);

        Task  UpdateAsync(T entity);

        Task  DeleteAsync(int id);
         



    }
}
