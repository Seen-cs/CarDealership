using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.EntityFramework;

namespace DataAccess.Concrete
{
    public class EfUserDal : EfEntityRepositoryBase<User, CarDealershipContext>, IUserDal
    {

    }
}
