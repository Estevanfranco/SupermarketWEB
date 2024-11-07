namespace SupermarketWEB.Models
{
    public class Customers
    {
        public int Id { get; set; } // Será la llave primaria
        public int DocumentNum { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string BithDay { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

    }
}
