﻿using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ModelManager : IModelService
    {
        IModelDal _modelDal;
        public ModelManager(IModelDal modelDal)
        {
            _modelDal = modelDal;
        }
        public IResult Add(Model model)
        {
            _modelDal.Add(model);
            return new SuccessResult();

        }

        public IDataResult<List<Model>> GetAll()
        {
            return new SuccessDataResult<List<Model>>(_modelDal.GetAll());
        }

        public int GetModelById(string modelName)
        {
            return _modelDal.Get(p => p.Name == modelName).Id;
        }

        public IResult Update(Model model)
        {
            _modelDal.Update(model);
            return new SuccessResult();

        }
    }
}
