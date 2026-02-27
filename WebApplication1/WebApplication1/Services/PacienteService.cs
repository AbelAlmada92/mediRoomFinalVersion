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

        public Task<Paciente?> GetByIdPacienteAsync(int idPaciente)
            => _db.Pacientes.AsNoTracking().FirstOrDefaultAsync(p => p.IdPaciente == idPaciente);

        public async Task<Paciente> CreateAsync(Paciente paciente)
        {
            _db.Pacientes.Add(paciente);
            await _db.SaveChangesAsync();
            return paciente;
        }

        public async Task<Paciente?> UpdateAsync(int idPaciente, Paciente paciente)
        {
            var existing = await _db.Pacientes.FirstOrDefaultAsync(p => p.IdPaciente == idPaciente);
            if (existing is null) return null;

            existing.Nombre = paciente.Nombre;
            existing.Apellido = paciente.Apellido;
            existing.DNI = paciente.DNI;
            existing.NLegajo = paciente.NLegajo;
            existing.ObraSocial = paciente.ObraSocial;
            existing.SexoBio = paciente.SexoBio;
            existing.FechaNacimiento = paciente.FechaNacimiento;
            existing.GrupoSanguineo = paciente.GrupoSanguineo;
            existing.MedicacionPrescripta = paciente.MedicacionPrescripta;
            existing.Domicilio = paciente.Domicilio;
            existing.TelefonoPaciente = paciente.TelefonoPaciente;

            await _db.SaveChangesAsync();
            return existing;
        }

    }
}