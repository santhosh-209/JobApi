
using JobApi.Data;
using JobApi.Models;
using Microsoft.EntityFrameworkCore;

namespace JobApi.Repository;

public class JobRepository
{
    private readonly JobDbContext _context;

    public JobRepository(JobDbContext context)
    {
        _context = context;
    }

    public List<Job> GetAll()
    {
        return _context.Jobs.ToList();
    }

    public Job? GetById(int id)
    {
        return _context.Jobs.FirstOrDefault(j => j.Id == id);
    }

    public void Add(Job job)
    {
        _context.Jobs.Add(job);
        _context.SaveChanges();
    }

    public bool Delete(Job job)
    {
        _context.Jobs.Remove(job);
        return _context.SaveChanges() > 0;
    }
    public void Update(Job job)
    {
        _context.Jobs.Update(job);
        _context.SaveChanges();
    }
}
