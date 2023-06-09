﻿using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IBrandService
    {
        IResult Add(Brand brand);
        IResult Update(Brand brand);
        IDataResult<List<Brand>> GetAll();
        IDataResult<Brand> Get(string brandName);
        IDataResult<Brand> GetBrandById(int brandId);
       // IDataResult<List<Brand>> GetBrandName(string brandName);
    }
}
