﻿using Src.Domain.Core.Base.Entities;
using Src.Domain.Core.Customer_Manager.Customer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Src.Domain.Core.HomeServices_Manager.HomeServices.Entities
{
    public class HomeService
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int SubCategoryId { get; set; }
        public SubCategory SubCategory { get; set; }
        public string ImagePath { get; set; }
        public int  Views { get; set; }
        public float BasePrice { get; set; }
        public bool IsActive { get; set; }
        public List<AppRequest> Requests { get; set; }
    }
}
