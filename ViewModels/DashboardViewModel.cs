namespace BookStore.ViewModels;
    public class DashboardViewModel
    {
        public int TotalBooks { get; set; }
        public int TotalUsers { get; set; }
        public int ActiveLoans { get; set; }
        public double TotalValue { get; set; }
    }