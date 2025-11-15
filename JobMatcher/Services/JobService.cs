using System.Net.Http.Json;
using JobMatcher.Models;

namespace JobMatcher.Services;

public class JobService
{
    private readonly HttpClient _http;

    public JobService(IHttpClientFactory factory)
    {
        _http = factory.CreateClient();
    }

    public async Task<List<Job>> GetJobsAsync()
    {
        var url = "https://remoteok.com/api";
        var data = await _http.GetFromJsonAsync<List<RemoteOkJob>>(url);

        if (data == null) return new();

        return data
            .Where(j => !string.IsNullOrEmpty(j?.Position))
            .Select(j => new Job
            {
                Title = j.Position ?? "",
                Company = j.Company ?? "",
                Location = j.Location ?? "Remote",
                Type = j.JobType ?? "",
                Description = j.Description ?? "",
                Url = j.Url ?? ""
            })
            .ToList();
    }

    public class RemoteOkJob
    {
        public string? Position { get; set; }
        public string? Company { get; set; }
        public string? Location { get; set; }
        public string? JobType { get; set; }
        public string? Description { get; set; }
        public string? Url { get; set; }
    }
}