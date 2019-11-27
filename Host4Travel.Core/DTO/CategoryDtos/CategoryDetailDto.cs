using System.Collections.Generic;

namespace Host4Travel.Core.DTO.CategoryDtos
{
    public class CategoryDetailDto
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public string CategoryUrl { get; set; }
        public bool IsActive { get; set; } 
        public virtual CategoryDetailDto CategoryParent { get; set; }
        public virtual ICollection<CategoryDetailDto> InverseCategoryParent { get; set; }
    }
}