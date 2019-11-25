﻿using Host4Travel.Core.DAL.Abstract;
using Host4Travel.Core.DAL.Concrete.EntityFramework;
using Host4Travel.Entities.Concrete;
using Host4Travel.UI;

namespace Host4Travel.DAL.Abstract
{
    public interface IDocumentTypeDal:IEntityRepository<DocumentType>
    {
        
    }
}