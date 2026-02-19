namespace Ecommerce.Web.Areas.Admin.ViewModels
{
    public class DashboardViewModel
    {
        public int TotalOrders { get; set; }
        public int TotalUsers { get; set; }
        public int TotalProducts { get; set; }
        public int TotalMessages { get; set; }
        
        public string[] MonthlySalesLabels { get; set; }
        public decimal[] MonthlySalesData { get; set; }
        public string[] DailyViewsLabels { get; set; }
        public int[] DailyViewsData { get; set; }

    }
}
