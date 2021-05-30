using MassDataApi.Data.Entities;
using MassDataApi.Repository.MassRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassDataApi.Service.MassService
{
    public interface ITemporaryCertificateService
    {
        Task<ICollection<TemporaryCertificate>> GetTemporaryCertificateList();
        Task<TemporaryCertificate> GetTemporaryCertificate(int id);
        Task<TemporaryCertificate> CreateNewTemporaryCertificate(TemporaryCertificate certificate);

        Task<string> DeleteTemporaryCertificate(int id);
        Task<string> UpdateTemporaryCertificate(int id, TemporaryCertificate certificate);
    }

    public class TemporaryCertificateService : ITemporaryCertificateService
    {
        private readonly ITemporaryCertificateRepository _repository;

        public TemporaryCertificateService(ITemporaryCertificateRepository repository)
        {
            _repository = repository;
        }
        public async Task<TemporaryCertificate> CreateNewTemporaryCertificate(TemporaryCertificate certificate)
        {
            try
            {
                var res = await _repository.CreateNewTemporaryCertificate(certificate);
                return res;
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
                var res = await _repository.DeleteTemporaryCertificate(id);
                return res;
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
                var res = await _repository.GetTemporaryCertificate(id);
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
                var res = await _repository.GetTemporaryCertificateList();
                return res;
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
                var res = await _repository.UpdateTemporaryCertificate(id,certificate);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
