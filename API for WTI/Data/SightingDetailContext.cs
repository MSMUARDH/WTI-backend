using API_for_WTI.Models;
using Microsoft.EntityFrameworkCore;

namespace API_for_WTI.Data
{
    public class SightingDetailContext : DbContext
    {
        public SightingDetailContext(DbContextOptions<SightingDetailContext> options) : base(options)
        {

        }

        public DbSet<SightingDetail> SightingDetails { get; set; }
    }
}
