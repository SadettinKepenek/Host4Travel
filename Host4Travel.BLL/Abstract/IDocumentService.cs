using System.Collections.Generic;
using Host4Travel.Core.DTO.DocumentService;

namespace Host4Travel.BLL.Abstract
{
    public interface IDocumentService
    {
        List<DocumentListDto> GetAll();
        DocumentListDto GetById();
        void Add(DocumentAddDto model);
        void Update(DocumentUpdateDto model);
        void Delete(DocumentUpdateDto model);
    }
}