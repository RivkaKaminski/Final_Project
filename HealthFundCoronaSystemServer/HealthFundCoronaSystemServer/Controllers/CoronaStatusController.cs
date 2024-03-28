using HealthFundCoronaSystemServer.DTO;
using HealthFundCoronaSystemServer.Store;
using Microsoft.AspNetCore.Mvc;

namespace HealthFundCoronaSystemServer.Controllers
{
    [ApiController]
    [Route("api/coronastatus")]
    public class CoronaStatusController : ControllerBase
    {
        private readonly CoronaStatusStore _coronaStatusStore;

        public CoronaStatusController(CoronaStatusStore coronaStatusStore)
        {
            _coronaStatusStore = coronaStatusStore;
        }
        [HttpGet("{memberId}")]

        public CoronaStatusDTO GetCoronaStatusForMember(int memberId)
        {
            return _coronaStatusStore.GetCoronaStatusForMember(memberId);
        }

        [HttpGet]
        public  List<CoronaStatusDTO> GetActiveCoronaStatus()
        {
            return _coronaStatusStore.GetActiveCoronaStatus();
        }
        [HttpDelete("{coronaStatusId}")]
        public  void DeleteCoronaStatus(int coronaStatusId)
        {
            _coronaStatusStore.DeleteCoronaStatus(coronaStatusId);
        }
        [HttpPut]
        public void UpdateCoronaStatus(CoronaStatusDTO coronaStatus)
        {
            _coronaStatusStore.UpdateCoronaStatus(coronaStatus);
        }
        [HttpPost]
        public void AddCoronaStatus(CoronaStatusDTO coronaStatus)
        {
            _coronaStatusStore.AddCoronaStatus(coronaStatus);
        }
    }
}
