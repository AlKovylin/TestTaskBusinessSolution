namespace TestTaskBusinessSolution.Models
{
    public class CreateItemViewModel
    {
        public int OrderId { get; set; }
        public string? Name { get; set; }
        public decimal Quantity { get; set; }//количество
        public string? Unit { get; set; }//единица измерения
    }
}
