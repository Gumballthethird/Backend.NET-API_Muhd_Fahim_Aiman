using FreelancerApp.Application.DTOs;
using FreelancerApp.Application.Interfaces;
using FreelancerApp.Domain.Entities;
using FreelancerApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FreelancerApp.Infrastructure.Services
{
    public class FreelancerService : IFreelancerService
    {
        private readonly FreelancerDbContext _context;

        public FreelancerService(FreelancerDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<FreelancerDto>> GetAllAsync(string? search = null)
        {
            var query = _context.Freelancers
                .Include(f => f.Skillsets)
                .Include(f => f.Hobbies)
                .Where(f => !f.IsArchived);

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(f =>
                    f.Username.Contains(search) ||
                    f.Email.Contains(search));
            }

            var freelancers = await query.ToListAsync();

            return freelancers.Select(f => new FreelancerDto
            {
                Id = f.Id,
                Username = f.Username,
                Email = f.Email,
                PhoneNumber = f.PhoneNumber,
                Skillsets = f.Skillsets.Select(s => new SkillsetDto { Name = s.Name }).ToList(),
                Hobbies = f.Hobbies.Select(h => new HobbyDto { Name = h.Name }).ToList()
            });
        }

        public async Task<FreelancerDto?> GetByIdAsync(Guid id)
        {
            var f = await _context.Freelancers
                .Include(f => f.Skillsets)
                .Include(f => f.Hobbies)
                .FirstOrDefaultAsync(f => f.Id == id);

            if (f == null) return null;

            return new FreelancerDto
            {
                Id = f.Id,
                Username = f.Username,
                Email = f.Email,
                PhoneNumber = f.PhoneNumber,
                Skillsets = f.Skillsets.Select(s => new SkillsetDto { Name = s.Name }).ToList(),
                Hobbies = f.Hobbies.Select(h => new HobbyDto { Name = h.Name }).ToList()
            };
        }

        public async Task CreateAsync(FreelancerDto dto)
        {
            var freelancerId = Guid.NewGuid();

            var freelancer = new Freelancer
            {
                Id = freelancerId,
                Username = dto.Username,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                IsArchived = false,
                Skillsets = dto.Skillsets.Select(s => new Skillset
                {
                    Id = Guid.NewGuid(),
                    Name = s.Name,
                    FreelancerId = freelancerId
                }).ToList(),
                Hobbies = dto.Hobbies.Select(h => new Hobby
                {
                    Id = Guid.NewGuid(),
                    Name = h.Name,
                    FreelancerId = freelancerId
                }).ToList()
            };

            await _context.Freelancers.AddAsync(freelancer);
            await _context.SaveChangesAsync();
        }


        public async Task UpdateAsync(Guid id, FreelancerDto dto)
        {
            var freelancer = await _context.Freelancers
                .Include(f => f.Skillsets)
                .Include(f => f.Hobbies)
                .FirstOrDefaultAsync(f => f.Id == id);

            if (freelancer == null) return;

            // Update scalar fields
            freelancer.Username = dto.Username;
            freelancer.Email = dto.Email;
            freelancer.PhoneNumber = dto.PhoneNumber;

            // Remove old Skillsets & Hobbies
            _context.Skillsets.RemoveRange(freelancer.Skillsets);
            _context.Hobbies.RemoveRange(freelancer.Hobbies);

            // Save changes now to flush out deleted children
            await _context.SaveChangesAsync();

            // Add new Skillsets
            var newSkillsets = dto.Skillsets.Select(s => new Skillset
            {
                Id = Guid.NewGuid(),
                Name = s.Name,
                FreelancerId = freelancer.Id
            });

            // Add new Hobbies
            var newHobbies = dto.Hobbies.Select(h => new Hobby
            {
                Id = Guid.NewGuid(),
                Name = h.Name,
                FreelancerId = freelancer.Id
            });

            await _context.Skillsets.AddRangeAsync(newSkillsets);
            await _context.Hobbies.AddRangeAsync(newHobbies);

            Console.WriteLine($"Updating freelancer with ID: {freelancer.Id}");
            Console.WriteLine($"Skillsets count: {dto.Skillsets.Count}");
            Console.WriteLine($"Hobbies count: {dto.Hobbies.Count}");

            // Save new children
            await _context.SaveChangesAsync();
        }





        public async Task DeleteAsync(Guid id)
        {
            var freelancer = await _context.Freelancers.FindAsync(id);
            if (freelancer != null)
            {
                _context.Freelancers.Remove(freelancer);
                await _context.SaveChangesAsync();
            }
        }

        public async Task ArchiveAsync(Guid id)
        {
            var freelancer = await _context.Freelancers.FindAsync(id);
            if (freelancer != null)
            {
                freelancer.IsArchived = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task UnarchiveAsync(Guid id)
        {
            var freelancer = await _context.Freelancers.FindAsync(id);
            if (freelancer != null)
            {
                freelancer.IsArchived = false;
                await _context.SaveChangesAsync();
            }
        }

        //Insert new codes here
        public async Task UpdatePartialAsync(Guid id, FreelancerDto dto)
        {
            var freelancer = await _context.Freelancers
                .Include(f => f.Skillsets)
                .Include(f => f.Hobbies)
                .FirstOrDefaultAsync(f => f.Id == id);

            if (freelancer == null) return;

            freelancer.Username = dto.Username;
            freelancer.Email = dto.Email;
            freelancer.PhoneNumber = dto.PhoneNumber;

            _context.Freelancers.Update(freelancer);
            await _context.SaveChangesAsync();
        }

    }

    
}
