using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Customer.DAL.Repositories
{
   public class BaseManager<TEntity> : Repository<TEntity> where TEntity : class
    {
        public BaseManager(DbContext context) : base(context)
        {

        }
    }
}
