﻿namespace NZWalks.Models.DTO.AddMethod
{
    public class Walk
    {
        public string Name { get; set; }
        public double Length { get; set; }
        public Guid RegionId { get; set; }
        public Guid WalkDificulty { get; set; }
    }
}
