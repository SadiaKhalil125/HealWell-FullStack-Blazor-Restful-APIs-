using Domain.Models;
namespace Application.Interfaces
{
    public interface IDoctorRepository
    {
        Task<IEnumerable<Doctor>> GetAllAsync();
        Task<Doctor?> GetByIdAsync(int id);
        Task<Doctor> AddAsync(Doctor doctor);
        Task<bool> UpdateAsync(Doctor doctor);
        Task<bool> DeleteAsync(int id);
        Task AddPrescription(Prescription prescription);
        Task AddHealthRecord(HealthRecord healthrecord);
        Task<int> GetDoctorId(string email);
        Task<bool> CheckLoginAsync(string name, string email);
    }
}
