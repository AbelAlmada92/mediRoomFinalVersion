using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class MedicosService : IMedicosService
    {
        private readonly AppDbContext _db;

        public MedicosService(AppDbContext db) => _db = db;

        public Task<List<Medico>> GetAllAsync()
            => _db.Medicos.AsNoTracking().ToListAsync();

        public Task<Medico?> GetByIdAsync(int idMedico)
            => _db.Medicos.AsNoTracking().FirstOrDefaultAsync(m => m.IdMedico == idMedico);
    }
}