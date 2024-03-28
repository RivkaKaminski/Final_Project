using HealthFundCoronaSystemServer.DAL;
using HealthFundCoronaSystemServer.DTO;
using HealthFundCoronaSystemServer.Controllers;


namespace HealthFundCoronaSystemServer.Store
{
    public class VaccinationStore
    {
       
        public  List<VaccinationDTO> GetAllVaccinations()
        {
          return VaccinationDAL.GetAllVaccinations();
        }
        // Adds a vaccination record.
        public  void AddVaccination(VaccinationDTO vaccination)
        {
            VaccinationDAL.AddVaccination(vaccination);
        }

        // Updates a vaccination record.
        public  void UpdateVaccination(VaccinationDTO vaccination)
        {
            VaccinationDAL.UpdateVaccination(vaccination);
        }

        // Deletes a vaccination record.
        public  void DeleteVaccination(int vaccinationId)
        {
            VaccinationDAL.DeleteVaccination(vaccinationId);
        }

        // Retrieves all vaccination records for a member.
        public  IEnumerable<VaccinationDTO> GetVaccinationsByMemberId(int memberId)
        {
            return VaccinationDAL.GetVaccinationsByMemberId(memberId);
        }

        public  IEnumerable<VaccinationDTO> GetVaccinationsByManufacturer(string manufacturer)
        {
            return VaccinationDAL.GetVaccinationsByManufacturer(manufacturer);
        }
    }

}
