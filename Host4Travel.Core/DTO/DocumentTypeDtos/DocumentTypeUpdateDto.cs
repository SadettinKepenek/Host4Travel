namespace Host4Travel.Core.DTO.DocumentTypeDtos
{
    public class DocumentTypeUpdateDto
    {
        public int DocumentTypeId { get; set; }
        public string DocumentTypeName { get; set; }
        public bool IsActive { get; set; }
    }
}