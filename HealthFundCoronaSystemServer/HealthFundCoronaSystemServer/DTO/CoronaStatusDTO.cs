namespace HealthFundCoronaSystemServer.DTO
{
    public class CoronaStatusDTO
    {
        public int CoronaStatusId { get; set; }
        public int? MemberId { get; set; }
        public DateTime? PositiveResultDate { get; set; }
        public DateTime? RecoveryDate { get; set; }
    }

}
