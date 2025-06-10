namespace ProductService.ApplicationCore.Models
{
    public class CategoryRequestModel
    {
        public string Name { get; set; }
        public int? ParentCategoryId { get; set; }
    }
}
