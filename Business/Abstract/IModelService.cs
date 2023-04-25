using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IModelService
    {
        IResult Add(Model model);
        IResult Update(Model model);
        IDataResult<Model> GetModelById(int modelId);
        IDataResult<Model> Get(string modelName);
        IDataResult<List<Model>> GetAll();


    }
}
