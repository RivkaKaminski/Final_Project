using HealthFundCoronaSystemServer.DAL;
using HealthFundCoronaSystemServer.DTO;

namespace HealthFundCoronaSystemServer.Store
{
    public  class MemberPhotoStore
    {
        public  List<MemberPhotoDTO> GetAllMemberPhotos()
        {
          return  MemberPhotoDAL.GetAllMemberPhotos();
        }
        public  MemberPhotoDTO GetMemberPhotoById(int memberPhotoId)
        {
            return MemberPhotoDAL.GetMemberPhotoById(memberPhotoId);
        }
        public  bool PhotoExistsForMember(int memberId)
        {
            return MemberPhotoDAL.PhotoExistsForMember(memberId);

        }
        public  void UpdateMemberPhoto(MemberPhotoDTO memberPhoto)
        {
            MemberPhotoDAL.UpdateMemberPhoto(memberPhoto);
        }

        public  void AddMemberPhoto(MemberPhotoDTO photo)
        {
            MemberPhotoDAL.AddMemberPhoto(photo);
        }
        
        
        public  void DeleteMemberPhoto(int photoId)
        {
            MemberPhotoDAL.DeleteMemberPhoto(photoId);
        }

    }
}

