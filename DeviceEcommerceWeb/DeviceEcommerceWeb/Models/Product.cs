namespace DeviceEcommerceWeb.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Category { get; set; }

        public string Status { get; set; }

        public Product(int id, string name, int quantity, string category, string status)
        {
            Id = id;
            Name = name;
            Quantity = quantity;
            Category = category;
            Status = status;
        }
    }
}
