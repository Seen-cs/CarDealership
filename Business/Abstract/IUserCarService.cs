using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserCarService
    {
        IResult Add(UserCar userCar);
        IResult Update(UserCar userCar);
    }
}
