using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface IPacientesService
    {
        Task<List<Paciente>> GetAllAsync();
        Task<Paciente?> GetByIdPacienteAsync(int nLegajo);
        Task<Paciente> CreateAsync(Paciente paciente);
    }
}