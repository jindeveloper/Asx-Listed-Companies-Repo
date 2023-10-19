namespace Ct.Interview.Web.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [EnableCors("AsxListeCompaniesCorsPolicy")]
    public class AsxListedCompaniesController : ControllerBase
    {
        private readonly IAsxListedCompaniesService _asxListedCompaniesService;
        private readonly IMapper _mapper;
        private readonly ILogger<AsxListedCompaniesController> _logger;

        public AsxListedCompaniesController(IAsxListedCompaniesService asxListedCompaniesService,
                                            IMapper mapper,
                                            ILoggerFactory logger)
        {
            this._asxListedCompaniesService = asxListedCompaniesService;
            this._mapper = mapper;
            this._logger = logger.CreateLogger<AsxListedCompaniesController>();
        }

        [HttpGet]
        [ActionName("GetCompanies")]
        public async Task<IActionResult> Get(string asxCode = "")
        {
            IList<ListedCompany> asxListedCompanies = new List<ListedCompany>();
            List<AsxListedCompanyResponseViewModel> result = new();

            try
            {
                if (!string.IsNullOrEmpty(asxCode))
                {
                    this._logger.LogDebug($"Searching for asxCode: {asxCode}");
                    
                    asxListedCompanies = await _asxListedCompaniesService.GetByAsxCode(asxCode);
                    
                    this._logger.LogDebug($"Searching for asxCode: {asxCode} done with total records of {asxListedCompanies.Count()} ");
                }
                else
                {
                    this._logger.LogDebug($"Getting all records of ASX listed companies start");
                    
                    asxListedCompanies = await _asxListedCompaniesService.GetAll();

                    this._logger.LogDebug($"Getting all records of ASX listed companies done");
                }

                result = this._mapper.Map<List<AsxListedCompanyResponseViewModel>>(asxListedCompanies);

                return Ok(result);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.Message);

                return BadRequest(ex.Message);
            }
        }
    }
}
