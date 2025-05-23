using HealWell.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace HealWell.Services
{
    public class DoctorService
    {
        private readonly HttpClient _httpClient;
        public DoctorService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<int> loginandReturnId(DoctorLoginModel model)
        {
            try
            {
                // Simulate API call
                //await Task.Delay(1500);
                var response = await _httpClient.PostAsJsonAsync("https://localhost:7047/api/Doctors/check-login", model);
                int Id;
                if (response.IsSuccessStatusCode)
                {

                    var responsemsg = await _httpClient.PostAsJsonAsync($"https://localhost:7047/api/Doctors/GetId", model);
                    Id = await responsemsg.Content.ReadFromJsonAsync<int>();

                    return Id;
                    // Navigate or save token, etc.
                }
                else
                {
                    return -1;
                }
                // Successful login - redirect to dashboard

            }
            catch (Exception ex)
            {
                Console.WriteLine("Invalid email or password. Please try again.");
                return -1;
            }

        }
        public async Task<List<Doctor>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Doctor>>("https://localhost:7047/api/Doctors/GetAll");
        }
        public async Task<Doctor> GetById(int id)
        {
            try
            {
                var doctor = await _httpClient.GetFromJsonAsync<Doctor>($"https://localhost:7047/api/Doctors/{id}");
                return doctor;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<bool> UpdateDoctor(Doctor doctor)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"https://localhost:7047/api/Doctors/{doctor.Id}", doctor);
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }

        }
       
        public async Task<string> GetImageUrl(string url)
        {
            return $"https://localhost:7047/images/{url}";
        }
        //public async Task<Doctor?> GetByIdAsync(int id)
        //{
        //    return await _repo.GetByIdAsync(id);
        //}

        //public async Task<Doctor> AddAsync(Doctor doctor)
        //{
        //    return await _repo.AddAsync(doctor);
        //}

        //public async Task<bool> UpdateAsync(Doctor doctor)
        //{
        //    return await _repo.UpdateAsync(doctor);
        //}

        //public async Task<bool> DeleteAsync(int id)
        //{
        //    return await _repo.DeleteAsync(id); 
        //}
        //public async Task AddPrescription(Prescription prescription)
        //{
        //    await _repo.AddPrescription(prescription);
        //}
        //public async Task AddHealthRecord(HealthRecord healthrecord)
        //{
        //    await _repo.AddHealthRecord(healthrecord);
        //}

        //public async Task<int> GetDoctorId(string email)
        //{
        //    return await _repo.GetDoctorId(email);  
        //}
        //public async Task<bool> CheckLoginAsync(string name, string email)
        //{
        //    return await _repo.CheckLoginAsync(name, email);    
        //}
    }
}
