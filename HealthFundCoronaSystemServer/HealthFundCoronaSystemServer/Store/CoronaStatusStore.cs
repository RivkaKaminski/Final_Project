using HealthFundCoronaSystemServer.DTO;
using HealthFundCoronaSystemServer.Controllers;
using HealthFundCoronaSystemServer.DAL;
namespace HealthFundCoronaSystemServer.Store
{
    public class CoronaStatusStore
    {
        // Adds or updates a member's corona status

        public  List<CoronaStatusDTO> GetActiveCoronaStatus()
        {
            return CoronaStatusDAL.GetActiveCoronaStatus();
        }
        public  void DeleteCoronaStatus(int coronaStatusId)
        {
            CoronaStatusDAL.DeleteCoronaStatus(coronaStatusId);
        }
        public  void UpdateCoronaStatus(CoronaStatusDTO coronaStatus)
        {
            CoronaStatusDAL.UpdateCoronaStatus(coronaStatus);

        }
        public  void AddCoronaStatus(CoronaStatusDTO coronaStatus)
        {
            CoronaStatusDAL.AddCoronaStatus(coronaStatus);
        }

        // Retrieves the corona status for a member
        public CoronaStatusDTO GetCoronaStatusForMember(int memberId)
        {
           return CoronaStatusDAL.GetCoronaStatusForMember(memberId);
        }
    }

}
