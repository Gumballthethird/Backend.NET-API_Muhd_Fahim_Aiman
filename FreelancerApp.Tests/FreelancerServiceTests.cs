public class FreelancerServiceTests
{
    private FreelancerDbContext CreateContext()
    {
        var options = new DbContextOptionsBuilder<FreelancerDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;
        return new FreelancerDbContext(options);
    }

    [Fact]
    public async Task Can_Add_Freelancer()
    {
        var context = CreateContext();
        var service = new FreelancerService(context);

        var freelancerDto = new FreelancerDto
        {
            Username = "test",
            Email = "test@test.com",
            PhoneNumber = "123456",
            Skillsets = new List<SkillsetDto>(),
            Hobbies = new List<HobbyDto>()
        };

        await service.CreateAsync(freelancerDto);

        var all = await service.GetAllAsync();
        var result = all.FirstOrDefault(f => f.Username == "test");

        Assert.NotNull(result);
        Assert.Equal("test", result.Username);
    }

    [Fact]
    public async Task Can_Archive_Freelancer()
    {
        var context = CreateContext();
        var service = new FreelancerService(context);

        var freelancerDto = new FreelancerDto
        {
            Username = "arch",
            Email = "arch@test.com",
            PhoneNumber = "123456",
            Skillsets = new List<SkillsetDto>(),
            Hobbies = new List<HobbyDto>()
        };

        await service.CreateAsync(freelancerDto);

        var added = await service.GetAllAsync();
        var freelancer = added.First(f => f.Username == "arch");

        await service.ArchiveAsync(freelancer.Id);
        var result = await service.GetByIdAsync(freelancer.Id);

        Assert.NotNull(result);
        Assert.True(context.Freelancers.Find(freelancer.Id)?.IsArchived);
    }

    [Fact]
    public async Task GetAllAsync_Should_Exclude_Archived_Freelancers()
    {
        var context = CreateContext();
        var service = new FreelancerService(context);

        // Insert freelancers
        context.Freelancers.AddRange(
            new Freelancer { Id = Guid.NewGuid(), Username = "Alice", Email = "a@a.com", IsArchived = false },
            new Freelancer { Id = Guid.NewGuid(), Username = "Bob", Email = "b@b.com", IsArchived = true }
        );
        await context.SaveChangesAsync();

        var result = await service.GetAllAsync();

        Assert.Single(result);
        Assert.Equal("Alice", result.First().Username);
    }
}
