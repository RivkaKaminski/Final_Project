using HealthFundCoronaSystemServer.DAL;
using HealthFundCoronaSystemServer.DTO;
using HealthFundCoronaSystemServer.Store;
using Microsoft.AspNetCore.Mvc;

namespace HealthFundCoronaSystemServer.Controllers
{
    [ApiController]
    [Route("api/dailyActivePatients")]
    public class DailyActivePatientsController : ControllerBase
    {
        private readonly DailyActivePatientsStore _dailyActivatePatientStore;

        public  DailyActivePatientsController(DailyActivePatientsStore dailyActivePatientsStore)
        {
            _dailyActivatePatientStore = dailyActivePatientsStore;
        }
        [HttpGet("GetActivePatientsForLastMonth{date}")]

        public int GetActivePatientsForLastMonth( DateTime date)
        {
            return _dailyActivatePatientStore.GetActivePatientsForLastMonth(date);
        }
        [HttpPost]

        public void AddOrUpdateActivePatientsCountForDate(DateTime date, int count)
        {
            _dailyActivatePatientStore.AddOrUpdateActivePatientsCountForDate(date, count);
        }
        [HttpGet("{date}")]
        public int GetActivePatientsCountForDate(DateTime date)
        {
           return _dailyActivatePatientStore.GetActivePatientsCountForDate(date);
        }
    }
}
