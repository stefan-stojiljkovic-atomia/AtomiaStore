﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Atomia.Store.AspNetMvc.Infrastructure;

namespace Atomia.Store.Services.Fakes
{
    public class FakeThemeNamesProvider : IThemeNamesProvider
    {
        public IEnumerable<string> GetThemeNames()
        {
            return new List<string> { "Bloop" };
        }
    }
}
