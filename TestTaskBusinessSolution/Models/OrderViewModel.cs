using System.ComponentModel.DataAnnotations;

namespace TestTaskBusinessSolution.Models
{
    public class OrderViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Введите номер заказа")]
        [DataType(DataType.Text)]
        public string? Number { get; set; }

        [Required(ErrorMessage = "Укажите дату заказа")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        
        public int ProviderId { get; set; }
        public string? ProviderName { get; set; }
    }
}
