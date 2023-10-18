namespace CarWorkshop
{
    public class Car
    {
        public int CarId { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public int YearOfRelease { get; set; }
        public string VinCode { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}