using Microsoft.EntityFrameworkCore;
using BaiKiemTra02.Models;

namespace BaiKiemTra02.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<LopHoc> LopHoc { get; set; }
    }
}
