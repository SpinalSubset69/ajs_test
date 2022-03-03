namespace AJSExample.Data.Dtos
{
    public class CreateProductDto
    {
        public string? Name { get; set; }
        public string? Price { get; set; }
        public string? Description { get; set; }
        public DateTime Created_At { get; set; }
    }
}