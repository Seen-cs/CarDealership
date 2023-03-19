
using DataAccess.Concrete;
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
            
        }
    }
}
