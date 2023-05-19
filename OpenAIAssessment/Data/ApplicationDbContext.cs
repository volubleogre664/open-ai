namespace OpenAIAssessment.Data
{
    using Microsoft.EntityFrameworkCore;

    using OpenAIAssessment.Models;
    
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Chat> Chats { get; set; }

        public DbSet<TextEditor> TextEdits { get; set; }

        public DbSet<History> Histories { get; set; }
    }
}
