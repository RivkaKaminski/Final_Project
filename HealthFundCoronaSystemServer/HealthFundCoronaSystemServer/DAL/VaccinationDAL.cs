using HealthFundCoronaSystemServer.DTO;
using HealthFundCoronaSystemServer.Models1;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HealthFundCoronaSystemServer.DAL
{
    public static class VaccinationDAL
    {
        public static List<VaccinationDTO> GetAllVaccinations()
        {
            using (HealthFundCoronaSystemDBContext dbContext = new HealthFundCoronaSystemDBContext())
            {
                return dbContext.Vaccinations.Select(v => new VaccinationDTO
                {
                    VaccinationId = v.VaccinationId,
                    MemberId = v.MemberId,
                    VaccineDate = v.VaccineDate,
                    VaccineManufacturer = v.VaccineManufactor
                }).ToList();
            }
        }

        public static void AddVaccination(VaccinationDTO vaccination)
        {
            using (HealthFundCoronaSystemDBContext dbContext = new HealthFundCoronaSystemDBContext())
            {
                Vaccination newVaccination = new Vaccination
                {
                    VaccinationId = vaccination.VaccinationId,
                  MemberId = vaccination.MemberId,
                    VaccineDate = vaccination.VaccineDate,
                    VaccineManufactor = vaccination.VaccineManufacturer
                };
                dbContext.Vaccinations.Add(newVaccination);
                dbContext.SaveChanges();
            }
        }

        public static void UpdateVaccination(VaccinationDTO vaccination)
        {
            using (HealthFundCoronaSystemDBContext dbContext = new HealthFundCoronaSystemDBContext())
            {
                Vaccination? existingVaccination = dbContext.Vaccinations.FirstOrDefault(v => v.VaccinationId == vaccination.VaccinationId);
                if (existingVaccination != null)
                {
                    existingVaccination.VaccinationId = vaccination.VaccinationId;
                    existingVaccination.MemberId = vaccination.MemberId;
                    existingVaccination.VaccineDate = vaccination.VaccineDate;
                    existingVaccination.VaccineManufactor = vaccination.VaccineManufacturer;
                    dbContext.SaveChanges();
                }
            }
        }

        public static void DeleteVaccination(int vaccinationId)
        {
            using (HealthFundCoronaSystemDBContext dbContext = new HealthFundCoronaSystemDBContext())
            {
                Vaccination? vaccinationToDelete = dbContext.Vaccinations.FirstOrDefault(v => v.VaccinationId == vaccinationId);
                if (vaccinationToDelete != null)
                {
                    dbContext.Vaccinations.Remove(vaccinationToDelete);
                    dbContext.SaveChanges();
                }
            }
        }

        public static List<VaccinationDTO> GetVaccinationsByManufacturer(string manufacturer)
        {
            using (HealthFundCoronaSystemDBContext dbContext = new HealthFundCoronaSystemDBContext())
            {
                return dbContext.Vaccinations.Where(v => v.VaccineManufactor == manufacturer)
                                            .Select(v => new VaccinationDTO
                                            {
                                                VaccinationId = v.VaccinationId,
                                                MemberId = v.MemberId,
                                                VaccineDate = v.VaccineDate,
                                                VaccineManufacturer = v.VaccineManufactor
                                            }).ToList();
            }
        }

        public static List<VaccinationDTO> GetVaccinationsByMemberId(int memberId)
        {
            using (HealthFundCoronaSystemDBContext dbContext = new HealthFundCoronaSystemDBContext())
            {
                return dbContext.Vaccinations.Where(v => v.MemberId == memberId)
                                            .Select(v => new VaccinationDTO
                                            {
                                                VaccinationId = v.VaccinationId,
                                                MemberId = v.MemberId,
                                                VaccineDate = v.VaccineDate,
                                                VaccineManufacturer = v.VaccineManufactor
                                            }).ToList();
            }
        }
    }
}
