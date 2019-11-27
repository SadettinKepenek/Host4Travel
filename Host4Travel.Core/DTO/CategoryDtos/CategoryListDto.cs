namespace Host4Travel.Core.DTO.CategoryDtos
{
    public class CategoryListDto
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public string CategoryParentId { get; set; }
        public string CategoryParentName { get; set; }
    }
}