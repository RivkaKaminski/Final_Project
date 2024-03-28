using HealthFundCoronaSystemServer.DTO;
using HealthFundCoronaSystemServer.Models1;
using System;
using System.Linq;

namespace HealthFundCoronaSystemServer.DAL
{
    public static class DailyActivePatientsDAL
    {
        public static List<DailyActivePatientsDTO> GetDailyActivePatientsForLastMonth()
        {
            using (HealthFundCoronaSystemDBContext dbContext = new HealthFundCoronaSystemDBContext())
            {
                DateTime lastMonth = DateTime.Today.AddMonths(-1);
                return dbContext.DailyActivatePatients.Where(d => d.Date >= lastMonth)
                                                     .Select(d => new DailyActivePatientsDTO
                                                     {
                                                         Date = d.Date,
                                                         ActivePatientsCount = d.ActivePatientCount
                                                     }).ToList();
            }
        }

        public static int GetActivePatientsCountForDate(DateTime date)
        {
            using (HealthFundCoronaSystemDBContext dbContext = new HealthFundCoronaSystemDBContext())
            {
                return dbContext.DailyActivatePatients.FirstOrDefault(d => d.Date == date)?.ActivePatientCount ?? 0;
            }
        }

        public static void AddOrUpdateActivePatientsCountForDate(DateTime date, int count)
        {
            using (HealthFundCoronaSystemDBContext dbContext = new HealthFundCoronaSystemDBContext())
            {
                DailyActivatePatient? existingRecord = dbContext.DailyActivatePatients.FirstOrDefault(d => d.Date == date);
                if (existingRecord != null)
                {
                    existingRecord.ActivePatientCount = count;
                }
                else
                {
                    dbContext.DailyActivatePatients.Add(new DailyActivatePatient { Date = date, ActivePatientCount = count });
                }
                dbContext.SaveChanges();
            }
        }
        public static void AddOrUpdateActivePatientCount(DateTime date, int increment)
        {
            using (var dbContext = new HealthFundCoronaSystemDBContext())
            {
                var record = dbContext.DailyActivatePatients.FirstOrDefault(d => d.Date == date);

                if (record != null)
                {
                    // Increment the count if the record exists
                    record.ActivePatientCount += increment;
                }
                else
                {
                    // Add a new record with count = 1 if it doesn't exist
                    dbContext.DailyActivatePatients.Add(new DailyActivatePatient
                    {
                        Date = date,
                        ActivePatientCount = increment
                    });
                }

                dbContext.SaveChanges();
            }
        }

    }
}
