using System.ComponentModel.DataAnnotations.Schema;

namespace valven_deneme.Entity
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Date { get; set; }
        [ForeignKey("AuthorId")]
        public ICollection<Commit> Commits { get; set; }
    }
}
