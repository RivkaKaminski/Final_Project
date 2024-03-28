////using System;
////using System.Collections.Generic;

////namespace HealthFundCoronaSystemServer.Models
////{
////    public partial class Member
////    {
////        public Member()
////        {
////            CoronaStatuses = new HashSet<CoronaStatus>();
////            MemberPhotos = new HashSet<MemberPhoto>();
////            Vaccinations = new HashSet<Vaccination>();
////        }

////        public int MemberId { get; set; }
////        public string? FirstName { get; set; }
////        public string LastName { get; set; } = null!;
////        public string IdentityCard { get; set; } = null!;
////        public string? City { get; set; }
////        public string? Street { get; set; }
////        public int? StreetNumber { get; set; }
////        public DateTime? DateOfBirth { get; set; }
////        public string? Telephone { get; set; }
////        public string? Email { get; set; }
////        public string? MobilePhone { get; set; }

//        public virtual ICollection<CoronaStatus> CoronaStatuses { get; set; }
//        public virtual ICollection<MemberPhoto> MemberPhotos { get; set; }
//        public virtual ICollection<Vaccination> Vaccinations { get; set; }
//    }
//}
