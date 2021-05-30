using MassDataApi.Data.Entities;
using MassDataApi.Repository.MassRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassDataApi.Service.MassService
{
    public interface IStudentService
    {
        Task<ICollection<StudentRegistration>> GetStudentRegistrationList();
        Task<StudentRegistration> GetStudentRegistration(int id);
        Task<StudentRegistration> CreateNewStudentRegistration(StudentRegistration student);

        Task<string> DeleteStudentRegistration(int id);
        Task<string> UpdateStudentRegistration(int id, StudentRegistration student);
    }
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _repository;
        public StudentService(IStudentRepository repository)
        {
            _repository = repository;
        }
        public async Task<StudentRegistration> CreateNewStudentRegistration(StudentRegistration student)
        {
            try
            {
                var res = await _repository.CreateNewStudentRegistration(student);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> DeleteStudentRegistration(int id)
        {
            try
            {
                var res = await _repository.DeleteStudentRegistration(id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<StudentRegistration> GetStudentRegistration(int id)
        {
            try
            {
                var res = await _repository.GetStudentRegistration(id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<ICollection<StudentRegistration>> GetStudentRegistrationList()
        {
            try
            {
                var res = await _repository.GetStudentRegistrationList();
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> UpdateStudentRegistration(int id, StudentRegistration student)
        {
            try
            {
                var res = await _repository.UpdateStudentRegistration(id, student);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
