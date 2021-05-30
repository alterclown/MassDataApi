using MassDataApi.Data.Entities;
using MassDataApi.Repository.MassRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassDataApi.Service.MassService
{
    public interface IAuthenticationService
    {
        Task<Authentication> RegisterNewUser(Authentication auth);
    }
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IAuthenticationRepository _repository;

        public AuthenticationService(IAuthenticationRepository repository)
        {
            _repository = repository;
        }
        public async Task<Authentication> RegisterNewUser(Authentication auth)
        {
            try
            {
                var res = await _repository.RegisterNewUser(auth);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
    
}
