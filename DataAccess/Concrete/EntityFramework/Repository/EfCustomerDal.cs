﻿using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework.Repository
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, ReCapProjectContext>, ICustomerDal
    {

    }
}