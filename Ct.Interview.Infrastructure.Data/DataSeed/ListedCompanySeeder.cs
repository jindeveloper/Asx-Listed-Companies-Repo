namespace Ct.Interview.Infrastructure.Data.DataSeed
{
    public class ListedCompanySeeder
    {
        private readonly ASXListedCompaniesContext _dbContext;

        public ListedCompanySeeder(ASXListedCompaniesContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task ConfigureDatabase()
        {
            await this._dbContext.Database.EnsureCreatedAsync();
            await this._dbContext.SaveChangesAsync();
        }
    }
}
