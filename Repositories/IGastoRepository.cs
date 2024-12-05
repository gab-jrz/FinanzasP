using System.Collections.Generic;
using System.Threading.Tasks;
using FinanzasPersonales.Entities;


namespace FinanzasPersonales.Repositories
{
    public interface IGastoRepository
    {
            Task<IEnumerable<Gasto>> GetAllAsync();
            Task<Gasto?> GetByIdAsync(int id);
            Task AddAsync(Gasto gasto);
            Task UpdateAsync(Gasto gasto);
            Task DeleteAsync(int id);
    }
}
