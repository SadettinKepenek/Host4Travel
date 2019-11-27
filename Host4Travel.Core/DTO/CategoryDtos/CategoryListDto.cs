using System.Collections.Generic;

namespace Host4Travel.Core.DTO.CategoryDtos
{
    public class CategoryListDto
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public string CategoryUrl { get; set; }
        public bool IsActive { get; set; } 
        public virtual CategoryListDto CategoryParent { get; set; }
        public virtual ICollection<CategoryListDto> InverseCategoryParent { get; set; }
    }
}