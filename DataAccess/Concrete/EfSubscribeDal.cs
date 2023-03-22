using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete
{
    public class EfSubscribeDal : EfEntityRepositoryBase<Subscribe, CarDealershipContext>, ISubscribeDal
    {
        public List<SubscribeDetailDto> GetClaims()
        {
            using (var contex = new CarDealershipContext())
            {
                var result = from p in contex.Subscribes
                             join c in contex.Users
                             on p.SubUserId equals c.Id
                             
                             select new SubscribeDetailDto
                             {
                                 Id=p.Id,
                                 SubUser=c.LastName,
                                 SupUser=c.LastName
                                 
                             };
                return result.ToList();
            }
        }
    }
}
