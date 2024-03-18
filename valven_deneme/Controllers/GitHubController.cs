using Microsoft.AspNetCore.Mvc;
using valven_deneme.Service;

namespace valven_deneme.Controllers
{
    public class GitHubController : Controller
    {
        private readonly GitHubService _gitHubService;

        public GitHubController(GitHubService gitHubService)
        {
            _gitHubService = gitHubService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("repos/{owner}/{repo}/commits")]
        public async Task<IActionResult> GetCommits(string owner, string repo)
        {
            try
            {
                var gitHubs = await _gitHubService.GetCommits(owner, repo);
                if (gitHubs == null)
                {
                    return NotFound();
                }
                var commits = await _gitHubService.GetCommitField();
                return View("CommitList", commits);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

        }
        [HttpGet("repos/{owner}/{repo}/commits/author")]
        public async Task<IActionResult> GetAuthor()
        {
            var authors = await _gitHubService.GetAuthorField();
            return View("Author", authors);

        }
    }
}
