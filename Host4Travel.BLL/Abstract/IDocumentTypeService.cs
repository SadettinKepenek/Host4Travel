using System.Collections.Generic;
using Host4Travel.Core.DTO.DocumentTypeDtos;

namespace Host4Travel.BLL.Abstract
{
    public interface IDocumentTypeService
    {
        List<DocumentTypeDetailDto> GetAll();
        DocumentTypeDetailDto GetById(int id);
        void Add(DocumentTypeAddDto model);
        void Update(DocumentTypeUpdateDto model);
        void Delete(DocumentTypeDeleteDto model);
    }
}