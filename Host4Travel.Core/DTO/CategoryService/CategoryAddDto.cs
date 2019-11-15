﻿namespace Host4Travel.Core.DTO.CategoryService
{
    public class CategoryAddDto
    {
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public string CategoryUrl { get; set; }
        public int CategoryLevel { get; set; }
        public int? CategoryParentId { get; set; }
        public bool IsActive { get; set; } 
    }
}