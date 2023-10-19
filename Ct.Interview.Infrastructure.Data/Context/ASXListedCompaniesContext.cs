namespace Ct.Interview.Infrastructure.Data.Context
{
    public class ASXListedCompaniesContext : DbContext
    {
        public ASXListedCompaniesContext(DbContextOptions<ASXListedCompaniesContext> options): base (options) { }

        public DbSet<ListedCompany> Company { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ListedCompanySeedConfiguration());
        }
    }
}
