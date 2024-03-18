using Newtonsoft.Json;
using System.Net.Http.Headers;
using valven_deneme.Entity;
using valven_deneme.Models;
using valven_deneme.Repository;

namespace valven_deneme.Service
{
    public class GitHubService : IGitHubService
    {
        private readonly HttpClient _httpClient;
        private readonly DataContext _context;
        private readonly CommitRepository _commitRepository;
        private readonly AuthorRepository _authorRepository;
        public List<Commit> commitEntities = new List<Commit>();
        public List<Author> authorEntities = new List<Author>();
        public GitHubService(HttpClient httpClient, DataContext context, AuthorRepository authorRepository, CommitRepository commitRepository)
        {

            _httpClient = httpClient;
            _commitRepository = commitRepository;
            _authorRepository = authorRepository;
            _context = context;

        }

        public async Task<List<GitHub>> GetCommits(string owner, string repo)
        {

            var url = $"repos/{owner}/{repo}/commits";
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "GitHubApiClient");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "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");
            _httpClient.Timeout = TimeSpan.FromSeconds(30);

            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                // Handle error
                return null;
            }

            var content = await response.Content.ReadAsStringAsync();
            var githubcommits = JsonConvert.DeserializeObject<List<GitHub>>(content);


            // Dönüşüm işlemleri
            //Commit commit = new Commit();


            foreach (var gitHub in githubcommits)
            {

                var author = new Author
                {
                    Name = gitHub.Commit.Author.Name,
                    Email = gitHub.Commit.Author.Email,
                    Date = gitHub.Commit.Author.Date
                };
                await _authorRepository.AddAuthor(author);
                authorEntities.Add(author);
                // Sonra Commit'i ekleyin ve AuthorId'yi doğru şekilde ayarlayın
                var commit = new Commit
                {
                    AuthorId = author.Id,
                    Hash = gitHub.Sha,
                    Message = gitHub.Commit.Message,
                    Timestamp = gitHub.Commit.Author.Date,
                    Patch = ""

                };
                await _commitRepository.AddCommit(commit);
                commitEntities.Add(commit);
                break;
            }

            return githubcommits;
        }

        public Task<List<Commit>> GetCommitField()
        {
            return Task.FromResult(commitEntities);
        }
        public Task<List<Author>> GetAuthorField()
        {
            return Task.FromResult(authorEntities);
        }
    }
}
