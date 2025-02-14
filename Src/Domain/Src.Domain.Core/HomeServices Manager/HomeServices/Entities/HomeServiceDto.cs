﻿using Src.Domain.Core.Base.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Src.Domain.Core.HomeServices_Manager.HomeServices.Entities
{
    public class HomeServiceDto
    {
        public string Title { get; set; }
        public SubCategory SubCategory { get; set; }
        public float BasePrice { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
    }
}
