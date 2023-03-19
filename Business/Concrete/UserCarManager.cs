using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserCarManager : IUserCarService
    {
        IUserCarDal _userDal;
        public UserCarManager(IUserCarDal userCar)
        {
            _userDal = userCar;
        }
        public IResult Add(UserCar userCar)
        {
            _userDal.Add(userCar);
            return new SuccessResult();

        }

        public IResult Update(UserCar userCar)
        {
            _userDal.Update(userCar);
            return new SuccessResult();

        }
    }
}
