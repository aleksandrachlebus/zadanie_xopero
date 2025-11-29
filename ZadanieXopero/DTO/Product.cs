namespace ZadanieXopero.DTO
{
    public class Product
    {
        public int quantity { get; set; }
        public String name { get; set; }
        public String description { get; set; }
        public String price { get; set; }

        public Product(int quantity, String name, String description, String price)
        {
            this.quantity = quantity;
            this.name = name;
            this.description = description;
            this.price = price;
        }
    }
}
