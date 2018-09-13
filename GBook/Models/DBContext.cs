using System.Data.Entity;

namespace GBook.Models
{
    public class DBContext : DbContext
    {
        public DbSet<Record> Records { get; set; }
    }
}