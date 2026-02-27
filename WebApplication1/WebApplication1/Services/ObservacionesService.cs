using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class ObservacionesService : IObservacionesService
    {
        private readonly AppDbContext _db;
        public ObservacionesService(AppDbContext db) => _db = db;

        public Task<List<Observacion>> GetAllAsync()
            => _db.Observaciones
                  .AsNoTracking()
                  .Include(o => o.Paciente)
                  .Include(o => o.Medico)
                  .OrderByDescending(o => o.FechaObservacion)
                  .ToListAsync();

        public Task<Observacion?> GetByIdAsync(int idObservacion)
            => _db.Observaciones
                  .AsNoTracking()
                  .Include(o => o.Paciente)
                  .Include(o => o.Medico)
                  .FirstOrDefaultAsync(o => o.IdObservacion == idObservacion);

        public Task<List<Observacion>> GetByPacienteIdAsync(int idPaciente)
            => _db.Observaciones
                  .AsNoTracking()
                  .Where(o => o.IdPaciente == idPaciente)
                  .Include(o => o.Paciente)
                  .Include(o => o.Medico)
                  .OrderByDescending(o => o.FechaObservacion)
                  .ToListAsync();
    }
}