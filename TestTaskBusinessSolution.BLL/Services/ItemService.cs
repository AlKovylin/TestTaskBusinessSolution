using AutoMapper;
using TestTaskBusinessSolution.BLL.DTO;
using TestTaskBusinessSolution.BLL.Exceptions;
using TestTaskBusinessSolution.BLL.Interfaces;
using TestTaskBusinessSolution.DAL.Entities;
using TestTaskBusinessSolution.DAL.Interfaces;

namespace TestTaskBusinessSolution.BLL.Services
{
    public class ItemService : IItemService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ItemService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ItemDTO> Get(int id)
        {
            var item = await _unitOfWork.GetRepository<Item>().Get(id);

            var itemDTO = _mapper.Map<Item, ItemDTO>(item!);

            return itemDTO;
        }

        public List<ItemDTO> GetAll(int idOrder)
        {
            var item = _unitOfWork.GetRepository<Item>().GetAll().Where(x => x.OrderId == idOrder);

            var listItemDTO = _mapper.Map<List<Item>, List<ItemDTO>>(item.ToList());

            return listItemDTO;
        }

        public async Task<int> Create(CreateItemDTO item)
        {
            CheckItemNameNotNull(item.Name!);

            var order = await _unitOfWork.GetRepository<Order>().Get(item.OrderId);

            if (item.Name == order!.Number)
                throw new NameItemException("Наименование товара не может совпадать с номером заказа.");

            var _item = _mapper.Map<CreateItemDTO, Item>(item);

            await _unitOfWork.GetRepository<Item>().Create(_item);

            var idNewItem = _item.Id;

            return idNewItem;
        }

        public async Task Update(ItemDTO item)
        {
            CheckItemNameNotNull(item.Name!);            

            var updateItem = await _unitOfWork.GetRepository<Item>().Get(item.Id);

            var order = _unitOfWork.GetRepository<Order>().GetAll().FirstOrDefault(x => x.Id == updateItem!.OrderId);

            if (item.Name == order!.Number)
                throw new NameItemException("Наименование товара не может совпадать с номером заказа.");

            updateItem = _mapper.Map(item, updateItem!);

            await _unitOfWork.GetRepository<Item>().Update(updateItem);
        }

        private void CheckItemNameNotNull(string name)
        {
            if (name == null)
                throw new NameItemException("Наименование не может быть пустым.");
        }

        public async Task Delete(int id)
        {
            var item = await _unitOfWork.GetRepository<Item>().Get(id);

            await _unitOfWork.GetRepository<Item>().Delete(item!);
        }
    }
}
