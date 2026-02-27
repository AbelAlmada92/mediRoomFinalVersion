using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class PacientesService : IPacientesService
    {
        private readonly AppDbContext _db;
        public PacientesService(AppDbContext db) => _db = db;

        public Task<List<Paciente>> GetAllAsync()
            => _db.Pacientes.AsNoTracking().ToListAsync();

        public Task<Paciente?> GetByNLegajoAsync(int nLegajo)
            => _db.Pacientes.AsNoTracking().FirstOrDefaultAsync(p => p.NLegajo == nLegajo);

        public async Task<Paciente> CreateAsync(Paciente paciente)
        {
            _db.Pacientes.Add(paciente);
            await _db.SaveChangesAsync();
            return paciente;
        }
    }
}