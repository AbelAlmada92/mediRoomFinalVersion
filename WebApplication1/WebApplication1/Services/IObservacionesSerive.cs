using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface IObservacionesService
    {
        Task<List<Observacion>> GetAllAsync();
        Task<List<Observacion>> GetByPacienteIdAsync(int idPaciente);
        Task<Observacion?> GetByIdAsync(int idObservacion);
    }
}