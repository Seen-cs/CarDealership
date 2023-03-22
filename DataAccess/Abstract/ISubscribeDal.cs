using Core.DataAccess;
using Core.Entities.Concrete;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface ISubscribeDal : IEntityRepository<Subscribe>
    {
        List<SubscribeDetailDto> GetClaims();

    }

}
