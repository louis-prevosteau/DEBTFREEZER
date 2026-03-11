using DebtFreezerApi.Data;
using DebtFreezerApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DebtFreezerApi.Repository
{
    public class DebtsRepository : IRepository<Debt>
    {

        private readonly ApplicationDbContext _dbcontext;

        public DebtsRepository(ApplicationDbContext dbcontext)
        {
            _dbcontext =  dbcontext;
        }


        public async Task<Debt> CreateAsync(Debt entity)
        {
            _dbcontext.Add(entity);
            await _dbcontext.SaveChangesAsync(); //Sauvegrade en BDD
            await _dbcontext.Entry(entity).Reference(e => e.User).LoadAsync();
            return entity;

        }


        public async Task DeleteAsync(int id)
        {
            var debt = await _dbcontext.Dettes.FindAsync(id);
            if (debt != null)
            {
                _dbcontext.Dettes.Remove(debt);
                await _dbcontext.SaveChangesAsync();
            }
           
        }

        public async  Task<List<Debt>> GetAllAsync()
        {
            
            return await _dbcontext.Dettes
                .Include(e => e.User)
                .ToListAsync();
        }

        public async Task<Debt> GetByIdAsync(int id)
        {
            return await _dbcontext.Dettes.Include(e => e.User).FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task UpdateAsync(Debt entity)

        {
            _dbcontext.Dettes.Update(entity);
            await _dbcontext.SaveChangesAsync();
        }
    }
}
