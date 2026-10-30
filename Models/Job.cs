using System.ComponentModel.DataAnnotations;

namespace JobApi.Models;
public class Job
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Title must give then only data can store in db")]
    public string Title { get; set; } = string.Empty;

    public string? Description { get; set; }

    public string? Location { get; set; }

    public decimal? Salary { get; set; }
}
