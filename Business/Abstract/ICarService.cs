using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IResult Add(Car car);
        IResult Update(Car car);
        IDataResult<Car> Get(int carId);
        IDataResult<List<CarDetailDto>> GetAll();     
        IDataResult<List<Car>> GetByColorId(int colorId);
        IDataResult<List<Car>> GetByUnitePrice(decimal min, decimal max);
        IDataResult<CarDetailDto> GetById(int carId);
    }
}
