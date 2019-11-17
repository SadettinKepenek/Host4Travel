using Host4Travel.Core.DAL.Concrete.EntityFramework;
using Host4Travel.DAL.Abstract;
using Host4Travel.Entities.Concrete;
using Host4Travel.UI;

namespace Host4Travel.DAL.Concrete.EntityFramework
{
    public class EfPostCheckInRepository:EfEntityRepositoryBase<PostCheckIn,ApplicationDbContext>,IPostCheckInDal
    {
        
    }
}