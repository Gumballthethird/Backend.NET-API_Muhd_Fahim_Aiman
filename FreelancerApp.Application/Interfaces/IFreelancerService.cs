using FreelancerApp.Application.DTOs;

namespace FreelancerApp.Application.Interfaces
{
    public interface IFreelancerService
    {
        Task<IEnumerable<FreelancerDto>> GetAllAsync(string search = null);
        Task<FreelancerDto?> GetByIdAsync(Guid id);
        Task CreateAsync(FreelancerDto dto);
        Task UpdateAsync(Guid id, FreelancerDto dto);
        Task DeleteAsync(Guid id);
        Task ArchiveAsync(Guid id);
        Task UnarchiveAsync(Guid id);
    }
}
