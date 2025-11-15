using Microsoft.AspNetCore.Mvc.RazorPages;
using JobMatcher.Models;
using JobMatcher.Services;

namespace JobMatcher.Pages;

public class IndexModel : PageModel
{
    private readonly JobService _jobService;

    public IndexModel(JobService jobService)
    {
        _jobService = jobService;
    }

    public List<Job> Jobs { get; set; } = new();
    public int Page { get; set; }
    public int TotalPages { get; set; }

    public async Task OnGet(int page = 1, int pageSize = 20)
    {
        var allJobs = await _jobService.GetJobsAsync(); // RemoteOK data

        Page = page;
        TotalPages = (int)Math.Ceiling(allJobs.Count / (double)pageSize);

        Jobs = allJobs
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToList();
    }
}