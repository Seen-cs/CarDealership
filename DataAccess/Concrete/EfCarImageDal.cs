using Core.DataAccess.EntityFramework;
using DataAccess.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete
{
    public class EfCarImageDal:EfEntityRepositoryBase<CarImage, CarDealershipContext>, ICarImageDal
    {
    }
}
