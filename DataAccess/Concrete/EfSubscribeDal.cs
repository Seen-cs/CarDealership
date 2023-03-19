using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.EntityFramework;
using Entities.Concrete;

namespace DataAccess.Concrete
{
    public class EfSubscribeDal : EfEntityRepositoryBase<Subscribe, CarDealershipContext>, ISubscribeDal
    {

    }
}
