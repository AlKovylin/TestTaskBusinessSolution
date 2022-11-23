namespace TestTaskBusinessSolution.DAL.Entities
{
    public class Item
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Quantity { get; set; }//количество
        public string? Unit { get; set; }//единица измерения

        public int OrderId { get; set; }
        public Order? Order { get; set; }
    }
}
