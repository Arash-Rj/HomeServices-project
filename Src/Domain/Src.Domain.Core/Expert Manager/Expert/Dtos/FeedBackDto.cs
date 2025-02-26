using Src.Domain.Core.Expert_Manager.Expert.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Src.Domain.Core.Expert_Manager.Expert.Dtos
{
    public class FeedBackDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string CustomerName { get; set; }
        public string ExpertName { get; set; }
        public FeedBackStatus Status { get; set; }
        public int Score { get; set; }
    }
}
