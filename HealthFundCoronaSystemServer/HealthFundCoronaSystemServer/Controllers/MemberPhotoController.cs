using HealthFundCoronaSystemServer.DTO;
using HealthFundCoronaSystemServer.Store;
using Microsoft.AspNetCore.Mvc;

namespace HealthFundCoronaSystemServer.Controllers
{

    [ApiController]
    [Route("api/memberPhoto")]
    public class MemberPhotoController : ControllerBase
    {
        private readonly MemberPhotoStore _memberPhotoStore;

        public MemberPhotoController(MemberPhotoStore memberPhotoStore)
        {
            _memberPhotoStore = memberPhotoStore;
        }

        [HttpGet] // Get all members
        public List<MemberPhotoDTO> GetAllMemberPhotos()
        {
            return _memberPhotoStore.GetAllMemberPhotos();
        }
        [HttpPut]// Update existing member

        public void UpdateMemberPhoto(MemberPhotoDTO memberPhoto)
        {
            _memberPhotoStore.UpdateMemberPhoto(memberPhoto);
        }

        [HttpPost]
        public ActionResult AddMemberPhoto(MemberPhotoDTO photo)
        {
            _memberPhotoStore.AddMemberPhoto(photo);
            return Ok();
        }
        [HttpGet("{photoId}")]
        public ActionResult<MemberPhotoDTO> GetMemberPhotoById(int photoId)
        {
            var photo = _memberPhotoStore.GetMemberPhotoById(photoId);
            if (photo == null) return NotFound();
            return photo;
        }
        [HttpGet("PhotoExistsForMember {memberId}")]
        public  bool PhotoExistsForMember(int memberId)
        {
            return _memberPhotoStore.PhotoExistsForMember(memberId);
        }
        [HttpDelete("{photoId}")] 

        public ActionResult DeleteMemberPhoto(int photoId)
        {
            _memberPhotoStore.DeleteMemberPhoto(photoId);
            return NoContent(); 
        }
    }
}
