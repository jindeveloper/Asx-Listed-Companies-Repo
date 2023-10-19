namespace Ct.Interview.Application.Service
{
    public class AsxListedCompaniesService : IAsxListedCompaniesService
    {
        private readonly IListedCompanyRepository _listedCompanyRepository;

        public AsxListedCompaniesService(IListedCompanyRepository listedCompanyRepository)
        {
            this._listedCompanyRepository = listedCompanyRepository;
        }

        public async Task<IList<ListedCompany>> GetAll()
        {
            return await this._listedCompanyRepository.GetListedCompanies();
        }

        public async Task<IList<ListedCompany>> GetByAsxCode(string asxCode)
        {
            var result = await this._listedCompanyRepository.GetListedCompanies();

            var listedCompany = result.Where(x => x.Code.Contains(asxCode)).ToList();

            return listedCompany;
        }
    }
}
