using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TestTaskBusinessSolution.BLL.DTO;
using TestTaskBusinessSolution.BLL.Exeption;
using TestTaskBusinessSolution.BLL.Interfaces;
using TestTaskBusinessSolution.Models;

namespace TestTaskBusinessSolution.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ILogger<OrdersController> _logger;
        private readonly IOrdersService _orderService;
        private readonly IProviderService _providerService;
        private readonly IItemService _itemService;
        private readonly IMapper _mapper;

        public OrdersController(ILogger<OrdersController> logger,
                                IOrdersService orderService,
                                IProviderService providerService,
                                IItemService itemService,
                                IMapper mapper)
        {
            _logger = logger;
            _orderService = orderService;
            _providerService = providerService;
            _itemService = itemService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var orders = _orderService.GetAll()
                .Where(x => x.Date.Date <= DateTime.Now.Date && x.Date.Date >= DateTime.Now.AddMonths(-1))
                .OrderByDescending(x => x.Date);

            var model = new OrdersViewModel()
            {
                Orders = _mapper.Map<List<OrderDTO>, List<OrderViewModel>>(orders.ToList()),
                Providers = new SelectList(ProvidersDictionary(), "Key", "Value")
            };

            return View(model);
        }

        private Dictionary<int, string> ProvidersDictionary()
        {
            var providers = _providerService.GetAll();

            return providers.Select(x => new KeyValuePair<int, string>(x.Id, x.Name!))
                    .Distinct()
                    .OrderBy(x => x.Value)
                    .ToDictionary(t => t.Key, t => t.Value);
        }

        [HttpPost]
        public IActionResult ApplyFilters(OrdersViewModel viewModel, DateTime dateFrom, DateTime dateTo)
        {
            var data = _orderService.GetFiltered(viewModel.SelectedProviders!, dateFrom, dateTo);

            var model = _mapper.Map<List<OrderDTO>, List<OrderViewModel>>(data);

            return PartialView("_OrdersPartial", model);
        }

        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var order = await _orderService.Get(id);

            var orderItems = _itemService.GetAll(id);

            var model = new OrderViewingViewModel()
            {
                Order = _mapper.Map<OrderDTO, OrderViewModel>(order),
                OrderItems = _mapper.Map<List<ItemDTO>, List<ItemViewModel>>(orderItems)
            };

            return View("OrderViewing", model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new OrderCreateViewModel() { Providers = new SelectList(ProvidersDictionary(), "Key", "Value") };

            return View("OrderCreate", model);
        }

        [HttpPost]
        public async Task<JsonResult> Create(OrderCreateViewModel model)
        {
            var orderDTO = _mapper.Map<OrderCreateViewModel, OrderDTO>(model);

            try
            {
                int id = await _orderService.Create(orderDTO);

                return Json(new { success = true, message = "Заказ успешно создан.", redirect = $"/Orders/Update/{id}" });
            }
            catch (NumberOrderException ex)
            {
                return Json(new { success = false, message = ex.Message });
            }

            //return Json("Заказ успешно создан.");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var order = await _orderService.Get(id);

            var orderItems = _itemService.GetAll(id);

            var providers = _providerService.GetAll().Select(x => new ProviderViewModel() { Id = x.Id, Name = x.Name })
                .Distinct()
                .OrderBy(x => x.Name)
                .ToList();

            var model = new OrderEditViewModel()
            {
                Order = _mapper.Map<OrderDTO, OrderViewModel>(order),
                OrderItems = _mapper.Map<List<ItemDTO>, List<ItemViewModel>>(orderItems),
                Providers = providers
            };

            return View("OrderEdit", model);
        }

        [HttpPost]
        public async Task<JsonResult> Update(OrderViewModel model)
        {
            var order = _mapper.Map<OrderViewModel, OrderDTO>(model);

            try
            {
                await _orderService.Update(order);

                return Json("Изменения сохранены.");
            }
            catch (NumberOrderException ex)
            {
                return Json(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _orderService.Delete(id);

                return Json(new { success = true, message = "Заказ удалён.", redirect = "/Orders/Index/" });
            }
            catch
            {
                return Json(new { success = false, message = "Ошибка! Что-то пошло не так." });
            }
        }
    }
}