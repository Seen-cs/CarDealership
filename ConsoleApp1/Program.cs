
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
            IAuthService authService;
            EfCarDal carDal = new EfCarDal();
            foreach (var item in carDal.GetAll())
            {
                Console.WriteLine(item.Description);
            }
            UserForRegisterDto user = new UserForRegisterDto();

           // authService.Register(user, user.Password);
            //AuthManager authManager =new AuthManager(new UserManager(new EfUserDal),new JwtHelper(IConfiguration))
            
            UserCar userCar = new UserCar();
            userCar.CarId = 1;
            userCar.Stock = 100;
            userCar.UserId = 1;
          //  userCarManager.Add(userCar);
        }
    }
}
