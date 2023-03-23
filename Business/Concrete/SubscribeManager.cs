
using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class SubscribeManager:ISubscribeService
    {
        ISubscribeDal _subscribeDal;
        IUserService _userService;
        public SubscribeManager(ISubscribeDal subscribeDal, IUserService userService)
        {
            _subscribeDal = subscribeDal;
            _userService = userService;
        }

        public IResult Add(Subscribe subscribe)
        {
            _subscribeDal.Add(subscribe);
            return new SuccessResult();
        }

        public IDataResult<List<Subscribe>> GetAll()
        {
            return new SuccessDataResult<List<Subscribe>>(_subscribeDal.GetAll());
        }

        public IDataResult<List<SubscribeDetailDto>> GetClaims()
        {
            return new SuccessDataResult<List<SubscribeDetailDto>>(_subscribeDal.GetClaims());
        }

        public IResult Update(Subscribe subscribe)
        {
            _subscribeDal.Update(subscribe);
            return new SuccessResult();
        }


        public IDataResult<List<User>> GetAllSubUserBySupUserId(int supUserId)
        {
            List<User> result = new List<User>();
            if (_subscribeDal.GetAll(s => s.SupUserId == supUserId).Count > 0)
            {
                foreach (var sub in _subscribeDal.GetAll(s => s.SupUserId == supUserId))
                {
                    result.Add(_userService.GetById(sub.SubUserId).Data);
                }
            }
            return new SuccessDataResult<List<User>>(result);
        }

        public IResult Delete(Subscribe subscribe)
        {
            _subscribeDal.Delete(subscribe);
            return new SuccessResult();
        }

        public IDataResult<Subscribe> GetSubscribeBySupUserIdAndSubUserId(int supUserId, int subUserId)
        {
            return new SuccessDataResult<Subscribe>(_subscribeDal.Get(s => s.SubUserId == subUserId && s.SupUserId == supUserId));
        }
    }
}
