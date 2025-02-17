using Src.Domain.Core.Base.Entities;
using Src.Domain.Core.Expert_Manager.Expert.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Src.Domain.Core.HomeServices_Manager.HomeServices.Entities
{
    public class SubCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public List<AppExpert> AppExperts { get; set; }
        public List<HomeService> HomeServices { get; set; }
        public string? ImagePath { get; set; }
    }
}
