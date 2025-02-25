using Src.Domain.Core.AAM.ManageUser.Enums;
using Src.Domain.Core.Expert_Manager.Expert.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Src.Domain.Core.Expert_Manager.Expert.Dtos
{
    public class ExpertDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public ProvinceEnum Province { get; set; }
        public int ProposalCount { get; set; }
        public string ImagePath { get; set; }
    }
}
