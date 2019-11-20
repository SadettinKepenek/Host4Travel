using System.Collections.Generic;
using Host4Travel.Core.DTO.DocumentTypeService;

namespace Host4Travel.BLL.Abstract
{
    public interface IDocumentTypeService
    {
        List<DocumentTypeListDto> GetAll();
        DocumentTypeListDto GetById();
        void Add(DocumentTypeAddDto model);
        void Update(DocumentTypeUpdateDto model);
        void Delete(DocumentTypeDeleteDto model);
    }
}