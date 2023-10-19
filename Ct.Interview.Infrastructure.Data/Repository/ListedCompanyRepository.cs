namespace Ct.Interview.Infrastructure.Data.Repository
{
    public class ListedCompanyRepository : IListedCompanyRepository
    {
        private readonly ASXListedCompaniesContext _context;

        public ListedCompanyRepository(ASXListedCompaniesContext context)
        {
            this._context = context;
        }

        public async Task<IList<ListedCompany>> GetListedCompanies()
        {
            return await this._context.Company.ToListAsync();
        }
    }
}
