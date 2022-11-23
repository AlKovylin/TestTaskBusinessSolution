using AutoMapper;
using TestTaskBusinessSolution.BLL.DTO;
using TestTaskBusinessSolution.BLL.Exeption;
using TestTaskBusinessSolution.BLL.Interfaces;
using TestTaskBusinessSolution.DAL.Entities;
using TestTaskBusinessSolution.DAL.Interfaces;

namespace TestTaskBusinessSolution.BLL.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OrdersService(IUnitOfWork unitOfWork, IMapper mappr)
        {
            _unitOfWork = unitOfWork;
            _mapper = mappr;
        }

        public async Task<OrderDTO> Get(int id)
        {
            _unitOfWork.GetRepository<Provider>().GetAll();

            var order = await _unitOfWork.GetRepository<Order>().Get(id);

            var orderDTO = _mapper.Map<Order, OrderDTO>(order!);

            return orderDTO;
        }

        public List<OrderDTO> GetAll()
        {
            _unitOfWork.GetRepository<Provider>().GetAll();

            var orders = _unitOfWork.GetRepository<Order>().GetAll();

            var ordersDTO = _mapper.Map<List<Order>, List<OrderDTO>>(orders.ToList());
 
            return ordersDTO;
        }

        public List<OrderDTO> GetFiltered(int[] SelectedProviders, DateTime dateFrom, DateTime dateTo)
        {
            _unitOfWork.GetRepository<Provider>().GetAll();

            var orders = _unitOfWork.GetRepository<Order>().GetAll()
                .Where(x => x.Date.Date >= dateFrom.Date && x.Date.Date <= dateTo.Date);

            orders = SelectedProviders != null ? orders.Where(x => SelectedProviders.Contains(x.ProviderId)) : orders;

            var result = orders.OrderByDescending(x => x.Date).ToList();

            var orderDTOList = _mapper.Map<List<Order>, List<OrderDTO>>(result);

            return orderDTOList;
        }

        public async Task<int> Create(OrderDTO order)
        {
            CheckOrder(order);

            var newOrder = _mapper.Map<OrderDTO, Order>(order);

            newOrder.Date = DateTime.Now;

            await _unitOfWork.GetRepository<Order>().Create(newOrder);

            return newOrder.Id;
        }

        public async Task Update(OrderDTO order)
        {
            CheckOrder(order);

            var updateOrder = await _unitOfWork.GetRepository<Order>().Get(order.Id);

            updateOrder = _mapper.Map(order, updateOrder!);

            await _unitOfWork.GetRepository<Order>().Update(updateOrder);
        }

        private void CheckOrder(OrderDTO order)
        {
            if (order.Number == null)
                throw new NumberOrderException("Номер заказа не может быть пустым.");

            if (_unitOfWork.GetRepository<Order>()
                .GetAll()
                .Where(x => x.ProviderId == order.ProviderId)
                .Any(x => x.Number == order.Number))
                throw new NumberOrderException("Заказ с таким номером уже существует. Введите другой номер.");
        }

        public async Task Delete(int id)
        {
            var order = await _unitOfWork.GetRepository<Order>().Get(id);

            await _unitOfWork.GetRepository<Order>().Delete(order!);
        }
    }
}
