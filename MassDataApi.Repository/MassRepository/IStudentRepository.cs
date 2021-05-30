using MassDataApi.Data.DbContexts;
using MassDataApi.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassDataApi.Repository.MassRepository
{
    public interface IStudentRepository
    {
        Task<ICollection<StudentRegistration>> GetStudentRegistrationList();
        Task<StudentRegistration> GetStudentRegistration(int id);
        Task<StudentRegistration> CreateNewStudentRegistration(StudentRegistration student);

        Task<string> DeleteStudentRegistration(int id);
        Task<string> UpdateStudentRegistration(int id, StudentRegistration student);
    }
    public class StudentRepository : IStudentRepository
    {
        private readonly MassDataContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        public StudentRepository(MassDataContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<StudentRegistration> CreateNewStudentRegistration(StudentRegistration student)
        {
            try
            {
                var user = new IdentityUser
                {
                    UserName = student.Email,
                    Email = student.Email,
                };
                var result = await _userManager.CreateAsync(user, student.Password);
                if (result != null)
                {
                    return student;
                }
                return student;
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
                var response = await _context.StudentRegistrations.FindAsync(id);
                _context.StudentRegistrations.Remove(response);
                await _context.SaveChangesAsync();
                return "Deleted SuccessFully";
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
                var res = await _context.StudentRegistrations.FirstOrDefaultAsync(m => m.StudentId == id);
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
                var response = from c in _context.StudentRegistrations
                               orderby c.StudentId descending
                               select c;
                return await response.ToListAsync();
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
                var res = await _context.StudentRegistrations.FirstOrDefaultAsync(m => m.StudentId == id);
                res.Name = student.Name;
                res.Email = student.Email;
                res.RegNumber = student.RegNumber;
                res.Phone = student.Phone;
                res.CreatedDate = student.CreatedDate;
                res.Password = student.Password;
                _context.Update(res);
                await _context.SaveChangesAsync();
                return "Updated Record";
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
