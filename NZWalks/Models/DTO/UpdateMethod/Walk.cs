namespace NZWalks.Models.DTO.UpdateMethod
{
    public class Walk
    {
        public string Name { get; set; }
        public double Length { get; set; }
        public Guid RegionId { get; set; }
        public Guid WalkDificulty { get; set; }
    }
}
