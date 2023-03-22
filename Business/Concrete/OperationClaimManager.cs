using Business.Abstract;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class OperationClaimManager : IOperationClaimService
    {
        private IOperationClaimsDal _operationClaimsDal;
        public OperationClaimManager(IOperationClaimsDal operationClaimsDal)
        {
            _operationClaimsDal = operationClaimsDal;
        }

        public int GetOperationClaimById(string operationClaims)
        {
            return _operationClaimsDal.Get(p => p.Name == operationClaims).Id;
        }
    }
}
