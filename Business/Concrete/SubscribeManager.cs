
using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class SubscribeManager:ISubscribeService
    {
        ISubscribeDal _subscribeDal;
        public SubscribeManager(ISubscribeDal subscribeDal)
        {
            _subscribeDal = subscribeDal;
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

        public IResult Update(Subscribe subscribe)
        {
            _subscribeDal.Update(subscribe);
            return new SuccessResult();
        }
    }
}
