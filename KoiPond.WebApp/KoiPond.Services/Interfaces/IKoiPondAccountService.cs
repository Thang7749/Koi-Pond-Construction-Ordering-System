﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoiPond.Repositories.Entities;

namespace KoiPond.Services.Interfaces
{
    public interface IKoiPondAccountService
    {
        Task<List<AccountKoiPond>> AccountKoiPonds(); //ham lay du lieu
    }
}
