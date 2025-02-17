using Src.Domain.Core.Base.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Src.Domain.Core.HomeServices_Manager.HomeServices.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<SubCategory> SubCategories { get; set; }
        public string ImagePath { get; set; }
    }
}
