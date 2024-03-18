using System.ComponentModel.DataAnnotations.Schema;

namespace valven_deneme.Entity
{
    public class Commit
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public string Hash { get; set; }
        public string Timestamp { get; set; }
        public string Patch { get; set; }

        [ForeignKey("Author")]
        public int AuthorId { get; set; }
        public Author? Author { get; set; }
    }
}
