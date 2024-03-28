namespace HealthFundCoronaSystemServer.DTO
{
    public class MemberDTO
    {
        public int MemberId { get; set; }
        public string? FirstName { get; set; }
        public string LastName { get; set; } = null!;
        public string IdentityCard { get; set; } = null!;
        public string? City { get; set; }
        public string? Street { get; set; }
        public int? StreetNumber { get; set; }
        //public AddressDTO? Address { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Telephone { get; set; }
        public string? Email { get; set; }
        public string? MobilePhone { get; set; }
    }

    public class AddressDTO
    {
        public string? City { get; set; }
        public string? Street { get; set; }
        public int StreetNumber { get; set; }
    }
}
