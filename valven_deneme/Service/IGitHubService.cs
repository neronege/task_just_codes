using valven_deneme.Models;

namespace valven_deneme.Service
{
    public interface IGitHubService
    {
        Task<List<GitHub>> GetCommits(string owner, string repo);
    }
}
