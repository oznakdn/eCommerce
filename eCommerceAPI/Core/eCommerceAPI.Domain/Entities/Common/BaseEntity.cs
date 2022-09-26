﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceAPI.Domain.Entities.Common
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public virtual DateTime CreatedDate { get; set; }
    }
}
