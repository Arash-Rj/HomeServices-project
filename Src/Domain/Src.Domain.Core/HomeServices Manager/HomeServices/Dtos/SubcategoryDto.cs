using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Src.Domain.Core.HomeServices_Manager.HomeServices.Dtos
{
    public class SubcategoryDto
    {
       public int Id { get; set; }
       public string Name { get; set; }
        public string CategoryName { get; set; }
        public string ImagePath { get; set; }
    }
}
