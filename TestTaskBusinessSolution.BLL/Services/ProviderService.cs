using AutoMapper;
using TestTaskBusinessSolution.BLL.DTO;
using TestTaskBusinessSolution.BLL.Interfaces;
using TestTaskBusinessSolution.DAL.Entities;
using TestTaskBusinessSolution.DAL.Interfaces;

namespace TestTaskBusinessSolution.BLL.Services
{
    public class ProviderService : IProviderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProviderService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public List<ProviderDTO> GetAll()
        {
            var providers = _unitOfWork.GetRepository<Provider>().GetAll();

            return _mapper.Map<List<Provider>, List<ProviderDTO>>(providers.ToList());
        }
    }
}
