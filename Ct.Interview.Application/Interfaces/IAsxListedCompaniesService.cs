namespace Ct.Interview.Application.Interfaces
{
    public interface IAsxListedCompaniesService
    {
        Task<IList<ListedCompany>> GetByAsxCode(string asxCode);

        Task<IList<ListedCompany>> GetAll();
    }
}
