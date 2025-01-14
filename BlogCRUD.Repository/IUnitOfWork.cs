﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogCRUD.Repository
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync();
    }
}
