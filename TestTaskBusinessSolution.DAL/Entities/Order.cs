namespace TestTaskBusinessSolution.DAL.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public string? Number { get; set; }
        public DateTime Date { get; set; }

        /// <summary>
        /// Навигационное свойство
        /// </summary>
        public List<Item> Items { get; set; } = new List<Item>();

        /// <summary>
        /// Внешний ключ
        /// </summary>
        public int ProviderId { get; set; }
        /// <summary>
        /// Навигационное свойство
        /// </summary>
        public Provider? Provider { get; set; }
    }
}
