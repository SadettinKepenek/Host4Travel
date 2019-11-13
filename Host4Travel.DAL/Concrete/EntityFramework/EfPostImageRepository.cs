using Host4Travel.Core.DAL.EntityFramework;
using Host4Travel.DAL.Abstract;
using Host4Travel.UI;

namespace Host4Travel.DAL.Concrete.EntityFramework
{
    public class EfPostImageRepository:EfEntityRepositoryBase<PostImage,ApplicationDbContext>,IPostImageDal
    {
        
    }
}