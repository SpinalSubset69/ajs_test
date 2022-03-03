namespace AJSExample.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Price { get; set; }

        public string? Description { get; set; }
        public DateTime Created_At { get; set; }
        public string? Image { get; set; }
    }
}