﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWECVI.ApplicationCore.Entities
{
    public class Project : BaseEntity
    {
        public string ProjectId { get; set; } = default!;
        public string Name { get; set; } = default!;
        public string OperationId { get; set; } = default!;
        public string? Description { get; set; }
        public string Address { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;
        public string Email { get; set; } = default!;
        public int TownShipId { get; set; }
        public int ManagerId { get; set; }
        public DateTime DateLock { get; set; }
        public AppUser Manager { get; set; } = default!;
        public TownShip TownShip { get; set; } = default!;

    }
}
