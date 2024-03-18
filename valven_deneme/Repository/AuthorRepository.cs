using valven_deneme.Entity;

namespace valven_deneme.Repository
{
    public class AuthorRepository
    {
        private readonly DataContext _context;

        public AuthorRepository(DataContext context)
        {
            _context = context;
        }
        public async Task AddAuthor(Author author)
        {
            _context.Authors.Add(author);
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
