namespace UMS.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class UmsDbContext : IdentityDbContext
    {
        public UmsDbContext(DbContextOptions<UmsDbContext> options)
            : base(options)
        {
        }
    }
}
