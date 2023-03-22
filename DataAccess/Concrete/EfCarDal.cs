using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System.Linq;

using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarDealershipContext>, ICarDal
    {
        public List<CarDetailDto> GetClaims()
        {
            using (var contex = new CarDealershipContext())
            {
                var result = from carss in contex.Cars
                            join brand in contex.Brands
                            on carss.BrandId equals brand.Id
                            join color in contex.Colors
                            on carss.ColorId equals color.Id
                            join model in contex.Models
                            on carss.ModelId equals model.Id
                            join user in contex.Users
                            on carss.UserId equals user.Id
                            select new CarDetailDto
                            {
                                CarId = carss.Id,
                                color = color.Name,
                                brand=brand.Name,
                                model=model.Name,
                                userName=user.FirstName,
                                km=carss.Km,
                                price=carss.Price,
                                year=carss.Year,
                                description=carss.Description


                            };
                return result.ToList();
            }
        }
    }
}
