﻿using Src.Domain.Core.AAM.ManageUser.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Src.Domain.Core.AAM.ManageUser.Entities
{
    public class UserUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public ProvinceEnum Province { get; set; }
        public bool IsActive { get; set; }
        public string? CardNumber { get; set; }

        public string? Bioghraphy { get; set; }
        public string WorkPlaceAddress { get; set; }

        public string? Address { get; set; }
        public RoleEnum Role { get; set; }
    }
}
