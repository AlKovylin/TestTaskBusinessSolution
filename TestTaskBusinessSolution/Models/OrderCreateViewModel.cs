using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace TestTaskBusinessSolution.Models
{
    public class OrderCreateViewModel
    {
        [Required(ErrorMessage = "Введите номер заказа")]
        [DataType(DataType.Text)]
        public string? Number { get; set; }

        public SelectList? Providers { get; set; }
        public int SelectedProvider { get; set; }
    }
}
