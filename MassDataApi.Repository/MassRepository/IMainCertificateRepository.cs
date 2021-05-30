using MassDataApi.Data.DbContexts;
using MassDataApi.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassDataApi.Repository.MassRepository
{
    public interface IMainCertificateRepository
    {
        Task<ICollection<MainCertificate>> GetMainCertificateList();
        Task<MainCertificate> GetMainCertificate(int id);
        Task<MainCertificate> CreateNewMainCertificate(MainCertificate certificate);

        Task<string> DeleteMainCertificate(int id);
        Task<string> UpdateMainCertificate(int id, MainCertificate certificate);
    }
    public class MainCertificateRepository : IMainCertificateRepository
    {
        private readonly MassDataContext _context;
        public MainCertificateRepository(MassDataContext context)
        {
            _context = context;
        }
        public async Task<MainCertificate> CreateNewMainCertificate(MainCertificate certificate)
        {
            try
            {
                _context.MainCertificates.Add(certificate);
                await _context.SaveChangesAsync();
                return certificate;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> DeleteMainCertificate(int id)
        {
            try
            {
                var response = await _context.MainCertificates.FindAsync(id);
                _context.MainCertificates.Remove(response);
                await _context.SaveChangesAsync();
                return "Deleted SuccessFully";
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<MainCertificate> GetMainCertificate(int id)
        {
            try
            {
                var res = await _context.MainCertificates.FirstOrDefaultAsync(m => m.MainCertificateId == id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async  Task<ICollection<MainCertificate>> GetMainCertificateList()
        {
            try
            {
                var response = from c in _context.MainCertificates
                               orderby c.MainCertificateId descending
                               select c;
                return await response.ToListAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> UpdateMainCertificate(int id, MainCertificate certificate)
        {
            try
            {
                var res = await _context.MainCertificates.FirstOrDefaultAsync(m => m.MainCertificateId == id);
                res.RegNumber = certificate.RegNumber;
                res.Name = certificate.Name;
                res.FathersName = certificate.FathersName;
                res.Session = certificate.Session;
                res.Program = certificate.Program;
                res.CGPA = certificate.CGPA;
                res.Address = certificate.Address;
                res.Mobile = certificate.Mobile;
                res.Email = certificate.Email;
                res.ApplyDate = certificate.ApplyDate;
                res.TranIt = certificate.TranIt;
                res.Status = certificate.Status;
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
