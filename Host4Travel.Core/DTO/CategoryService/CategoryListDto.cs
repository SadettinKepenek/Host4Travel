namespace Host4Travel.Core.DTO.CategoryService
{
    public class CategoryListDto
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public string CategoryUrl { get; set; }
        public bool IsActive { get; set; } 
    }
}