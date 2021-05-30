using MassDataApi.Data.Entities;
using MassDataApi.Repository.MassRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassDataApi.Service.MassService
{
    public interface IMainCertificateService
    {
        Task<ICollection<MainCertificate>> GetMainCertificateList();
        Task<MainCertificate> GetMainCertificate(int id);
        Task<MainCertificate> CreateNewMainCertificate(MainCertificate certificate);

        Task<string> DeleteMainCertificate(int id);
        Task<string> UpdateMainCertificate(int id, MainCertificate certificate);
    }

    public class MainCertificateService : IMainCertificateService
    {
        private readonly IMainCertificateRepository _repository;
        public MainCertificateService(IMainCertificateRepository repository)
        {
            _repository = repository;
        }
        public async Task<MainCertificate> CreateNewMainCertificate(MainCertificate certificate)
        {
            try
            {
                var res = await _repository.CreateNewMainCertificate(certificate);
                return res;
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
                var res = await _repository.DeleteMainCertificate(id);
                return res;
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
                var res = await _repository.GetMainCertificate(id);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<ICollection<MainCertificate>> GetMainCertificateList()
        {
            try
            {
                var res = await _repository.GetMainCertificateList();
                return res;
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
                var res = await _repository.UpdateMainCertificate(id,certificate);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
