using JobApi.Models;
using Microsoft.EntityFrameworkCore;

namespace JobApi.Data;
public class JobDbContext : DbContext
{
    public JobDbContext(
        DbContextOptions<JobDbContext> options)
        : base(options)
    {
    }

    public DbSet<Job> Jobs { get; set; }
}
