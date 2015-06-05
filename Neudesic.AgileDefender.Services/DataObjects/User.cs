﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Neudesic.AgileDefender.Services.DataObjects
{
    public class User : BaseClass
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}