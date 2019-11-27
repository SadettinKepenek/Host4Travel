using System;
using System.Collections.Generic;
using Host4Travel.Core.DTO.DocumentDtos;

namespace Host4Travel.BLL.Abstract
{
    public interface IDocumentService
    {
        List<DocumentDetailDto> GetAll();
        DocumentDetailDto GetById(Guid id);
        void Add(DocumentAddDto model);
        void Update(DocumentUpdateDto model);
        void Delete(DocumentDeleteDto model);
    }
}