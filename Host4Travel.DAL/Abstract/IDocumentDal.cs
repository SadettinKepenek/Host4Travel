using System.Reflection.Metadata;
using Host4Travel.Core.DAL.Abstract;
using Document = Host4Travel.Entities.Concrete.Document;

namespace Host4Travel.DAL.Abstract
{
    public interface IDocumentDal:IEntityRepository<Document>
    {
        
    }
}