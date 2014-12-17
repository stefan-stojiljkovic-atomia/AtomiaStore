﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Atomia.Store.AspNetMvc.Infrastructure
{
    public interface IThemeNamesProvider
    {
        IEnumerable<string> GetThemeNames();
    }
}
