﻿using System;
using System.Collections.Generic;
using System.Text;
using DotVVM.Framework.Controls;

namespace DotVVM.SampleWeb.BL.Facades.Admin.Base
{
    public interface IListFacade<TDTO, TKey>
    {
        void FillDataSet(GridViewDataSet<TDTO> items);

        void Delete(TKey id);
    }
}
