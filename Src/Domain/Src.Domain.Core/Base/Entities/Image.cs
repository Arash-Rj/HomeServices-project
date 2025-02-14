using Src.Domain.Core.Customer_Manager.Customer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Src.Domain.Core.Base.Entities
{
    public class Image
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public int? RequestId { get; set; }
        public AppRequest? Request { get; set; }
    }
}
