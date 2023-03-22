using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ISubscribeService
    {
        IResult Add(Subscribe subscribe);
        IResult Update(Subscribe subscribe);
        IDataResult<List<Subscribe>> GetAll();
        IDataResult<List<SubscribeDetailDto>> GetClaims();
        IDataResult<List<User>> GetAllSubUserBySupUserId(int supUserId); 
    }
}
