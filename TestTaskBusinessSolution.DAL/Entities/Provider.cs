namespace TestTaskBusinessSolution.DAL.Entities
{
    public class Provider
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        /// <summary>
        /// Навигационное свойство
        /// </summary>
        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
