namespace Minda_Iulia_Proiect.Models
{
    public class AddCarViewModel
    {
        public string RegistrationPlate { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public ICollection<Rent> Rents { get; set; }
    }
}
