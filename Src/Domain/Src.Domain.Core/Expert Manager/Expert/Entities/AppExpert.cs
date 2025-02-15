using Src.Domain.Core.AAM.ManageUser.Entities;
using Src.Domain.Core.HomeServices_Manager.HomeServices.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Src.Domain.Core.Expert_Manager.Expert.Entities
{
    public class AppExpert: User
    {
        public string? Bioghraphy { get; set; }
        public string WorkPlaceAddress { get; set; }
        public List<Proposal> Proposals { get; set; }
        public List<FeedBack> FeedBacks { get; set; }
        public List<SubCategory> Specialties { get; set; }
    }
}
