using Application.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class DoctorService
    {
        private readonly IDoctorRepository _repo;
        public DoctorService(IDoctorRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<Doctor>> GetAllAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task<Doctor?> GetByIdAsync(int id)
        {
            return await _repo.GetByIdAsync(id);
        }

        public async Task<Doctor> AddAsync(Doctor doctor)
        {
            return await _repo.AddAsync(doctor);
        }

        public async Task<bool> UpdateAsync(Doctor doctor)
        {
            return await _repo.UpdateAsync(doctor);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repo.DeleteAsync(id); 
        }
        public async Task AddPrescription(Prescription prescription)
        {
            await _repo.AddPrescription(prescription);
        }
        public async Task AddHealthRecord(HealthRecord healthrecord)
        {
            await _repo.AddHealthRecord(healthrecord);
        }

        public async Task<int> GetDoctorId(string email)
        {
            return await _repo.GetDoctorId(email);  
        }
        public async Task<bool> CheckLoginAsync(string name, string email)
        {
            return await _repo.CheckLoginAsync(name, email);    
        }
    }
}
