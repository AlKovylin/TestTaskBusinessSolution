using Microsoft.AspNetCore.Mvc.Rendering;

namespace TestTaskBusinessSolution.Models
{
    public class OrdersViewModel
    {
        public List<OrderViewModel>? Orders { get; set; }
        public SelectList? Providers { get; set; }
        public int[]? SelectedProviders { get; set; }
    }
}
