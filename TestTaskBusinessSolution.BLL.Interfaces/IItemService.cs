using TestTaskBusinessSolution.BLL.DTO;

namespace TestTaskBusinessSolution.BLL.Interfaces
{
    public interface IItemService
    {
        Task<ItemDTO> Get(int id);
        List<ItemDTO> GetAll(int idOrder);
        Task<int> Create(CreateItemDTO item);
        Task Update(ItemDTO item);
        Task Delete(int id);
    }
}
