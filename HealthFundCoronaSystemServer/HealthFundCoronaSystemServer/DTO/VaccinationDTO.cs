namespace HealthFundCoronaSystemServer.DTO
{
    public class VaccinationDTO
    {
        public int VaccinationId { get; set; }
        public int? MemberId { get; set; }
        public DateTime? VaccineDate { get; set; }
        public string? VaccineManufacturer { get; set; }
    }
}
