using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface IMedicosService
    {
        Task<List<Medico>> GetAllAsync();
        Task<Medico?> GetByIdAsync(int idMedico);
        Task<Medico> CreateAsync(Medico medico);
        Task<Medico?> UpdateAsync(int id, Medico medico);
    }
}