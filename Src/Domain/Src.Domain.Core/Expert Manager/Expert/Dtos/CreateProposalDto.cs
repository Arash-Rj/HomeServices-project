using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Src.Domain.Core.Expert_Manager.Expert.Dtos
{
    public class CreateProposalDto
    {
        public string Description { get; set; }
        public float Price { get; set; }
        [MaxLength(10)]
        public string DueDate { get; set; }
        public int RequestId { get; set; }
        public int ExpertId { get; set; }
    }
}
