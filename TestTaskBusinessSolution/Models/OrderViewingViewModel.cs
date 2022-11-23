namespace TestTaskBusinessSolution.Models
{
    public class OrderViewingViewModel
    {
        public OrderViewModel? Order { get; set; }
        public List<ItemViewModel>? OrderItems { get; set; }
    }
}
