﻿using System.Collections.Generic;
using Host4Travel.Core.DTO.DocumentTypeDtos;

namespace Host4Travel.BLL.Abstract
{
    public interface IDocumentTypeService
    {
        List<DocumentTypeListDto> GetAll();
        DocumentTypeListDto GetById(int id);
        void Add(DocumentTypeAddDto model);
        void Update(DocumentTypeUpdateDto model);
        void Delete(DocumentTypeDeleteDto model);
    }
}