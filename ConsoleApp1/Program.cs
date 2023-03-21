
using Business.Abstract;
using Business.Concrete;
using Castle.Core.Configuration;
using Core.Entities.Concrete;
using Core.Utilities.Security.Jwt;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;
using Entities.DTOs;
using System;

namespace ConsoleApp1
{
    public class Program
    {
        static void Main(string[] args)
        {
            
            EfCarDal carDal = new EfCarDal();
            foreach (var item in carDal.GetAll())
            {
                Console.WriteLine(item.Description);
            }
            UserForRegisterDto user = new UserForRegisterDto();

            // authService.Register(user, user.Password);
            //AuthManager authManager =new AuthManager(new UserManager(new EfUserDal),new JwtHelper(IConfiguration))


            //  userCarManager.Add(userCar);

            //mail servisi denemesi

            ICarService CarService = new CarManager(new EfCarDal(), new SubscribeManager(new EfSubscribeDal()),new UserManager((new EfUserDal())));


            CarService.Add(new Car
            {
                BrandId = 1,
                ColorId = 2,
                Km = "20000",
                Price = 80100,
                ModelId = 1,
                UserId = 1,
                Year = "2018",
                Description = "Egea"

            });



        }
    }
}
