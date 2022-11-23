namespace TestTaskBusinessSolution.Models
{
    public class ItemViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Quantity { get; set; }//количество
        public string? Unit { get; set; }//единица измерения
    }
}
