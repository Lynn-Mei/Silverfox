﻿using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silverfox
{
    public interface IViewMaker
    {
        public IView Create();
    }
}
