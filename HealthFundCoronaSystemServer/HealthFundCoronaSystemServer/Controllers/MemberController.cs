using HealthFundCoronaSystemServer.DTO;
using HealthFundCoronaSystemServer.Store;
using Microsoft.AspNetCore.Mvc;

namespace HealthFundCoronaSystemServer.Controllers
{
    [ApiController]
    [Route("api/members")]
    public class MembersController : ControllerBase
    {
        private readonly MemberStore _memberStore;
        public MembersController(MemberStore memberStore)
        {
            _memberStore = memberStore;
        }
        [HttpGet] // Get all members
        public List<MemberDTO> GetAllMembers()
        {
            return _memberStore.GetAllMembers();
        }
        [HttpGet("{memberId}")] // Get specific member details
        public MemberDTO GetMemberById(int memberId)
        {
            return _memberStore.GetMemberById(memberId);
        }
        [HttpPost] // Add a new member
        public void AddMember( MemberDTO member)
        {
            _memberStore.AddMember(member);
        }

        [HttpPut]// Update existing member
        public void  UpdateMember(MemberDTO member)
        {
            _memberStore.UpdateMember(member);
        }

        [HttpDelete("{memberId}")] // Delete a member
        public void DeleteMember(int memberId)
        {
            _memberStore.DeleteMember(memberId);
        }
    }
}
