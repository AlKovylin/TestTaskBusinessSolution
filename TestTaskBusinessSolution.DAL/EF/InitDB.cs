using TestTaskBusinessSolution.DAL.Entities;

namespace TestTaskBusinessSolution.DAL.EF
{
    public class InitDB
    {
        private static Provider provider1 = new Provider() { Id = 1, Name = "Петротех" };
        private static Provider provider2 = new Provider() { Id = 2, Name = "Союзметалл" };
        private static Provider provider3 = new Provider() { Id = 3, Name = "Вестмет" };
        private static Provider provider4 = new Provider() { Id = 4, Name = "Севзапметалл" };
        private static Provider provider5 = new Provider() { Id = 5, Name = "Петроснаб" };

        private static Order order1 = new Order() { Id = 1, Number = "TT852431", Date = DateTime.Now.AddMonths(-1).AddDays(-5), ProviderId = provider1.Id };
        private static Order order2 = new Order() { Id = 2, Number = "TT852432", Date = DateTime.Now.AddMonths(-1).AddDays(-7), ProviderId = provider1.Id };
        private static Order order3 = new Order() { Id = 3, Number = "TT852433", Date = DateTime.Now.AddMonths(-2), ProviderId = provider1.Id };
        private static Order order4 = new Order() { Id = 4, Number = "TT852434", Date = DateTime.Now.AddDays(-3), ProviderId = provider2.Id };
        private static Order order5 = new Order() { Id = 5, Number = "TT852435", Date = DateTime.Now.AddDays(-8), ProviderId = provider2.Id };
        private static Order order6 = new Order() { Id = 6, Number = "TT852436", Date = DateTime.Now.AddMonths(-2).AddDays(-1), ProviderId = provider3.Id };
        private static Order order7 = new Order() { Id = 7, Number = "TT852437", Date = DateTime.Now.AddDays(-2), ProviderId = provider4.Id };
        private static Order order8 = new Order() { Id = 8, Number = "TT852438", Date = DateTime.Now.AddDays(-5), ProviderId = provider4.Id };
        private static Order order9 = new Order() { Id = 9, Number = "TT852439", Date = DateTime.Now, ProviderId = provider4.Id };
        private static Order order10 = new Order() { Id = 10, Number = "TT853437", Date = DateTime.Now.AddMonths(-1).AddDays(-10), ProviderId = provider5.Id };
        private static Order order11 = new Order() { Id = 11, Number = "TT854437", Date = DateTime.Now.AddMonths(-2).AddDays(-12), ProviderId = provider5.Id };
        private static Order order12 = new Order() { Id = 12, Number = "TT855437", Date = DateTime.Now, ProviderId = provider5.Id };
        private static Order order13 = new Order() { Id = 13, Number = "TT856437", Date = DateTime.Now.AddMonths(-1).AddDays(-15), ProviderId = provider5.Id };
        private static Order order14 = new Order() { Id = 14, Number = "TT857437", Date = DateTime.Now.AddMonths(-2).AddDays(-10), ProviderId = provider5.Id };

        private static Item orderItem1 = new Item() { Id = 1, Name = "Бронза D20", Quantity = 200.55m, Unit = "мм", OrderId = order1.Id };
        private static Item orderItem2 = new Item() { Id = 2, Name = "Алюминий D500", Quantity = 0.350m, Unit = "м", OrderId = order1.Id };
        private static Item orderItem3 = new Item() { Id = 3, Name = "Медь D10 L1000", Quantity = 50.00m, Unit = "шт", OrderId = order1.Id };
        private static Item orderItem4 = new Item() { Id = 4, Name = "Бронза D45", Quantity = 450.80m, Unit = "мм", OrderId = order1.Id };
        private static Item orderItem5 = new Item() { Id = 5, Name = "Латунь D80", Quantity = 10.70m, Unit = "м", OrderId = order1.Id };

        private static Item orderItem6 = new Item() { Id = 6, Name = "Труба профильная 20х20х1,5", Quantity = 500.87m, Unit = "кг", OrderId = order4.Id };
        private static Item orderItem7 = new Item() { Id = 7, Name = "Труба профильная 25х25х1,5", Quantity = 250.00m, Unit = "кг", OrderId = order4.Id };
        private static Item orderItem8 = new Item() { Id = 8, Name = "Труба профильная 40х60х2", Quantity = 0.92m, Unit = "т", OrderId = order4.Id };
        private static Item orderItem9 = new Item() { Id = 9, Name = "Труба профильная 40х40х1,5", Quantity = 2.36m, Unit = "т", OrderId = order4.Id };
        private static Item orderItem10 = new Item() { Id = 10, Name = "Труба профильная 80х60х2,5", Quantity = 10.45m, Unit = "т", OrderId = order4.Id };
        private static Item orderItem11 = new Item() { Id = 11, Name = "Арматура D10", Quantity = 8.25m, Unit = "т", OrderId = order4.Id };

        public static List<Provider> CreateProvider()
        {            
            return new List<Provider> { provider1, provider2, provider3, provider4, provider5 };
        }

        public static List<Order> CreateOrder()
        {
            return new List<Order> { order1, order2, order3, order4, order5, order6, order7, order8, order9, order10, order11, order12, order13, order14 };
        }

        public static List<Item> CreateItem() 
        {
            return new List<Item> { orderItem1, orderItem2, orderItem3, orderItem4, orderItem5, orderItem6, 
                                         orderItem7, orderItem8, orderItem9, orderItem10, orderItem11 };
        }        
    }
}
