using HealthFundCoronaSystemServer.DTO;
using HealthFundCoronaSystemServer.Store;
using Microsoft.AspNetCore.Mvc;

namespace HealthFundCoronaSystemServer.Controllers
{
    [ApiController]
    [Route("api/vaccinations")]
    public  class VaccinationsController : ControllerBase
    {
        private VaccinationStore _vaccinationStore;

        public VaccinationsController(VaccinationStore vaccinationStore)
        {
            _vaccinationStore = vaccinationStore;
        }
        [HttpPost]
        public void AddVaccination(VaccinationDTO vaccination)
        {
            _vaccinationStore.AddVaccination(vaccination);
        }
        [HttpPut] 
        public void UpdateVaccination(VaccinationDTO vaccination)
        {
            _vaccinationStore.UpdateVaccination(vaccination);
        }

       
        [HttpGet]
        public  List<VaccinationDTO> GetAllVaccinations()
        {
            return _vaccinationStore.GetAllVaccinations();
        }
        [HttpDelete("{vaccinationId}")]

        public void DeleteVaccination(int vaccinationId)
        {
            _vaccinationStore.DeleteVaccination(vaccinationId);
        }

        [HttpGet("{memberId}")]
        public IEnumerable<VaccinationDTO> GetVaccinationsByMemberId(int memberId)
        {
            return _vaccinationStore.GetVaccinationsByMemberId(memberId);
        }
        [HttpGet("GetVaccinationsByManufacturer{manufacturer}")]
        public IEnumerable<VaccinationDTO> GetVaccinationsByManufacturer(string manufacturer)
        {
            return _vaccinationStore.GetVaccinationsByManufacturer(manufacturer);
        }

    }

}
