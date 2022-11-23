using TestTaskBusinessSolution.BLL.DTO;

namespace TestTaskBusinessSolution.BLL.Interfaces
{
    public interface IOrdersService
    {
        List<OrderDTO> GetAll();
        List<OrderDTO> GetFiltered(int[] SelectedProviders, DateTime dateFrom, DateTime dateTo);
        Task<OrderDTO> Get(int id);
        Task<int> Create(OrderDTO order);
        Task Update(OrderDTO order);
        Task Delete(int id);
    }
}
