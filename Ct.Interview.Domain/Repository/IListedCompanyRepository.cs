namespace Ct.Interview.Domain.Repository
{
    public interface IListedCompanyRepository
    {
        Task<IList<ListedCompany>> GetListedCompanies();
    }
}
