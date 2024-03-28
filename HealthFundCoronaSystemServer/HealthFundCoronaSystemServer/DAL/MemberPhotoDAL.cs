using HealthFundCoronaSystemServer.DTO;
using HealthFundCoronaSystemServer.Models1;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HealthFundCoronaSystemServer.DAL
{
    public static class MemberPhotoDAL
    {
        // Retrieves all member photos
        public static List<MemberPhotoDTO> GetAllMemberPhotos()
        {
            using (var dbContext = new HealthFundCoronaSystemDBContext())
            {
                return dbContext.MemberPhotos.Select(mp => new MemberPhotoDTO
                {
                    PhotoId = mp.PhotoId,
                    MemberId = mp.MemberId,
                    PhotoUrl = mp.PhotoUrl,
                }).ToList();
            }
        }

        // Retrieves a specific member photo by ID
        public static MemberPhotoDTO GetMemberPhotoById(int memberPhotoId)
        {
            using (var dbContext = new HealthFundCoronaSystemDBContext())
            {
                var result = dbContext.MemberPhotos.FirstOrDefault(mp => mp.PhotoId == memberPhotoId);
                if (result != null)
                {
                    return new MemberPhotoDTO
                    {
                        PhotoId = result.PhotoId,
                        MemberId = result.MemberId,
                        PhotoUrl = result.PhotoUrl
                    };
                }
                return null;
            }
        }

        // Adds a new member photo
        public static void AddMemberPhoto(MemberPhotoDTO memberPhoto)
        {
            using (var dbContext = new HealthFundCoronaSystemDBContext())
            {
                var newMemberPhoto = new MemberPhoto
                {
                    PhotoId = memberPhoto.PhotoId,
                    MemberId = memberPhoto.MemberId,
                    PhotoUrl = memberPhoto.PhotoUrl
                };
                dbContext.MemberPhotos.Add(newMemberPhoto);
                dbContext.SaveChanges();
            }
        }

        // Updates an existing member photo
        public static void UpdateMemberPhoto(MemberPhotoDTO memberPhoto)
        {
            using (var dbContext = new HealthFundCoronaSystemDBContext())
            {
                var existingMemberPhoto = dbContext.MemberPhotos.FirstOrDefault(mp => mp.PhotoId == memberPhoto.PhotoId);
                if (existingMemberPhoto != null)
                {
                    existingMemberPhoto.MemberId = memberPhoto.MemberId;
                    existingMemberPhoto.PhotoId = memberPhoto.PhotoId;
                    existingMemberPhoto.PhotoUrl = memberPhoto.PhotoUrl;
                    dbContext.SaveChanges();
                }
            }
        }

        // Deletes a member photo by ID
        public static void DeleteMemberPhoto(int memberPhotoId)
        {
            using (var dbContext = new HealthFundCoronaSystemDBContext())
            {
                var memberPhotoToDelete = dbContext.MemberPhotos.FirstOrDefault(mp => mp.PhotoId == memberPhotoId);
                if (memberPhotoToDelete != null)
                {
                    dbContext.MemberPhotos.Remove(memberPhotoToDelete);
                    dbContext.SaveChanges();
                }
            }
        }
        public static bool PhotoExistsForMember(int memberId)
        {
            using (HealthFundCoronaSystemDBContext dbContext = new HealthFundCoronaSystemDBContext())
            {
                return dbContext.MemberPhotos.Any(p => p.MemberId == memberId);
            }
        }

    }
}
