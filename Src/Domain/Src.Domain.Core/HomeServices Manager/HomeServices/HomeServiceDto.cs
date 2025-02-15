using Src.Domain.Core.HomeServices_Manager.HomeServices.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Src.Domain.Core.HomeServices_Manager.HomeServices
{
    public class HomeServiceDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string SubCategoryName { get; set; }
        public float BasePrice { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public bool IsActive { get; set; }
    }
}
