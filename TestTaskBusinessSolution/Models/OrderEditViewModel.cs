namespace TestTaskBusinessSolution.Models
{
    public class OrderEditViewModel
    {
        public OrderViewModel? Order { get; set; }
        public List<ItemViewModel>? OrderItems { get; set; }
        public List<ProviderViewModel>? Providers { get; set; }
    }
}
