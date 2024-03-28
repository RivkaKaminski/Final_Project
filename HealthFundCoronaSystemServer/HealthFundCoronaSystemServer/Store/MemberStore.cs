using HealthFundCoronaSystemServer.DTO;
using HealthFundCoronaSystemServer.Controllers;
using HealthFundCoronaSystemServer.DAL;

namespace HealthFundCoronaSystemServer.Store
{
    public class MemberStore
    {
        MemberDTO member;
        // Retrieves a list of all members with their basic details
        public List<MemberDTO> GetAllMembers()
        {
            return MemberDAL.GetAllMembers();
        }

        // Retrieves detailed information for a specific member by ID, including corona details
        public MemberDTO GetMemberById(int memberId)
        {
            return MemberDAL.GetMemberById(memberId);
        }

        // Adds a new member to the health fund
        public void AddMember(MemberDTO member)
        {
            MemberDAL.AddMember(member);
        }

        // Updates existing member details
        public void UpdateMember(MemberDTO member)
        {
            MemberDAL.UpdateMember(member);
        }

        // Deletes a member from the health fund
        public void DeleteMember(int memberId)
        {
            MemberDAL.DeleteMember(memberId);
        }
    }

}
