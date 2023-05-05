﻿using System.Collections.Generic;
using TenderSystem.Core.Utilities.Results;
using TenderSystem.Entities.Concrete;

namespace TenderSystem.Business.Abstract
{
    public interface ITenderStatusService
    {
        Result GetAll();
        Result GetById(int tenderStatusId);

    }
}