using valven_deneme.Entity;

namespace valven_deneme.Repository
{
    public class CommitRepository
    {
        private readonly DataContext _context;

        public CommitRepository(DataContext context)
        {
            _context = context;
        }
        public async Task AddCommit(Commit commit)
        {
            _context.Commits.Add(commit);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Inner exception'ı görüntüle
                var innerException = ex.InnerException;
                Console.WriteLine(innerException.Message);
            }

        }

    }
}
