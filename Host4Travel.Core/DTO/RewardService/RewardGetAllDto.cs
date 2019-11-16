namespace Host4Travel.Core.DTO.RewardService
{
    public class RewardGetAllDto
    {
        public int RewardId { get; set; }
        public string RewardName { get; set; }
        public string RewardDescription { get; set; }
        public bool IsActive { get; set; }
    }
}