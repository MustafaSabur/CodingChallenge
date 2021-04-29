using Challenge.DataModels;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{
    public class AccessLogContext : DbContext
    {
        public AccessLogContext(DbContextOptions<AccessLogContext> opts) : base(opts)
        {
        }

        public DbSet<AccessLog> AccessLogs { get; set; }

    }
}