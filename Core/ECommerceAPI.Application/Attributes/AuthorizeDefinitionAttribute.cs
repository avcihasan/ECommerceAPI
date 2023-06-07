﻿using ECommerceAPI.Application.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Attributes
{
    public class AuthorizeDefinitionAttribute:Attribute
    {
        public string Menu { get; set; }
        public ActionType ActionType { get; set; }
        public string Definition   { get; set; }
    }
}
