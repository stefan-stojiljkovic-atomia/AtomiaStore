﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Atomia.Store.Core;
using System.Web;
using Atomia.Store.AspNetMvc.Helpers;

namespace Atomia.Store.Fakes.Adapters
{
    public class FakeRootResellerIdentifierProvider : IResellerIdentifierProvider
    {
        public ResellerIdentifier GetResellerIdentifier()
        {
            return new ResellerIdentifier
            {
                AccountHash = "184ec886dc90d2c1b5e50b6afe80db01",
                BaseUrl = BaseUriHelper.GetBaseUriString()
            };
        }


        public void SetResellerIdentifier(ResellerIdentifier identifier)
        {
            
        }
    }
}
