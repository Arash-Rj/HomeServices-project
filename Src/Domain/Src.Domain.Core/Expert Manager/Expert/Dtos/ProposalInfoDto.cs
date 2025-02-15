using Src.Domain.Core.Expert_Manager.Expert.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Src.Domain.Core.Expert_Manager.Expert.Dtos
{
    public class ProposalInfoDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string? ExpertName { get; set; }
        public string? HomeServiceName { get; set; }
        public ProposalStatus Status { get; set; }
        public float Price { get; set; }
        [MaxLength(10)]
        public string DueDate { get; set; }
        [MaxLength(10)]
        public string ProposalDate { get; set; }
    }
}
