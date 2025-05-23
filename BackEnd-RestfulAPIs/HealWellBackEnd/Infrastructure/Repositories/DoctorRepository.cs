// DoctorRepository.cs

using Application.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Infrastructure.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly HealWellDbContext _context;

        public DoctorRepository(HealWellDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Doctor>> GetAllAsync()
        {
            return await _context.Doctors.Include(d => d.Department).ToListAsync();
        }

        public async Task<Doctor?> GetByIdAsync(int id)
        {
            return await _context.Doctors.FindAsync(id);
        }

        public async Task<Doctor> AddAsync(Doctor doctor)
        {
            _context.Doctors.Add(doctor);
            await _context.SaveChangesAsync();
            return doctor;
        }

        public async Task<bool> UpdateAsync(Doctor doctor)
        {
            var existing = await _context.Doctors.FindAsync(doctor.Id);
            if (existing == null) return false;

            _context.Entry(existing).CurrentValues.SetValues(doctor);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var doctor = await _context.Doctors.FindAsync(id);
            if (doctor == null) return false;

            _context.Doctors.Remove(doctor);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task AddPrescription(Prescription prescription)
        {
            await _context.Prescriptions.AddAsync(prescription);
        }
        public async Task AddHealthRecord(HealthRecord healthrecord)
        {
            await _context.HealthRecords.AddAsync(healthrecord);
        }
       
        public async Task<int> GetDoctorId(string email)
        {
            var doctor = await _context.Doctors.Where(s=>s.Email == email).FirstOrDefaultAsync();
            return doctor.Id;
        }
        public async Task<bool> CheckLoginAsync(string name, string email)
        {
            return await _context.Doctors.AnyAsync(p => p.Name == name && p.Email == email);
        }
    }
}
