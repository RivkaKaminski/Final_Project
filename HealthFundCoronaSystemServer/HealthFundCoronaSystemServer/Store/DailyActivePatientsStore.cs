using HealthFundCoronaSystemServer.DAL;
using HealthFundCoronaSystemServer.DTO;

namespace HealthFundCoronaSystemServer.Store
{
    public  class DailyActivePatientsStore
    {
        public  void AddOrUpdateActivePatientsCountForDate(DateTime date, int count)
        {
            DailyActivePatientsDAL.AddOrUpdateActivePatientsCountForDate(date, count);
        }
        public  int GetActivePatientsForLastMonth(DateTime date)
        {
            return DailyActivePatientsDAL.GetActivePatientsCountForDate(date);
        }
        public  int GetActivePatientsCountForDate(DateTime date)
        {
            return DailyActivePatientsDAL.GetActivePatientsCountForDate(date);
        }
    }
}
