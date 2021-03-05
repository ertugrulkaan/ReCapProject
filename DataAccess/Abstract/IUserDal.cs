using Core.DataAccess;
using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        // BU Bir DAL interface'idir. USER

        List<OperationClaim> GetClaims(User user);
    }
}
