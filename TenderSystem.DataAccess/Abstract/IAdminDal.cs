﻿using TenderSystem.Core.DataAccess;
using TenderSystem.Entities.Concrete;

namespace TenderSystem.DataAccess.Abstract
{
    public interface IAdminDal : IEntityRepository<Admin>
    {
    }
}