﻿using InvestmentMaster.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentMaster.WPFUI.ViewModels.Abstract
{
    public interface IBaseViewModel
    {
        List<Fund> Funds { get; set; }

    }
}
