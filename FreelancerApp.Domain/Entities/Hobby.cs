namespace FreelancerApp.Domain.Entities;
public class Hobby
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public Guid FreelancerId { get; set; }
    public Freelancer Freelancer { get; set; }
}

