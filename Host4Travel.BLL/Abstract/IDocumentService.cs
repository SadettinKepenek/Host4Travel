﻿using System;
using System.Collections.Generic;
using Host4Travel.Core.DTO.DocumentService;

namespace Host4Travel.BLL.Abstract
{
    public interface IDocumentService
    {
        List<DocumentListDto> GetAll();
        DocumentListDto GetById(Guid id);
        void Add(DocumentAddDto model);
        void Update(DocumentUpdateDto model);
        void Delete(DocumentDeleteDto model);
    }
}