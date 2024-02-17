namespace Minda_Iulia_Proiect.Models
{
    public class Rent
    {
        public int RentID { get; set; }
        public int CustomerID { get; set;}
        public int CarID { get; set;}
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public Customer Customer { get; set;}   
        public Car Car { get; set; }
    }
}
