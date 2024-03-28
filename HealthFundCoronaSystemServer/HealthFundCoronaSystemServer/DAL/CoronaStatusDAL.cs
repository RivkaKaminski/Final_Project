using HealthFundCoronaSystemServer.DTO;
using HealthFundCoronaSystemServer.Models1;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Linq.Expressions;

namespace HealthFundCoronaSystemServer.DAL
{
    public static class CoronaStatusDAL
    {
        public static CoronaStatusDTO GetCoronaStatusForMember(int memberId)//לשנות לסטטוס אידי
        {
            try
            {
                using (HealthFundCoronaSystemDBContext dbContext = new HealthFundCoronaSystemDBContext())
                {
                    CoronaStatus? coronaStatus = dbContext.CoronaStatuses.FirstOrDefault(c => c.MemberId == memberId);
                    if (coronaStatus != null)
                    {
                        return new CoronaStatusDTO
                        {
                            CoronaStatusId = coronaStatus.CoronaStatusId,
                            MemberId = coronaStatus.MemberId,
                            PositiveResultDate = coronaStatus.PositiveResultDate,
                            RecoveryDate = coronaStatus.RecoveryDate
                        };
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to retrieve CoronaStatus for member {memberId}", ex);

            }

        }
        public static void AddOrUpdateCoronaStatus(CoronaStatusDTO coronaStatus)
        {
            using (var dbContext = new HealthFundCoronaSystemDBContext())
            {
                var existingCoronaStatus = dbContext.CoronaStatuses
                    .FirstOrDefault(c => c.MemberId == coronaStatus.MemberId);

                if (existingCoronaStatus != null)
                {
                    existingCoronaStatus.PositiveResultDate = coronaStatus.PositiveResultDate;
                    existingCoronaStatus.RecoveryDate = coronaStatus.RecoveryDate;
                }
                else
                {
                    dbContext.CoronaStatuses.Add(new CoronaStatus
                    {
                        MemberId = coronaStatus.MemberId,
                        PositiveResultDate = coronaStatus.PositiveResultDate,
                        RecoveryDate = coronaStatus.RecoveryDate
                    });
                }

                dbContext.SaveChanges();

                //Update the Daily Active Patients count based on the new or updated Corona Status
                UpdateDailyActivePatientsCount(coronaStatus.PositiveResultDate, coronaStatus.RecoveryDate);
            }
        }
        private static void UpdateDailyActivePatientsCount(DateTime? positiveResultDate, DateTime? recoveryDate)
        {
            if (positiveResultDate.HasValue && recoveryDate.HasValue)
            {
                var startDate = positiveResultDate.Value;
                var endDate = recoveryDate.Value.AddDays(-1); // Exclude the recovery date

                for (var date = startDate; date <= endDate; date = date.AddDays(1))
                {
                    DailyActivePatientsDAL.AddOrUpdateActivePatientCount(date, 1);
                }
            }
        }

        public static void AddCoronaStatus(CoronaStatusDTO coronaStatus)
        {
            try
            {
                using (HealthFundCoronaSystemDBContext dbContext = new HealthFundCoronaSystemDBContext())
                {
                    CoronaStatus newCoronaStatus = new CoronaStatus
                    {
                        MemberId = coronaStatus.MemberId,
                        PositiveResultDate = coronaStatus.PositiveResultDate,
                        RecoveryDate = coronaStatus.RecoveryDate
                    };
                    dbContext.CoronaStatuses.Add(newCoronaStatus);
                    dbContext.SaveChanges();
                }
            }catch (Exception ex)
            {
                throw new Exception("Failed to add new CoronaStatus.", ex);
            }
        }

        public static void UpdateCoronaStatus(CoronaStatusDTO coronaStatus)
        {
            using (HealthFundCoronaSystemDBContext dbContext = new HealthFundCoronaSystemDBContext())
            {
                CoronaStatus? existingCoronaStatus = dbContext.CoronaStatuses.FirstOrDefault(c => c.CoronaStatusId == coronaStatus.CoronaStatusId);
                if (existingCoronaStatus != null)
                {
                    existingCoronaStatus.MemberId = coronaStatus.MemberId;
                    existingCoronaStatus.PositiveResultDate = coronaStatus.PositiveResultDate;
                    existingCoronaStatus.RecoveryDate = coronaStatus.RecoveryDate;
                    dbContext.SaveChanges();
                }
            }
        }

        public static void DeleteCoronaStatus(int coronaStatusId)
        {
            using (HealthFundCoronaSystemDBContext dbContext = new HealthFundCoronaSystemDBContext())
            {
                CoronaStatus? coronaStatusToDelete = dbContext.CoronaStatuses.FirstOrDefault(c => c.CoronaStatusId == coronaStatusId);
                if (coronaStatusToDelete != null)
                {
                    dbContext.CoronaStatuses.Remove(coronaStatusToDelete);
                    dbContext.SaveChanges();
                }
            }
        }

        public static List<CoronaStatusDTO> GetActiveCoronaStatus()
        {
            using (HealthFundCoronaSystemDBContext dbContext = new HealthFundCoronaSystemDBContext())
            {
                DateTime currentDate = DateTime.Today;
                return dbContext.CoronaStatuses.Where(c => c.PositiveResultDate <= currentDate && c.RecoveryDate > currentDate)
                                             .Select(c => new CoronaStatusDTO
                                             {
                                                 CoronaStatusId = c.CoronaStatusId,
                                                 MemberId = c.MemberId,
                                                 PositiveResultDate = c.PositiveResultDate,
                                                 RecoveryDate = c.RecoveryDate
                                             }).ToList();
            }
        }
        // Add specific methods as needed for CoronaStatusDAL
    }
}
