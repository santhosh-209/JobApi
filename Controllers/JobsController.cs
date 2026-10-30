using Microsoft.AspNetCore.Mvc;
using JobApi.Models;
using JobApi.Services;

namespace JobApi.Controllers;
[ApiController]
[Route("api/[controller]")]
public class JobsController : ControllerBase
{
    private JobServices _jobServices;
    public JobsController(JobServices jobService)
    {
        _jobServices = jobService;
    }

    [HttpGet]
    public IActionResult GetAllJobs()
    {
        return Ok(_jobServices.GetAllJobs());
    }

    [HttpGet("{id}")]
    public IActionResult GetJobById(int id)
    {
        var response = _jobServices.GetJobById(id);
        if(response == null)
        return NotFound($"The Job with {id} is not found"); 
        return Ok(response);
    }

    [HttpPost]
    public IActionResult AddJob(Job job)
    {
        var createdJob = _jobServices.AddJob(job);

        return CreatedAtAction(
            nameof(GetJobById),
            new { id = createdJob.Id },
            createdJob);
    }
    [HttpPut("{id}")]
    public IActionResult UpdateJob(int id, Job job)
    {
        if (id != job.Id)
            return BadRequest("Id in the URL does not match the id in the body.");

        var response = _jobServices.UpdateJob(id, job);

        if (response == null)
            return NotFound($"Job with id {id} was not found.");

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteJob(int id)
    {
        var response = _jobServices.DeleteJob(id);

        if (!response)
            return NotFound($"Job with id {id} was not found.");

        return NoContent();
    }

    [HttpGet("search")]
    public IActionResult SearchJobs(string? title)
    {
        if(string.IsNullOrWhiteSpace(title))
            return BadRequest("Search title cannot be empty.");
        return Ok(_jobServices.SearchJobs(title));
    }
}
