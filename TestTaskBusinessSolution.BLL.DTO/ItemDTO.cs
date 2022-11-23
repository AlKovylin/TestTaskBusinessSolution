namespace TestTaskBusinessSolution.BLL.DTO
{
    public class ItemDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Quantity { get; set; }//количество
        public string? Unit { get; set; }//единица измерения
    }
}
