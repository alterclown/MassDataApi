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
    public interface ITemporaryCertificateRepository
    {
        Task<ICollection<TemporaryCertificate>> GetTemporaryCertificateList();
        Task<TemporaryCertificate> GetTemporaryCertificate(int id);
        Task<TemporaryCertificate> CreateNewTemporaryCertificate(TemporaryCertificate certificate);

        Task<string> DeleteTemporaryCertificate(int id);
        Task<string> UpdateTemporaryCertificate(int id, TemporaryCertificate certificate);
    }
    public class TemporaryCertificateRepository : ITemporaryCertificateRepository
    {
        private readonly MassDataContext _context;
        public TemporaryCertificateRepository(MassDataContext context)
        {
            _context = context;
        }
        public async Task<TemporaryCertificate> CreateNewTemporaryCertificate(TemporaryCertificate certificate)
        {
            try
            {
                _context.TemporaryCertificates.Add(certificate);
                await _context.SaveChangesAsync();
                return certificate;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> DeleteTemporaryCertificate(int id)
        {
            try
            {
                var response = await _context.TemporaryCertificates.FindAsync(id);
                _context.TemporaryCertificates.Remove(response);
                await _context.SaveChangesAsync();
                return "Deleted SuccessFully";
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<TemporaryCertificate> GetTemporaryCertificate(int id)
        {
            try
            {
                var res = await _context.TemporaryCertificates.FirstOrDefaultAsync(m => m.TemporaryCertificateId == id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<ICollection<TemporaryCertificate>> GetTemporaryCertificateList()
        {
            try
            {
                var response = from c in _context.TemporaryCertificates
                               orderby c.TemporaryCertificateId descending
                               select c;
                return await response.ToListAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> UpdateTemporaryCertificate(int id, TemporaryCertificate certificate)
        {
            try
            {
                var res = await _context.TemporaryCertificates.FirstOrDefaultAsync(m => m.TemporaryCertificateId == id);
                res.RegNumber = certificate.RegNumber;
                res.Name = certificate.Name;
                res.FathersName = certificate.FathersName;
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
