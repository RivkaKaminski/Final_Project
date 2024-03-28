using HealthFundCoronaSystemServer.DTO;
using HealthFundCoronaSystemServer.Models1;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HealthFundCoronaSystemServer.DAL
{
    public class MemberDAL
    {
        /// Retrieves all members from the database.
        /// A list of MemberDTO objects representing all members.
        public static List<MemberDTO> GetAllMembers()
        {
            using (HealthFundCoronaSystemDBContext dbContext = new HealthFundCoronaSystemDBContext())
            {
                return dbContext.Members.Select(m => new MemberDTO
                {
                    MemberId = m.MemberId,
                    FirstName = m.FirstName,
                    LastName = m.LastName,
                    IdentityCard = m.IdentityCard,
                    City = m.City,
                    Street = m.Street,
                    StreetNumber = m.StreetNumber,
                    DateOfBirth = m.DateOfBirth,
                    Telephone = m.Telephone,
                    Email = m.Email,
                    MobilePhone = m.MobilePhone
                }).ToList();
            }
        }

        /// Retrieves a member from the database by their ID.
        /// <param name="memberId">The ID of the member to retrieve.</param>
        /// <returns>A MemberDTO object representing the member.</returns>
        public static MemberDTO GetMemberById(int memberId)
        {
            using (HealthFundCoronaSystemDBContext dbContext = new HealthFundCoronaSystemDBContext())
            {
                Member? member = dbContext.Members.FirstOrDefault(m => m.MemberId == memberId);
                if (member != null)
                {
                    return new MemberDTO
                    {
                        MemberId = member.MemberId,
                        FirstName = member.FirstName,
                        LastName = member.LastName,
                        IdentityCard = member.IdentityCard,
                        City = member.City,
                        Street = member.Street,
                        StreetNumber = member.StreetNumber,
                        DateOfBirth = member.DateOfBirth,
                        Telephone = member.Telephone,
                        Email = member.Email,
                        MobilePhone = member.MobilePhone
                    };
                }
                return null;
            }
        }

        // Add methods for adding, updating, and deleting members from the database
        /// Adds a new member to the database.
        /// <param name="member">The MemberDTO object representing the new member.</param>
        public static void AddMember(MemberDTO member)
        {
            using (HealthFundCoronaSystemDBContext dbContext = new HealthFundCoronaSystemDBContext())
            {
                Member newMember = new Member
                {
                    FirstName = member.FirstName,
                    LastName = member.LastName,
                    IdentityCard = member.IdentityCard,
                    City = member.City,
                    Street = member.Street,
                    StreetNumber = member.StreetNumber,
                    DateOfBirth = member.DateOfBirth,
                    Telephone = member.Telephone,
                    Email = member.Email,
                    MobilePhone = member.MobilePhone
                };
                dbContext.Members.Add(newMember);
                dbContext.SaveChanges();
            }
        }
        public static  List<MemberDTO> GetMembersByCity(string city)
        {
            using (HealthFundCoronaSystemDBContext dbContext = new HealthFundCoronaSystemDBContext())
            {
                return dbContext.Members.Where(m => m.City == city)
                                        .Select(m => new MemberDTO
                                        {
                                            MemberId = m.MemberId,
                                            FirstName = m.FirstName,
                                            LastName = m.LastName,
                                            IdentityCard = m.IdentityCard,
                                            City = m.City,
                                            Street = m.Street,
                                            StreetNumber = m.StreetNumber,
                                            DateOfBirth = m.DateOfBirth,
                                            Telephone = m.Telephone,
                                            Email = m.Email,
                                            MobilePhone = m.MobilePhone
                                        }).ToList();
            }
        }
        /// Updates an existing member in the database.
        /// <param name="member">The MemberDTO object representing the updated member.</param>
        public static void UpdateMember(MemberDTO member)
        {
          
            using (HealthFundCoronaSystemDBContext dbContext = new HealthFundCoronaSystemDBContext())
            {
                Member? existingMember = dbContext.Members.FirstOrDefault(m => m.MemberId == member.MemberId);
                if (existingMember != null)
                {
                   
                    existingMember.FirstName = member.FirstName;
                    existingMember.LastName = member.LastName;
                    existingMember.IdentityCard = member.IdentityCard;
                    existingMember.City = member.City;
                    existingMember.Street = member.Street;
                    existingMember.StreetNumber = member.StreetNumber;
                    existingMember.DateOfBirth = member.DateOfBirth;
                    existingMember.Telephone = member.Telephone;
                    existingMember.Email = member.Email;
                    existingMember.MobilePhone = member.MobilePhone;

                    dbContext.SaveChanges();
                }
            }
        }

        /// Deletes a member from the database by their ID.
        /// <param name="memberId">The ID of the member to delete.</param>
        public static void DeleteMember(int memberId)
        {
            using (HealthFundCoronaSystemDBContext dbContext = new HealthFundCoronaSystemDBContext())
            {
                Member? memberToDelete = dbContext.Members.FirstOrDefault(m => m.MemberId == memberId);
                if (memberToDelete != null)
                {
                    CoronaStatus? coronaStatusToDelete = dbContext.CoronaStatuses.FirstOrDefault(m => m.MemberId == memberId);
                    Vaccination? vaccinationToDelete = dbContext.Vaccinations.FirstOrDefault(m => m.MemberId == memberId);
                    while (vaccinationToDelete != null)
                    {
                        dbContext.Vaccinations.Remove(vaccinationToDelete);
                        dbContext.SaveChanges();
                        vaccinationToDelete = dbContext.Vaccinations.FirstOrDefault(m => m.MemberId == memberId);
                    }
                    if (coronaStatusToDelete != null)
                    {
                        dbContext.CoronaStatuses.Remove(coronaStatusToDelete);
                        dbContext.SaveChanges();

                    }
                    dbContext.Members.Remove(memberToDelete);
                    dbContext.SaveChanges();
                }
            }
        }
    }
}
