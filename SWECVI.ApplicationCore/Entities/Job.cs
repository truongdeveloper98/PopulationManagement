﻿namespace SWECVI.ApplicationCore.Entities
{
    public class Job : BaseEntity
    {
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
    }
}
