
using Microsoft.EntityFrameworkCore;
using YachtApi.Models;

namespace YachtApi.Data
{
    public class YachtDbContext : DbContext
    {
        public YachtDbContext(
            DbContextOptions<YachtDbContext> options)
            : base(options)
        {
        }

        public DbSet<Berles> Berlesek { get; set; }
    }
}
