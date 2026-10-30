using JobApi.Models;
using JobApi.Repository;
namespace JobApi.Services;

public class JobServices
{
    private readonly JobRepository _jobRepository;
    public JobServices(JobRepository jobRepository)
    {
        _jobRepository = jobRepository;
    }
    public List<Job> GetAllJobs()
    {
        return _jobRepository.GetAll();
    }

    public Job? GetJobById(int id)
    {
        return _jobRepository.GetById(id);
    }

    public Job AddJob(Job job)
    {
        _jobRepository.Add(job);
        return job;
    }

    public Job? UpdateJob(int id, Job updatedJob)
    {
        var existingJob = _jobRepository.GetById(id);

        if (existingJob == null)
        {
            return null;
        }

        existingJob.Title = updatedJob.Title;

        _jobRepository.Update(existingJob);

        return existingJob;
    }

    public bool DeleteJob(int id)
    {
        var job = GetJobById(id);

        if (job == null)
            return false;

        _jobRepository.Delete(job);
        return true;
    }

    public List<Job> SearchJobs(string title)
    {
        return _jobRepository.GetAll()
            .Where(j => j.Title.Contains(
                title, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }
}
