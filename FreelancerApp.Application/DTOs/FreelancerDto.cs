using System;
using System.Collections.Generic;

namespace FreelancerApp.Application.DTOs
{
    public class FreelancerDto
    {
        public Guid Id { get; set; }
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public List<SkillsetDto> Skillsets { get; set; } = new();
        public List<HobbyDto> Hobbies { get; set; } = new();
    }
}
