using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IResult Add(Car car);
        IResult Update(Car car);
        IDataResult<List<Car>> GetAll();     
        IDataResult<List<Car>> GetByColorId(int colorId);
        IDataResult<List<Car>> GetByUnitePrice(decimal min, decimal max);
        IDataResult<Car> GetById(int carId);
    }
}
