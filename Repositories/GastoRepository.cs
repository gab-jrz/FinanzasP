using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinanzasPersonales.Entities;
using FinanzasPersonales.Models;


namespace FinanzasPersonales.Repositories
{
    public class GastoRepository : IGastoRepository
    {
        private readonly AppDbContext _context;

        public GastoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Gasto>> GetAllAsync()
        {
            return await _context.Gastos.ToListAsync();
        }

        public async Task<Gasto?> GetByIdAsync(int id)
        {
            return await _context.Gastos.FindAsync(id);
        }

        public async Task AddAsync(Gasto gasto)
        {
            await _context.Gastos.AddAsync(gasto);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Gasto gasto)
        {
            _context.Gastos.Update(gasto);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var gasto = await GetByIdAsync(id);
            if (gasto != null)
            {
                _context.Gastos.Remove(gasto);
                await _context.SaveChangesAsync();
            }

        }
    }
 }
