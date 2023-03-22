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
                var result = from car in contex.Cars
                            join brand in contex.Brands
                            on car.BrandId equals brand.Id
                            join color in contex.Colors
                            on car.ColorId equals color.Id
                            join model in contex.Models
                            on car.ModelId equals model.Id
                            join user in contex.Users
                            on car.UserId equals user.Id
                            select new CarDetailDto
                            {
                                CarId = car.Id,
                                Color = color.Name,
                                Brand=brand.Name,
                                Model=model.Name,
                                Km=car.Km,
                                Price=car.Price,
                                Year=car.Year,
                                Description=car.Description


                            };
                return result.ToList();
            }
        }
    }
}
