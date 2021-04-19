﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using WebStore.Clients.Base;

namespace WebStore.Clients.Values
{
    public class ValuesClient: BaseClient
    {
        public ValuesClient(IConfiguration Configuration) : base(Configuration, "api/values") { }


    }
}
