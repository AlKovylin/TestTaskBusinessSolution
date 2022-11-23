using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TestTaskBusinessSolution.BLL.DTO;
using TestTaskBusinessSolution.BLL.Exceptions;
using TestTaskBusinessSolution.BLL.Interfaces;
using TestTaskBusinessSolution.Models;

namespace TestTaskBusinessSolution.Controllers
{
    public class ItemsController : Controller
    {
        private readonly IItemService _itemService;
        private readonly IMapper _mapper;

        public ItemsController(IItemService itemService, IMapper mapper)
        {
            _itemService = itemService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateItemViewModel model)
        {
            var item = _mapper.Map<CreateItemViewModel, CreateItemDTO>(model);

            try
            {
                var itemId = await _itemService.Create(item);

                var itemDTO = await _itemService.Get(itemId);

                var resultModel = _mapper.Map<ItemDTO, ItemViewModel>(itemDTO);

                return Json(new { success = true, resultModel });
            }
            catch (NameItemException ex)
            {
                return Json(new { success = false, message = ex.Message });                
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update(ItemViewModel model)
        {
            var item = _mapper.Map<ItemViewModel, ItemDTO>(model);

            try
            {
                await _itemService.Update(item);

                return Json(new { success = true });
            }
            catch (NameItemException ex)
            {
                return Json(new { success = false, message = ex.Message });
            }           
        }

        [HttpPost]
        public async Task Delete(int id)
        {
            await _itemService.Delete(id);
        }
    }
}
