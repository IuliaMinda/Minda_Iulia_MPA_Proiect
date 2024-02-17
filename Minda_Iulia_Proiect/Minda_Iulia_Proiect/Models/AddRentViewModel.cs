namespace Minda_Iulia_Proiect.Models
{
    public class AddRentViewModel
    {
        public int CustomerID { get; set; }
        public int CarID { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public Customer Customer { get; set; }
        public Car Car { get; set; }
    }
}
