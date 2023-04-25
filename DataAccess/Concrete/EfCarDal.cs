using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System.Linq;

using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;

namespace DataAccess.Concrete
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarDealershipContext>, ICarDal
    {
        public List<CarDetailDto> GetAllClaims(Expression<Func<Car, bool>> filter = null)
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
                                 Brand = brand.Name,
                                 Color = color.Name,
                                 Description = car.Description,
                                 Km = car.Km,
                                 Model = model.Name,
                                 Price = car.Price,
                                 Year = car.Year,
                                 UserName = user.FirstName


                            };
                return result.ToList();
            }
        }

        public CarDetailDto GetClaims(Expression<Func<CarDetailDto, bool>> filter)
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
                                 Brand = brand.Name,
                                 Color = color.Name,
                                 Description = car.Description,
                                 Km = car.Km,
                                 Model = model.Name,
                                 Price = car.Price,
                                 Year = car.Year,
                                 UserName = user.FirstName


                             };
                return result.SingleOrDefault(filter);
            }
        }

       
    }
}
