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
            => _db.Medico.AsNoTracking().ToListAsync();

        public Task<Medico?> GetByIdAsync(int idMedico)
            => _db.Medico.AsNoTracking().FirstOrDefaultAsync(m => m.IdMedico == idMedico);

        public async Task<Medico> CreateAsync(Medico medico)
        {
            _db.Medico.Add(medico);
            await _db.SaveChangesAsync();
            return medico;
        }

        public async Task<Medico?> UpdateAsync(int id, Medico medico)
        {
            var existing = await _db.Medico.FirstOrDefaultAsync(m => m.IdMedico == id);
            if (existing is null) return null;

            existing.Nombre = medico.Nombre;
            existing.Apellido = medico.Apellido;
            existing.Matricula = medico.Matricula;
            existing.Especialidad = medico.Especialidad;
            existing.DNI = medico.DNI;
            existing.TelefonoMedico = medico.TelefonoMedico;
            existing.Mail = medico.Mail;

            await _db.SaveChangesAsync();
            return existing;
        }

    }
}