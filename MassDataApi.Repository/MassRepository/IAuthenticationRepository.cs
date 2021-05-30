using AutoMapper;
using MassDataApi.Data.DbContexts;
using MassDataApi.Data.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassDataApi.Repository.MassRepository
{
    public interface IAuthenticationRepository
    {
        Task<List<Authentication>> GetUserList();
        Task<Authentication> RetrieveUserInfo(int userId);
        Task<Authentication> PostLoginInfo(Authentication auth);
        Task<Authentication> RegisterNewUser(Authentication auth);
    }
    public class AuthenticationRepository : IAuthenticationRepository
    {
        
        private readonly MassDataContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<Authentication> _userManager;

        public AuthenticationRepository(MassDataContext context, UserManager<Authentication> userManager,
            IMapper mapper)
        {
            _context = context;
            _userManager = userManager;
            _mapper = mapper;
        }
        public Task<List<Authentication>> GetUserList()
        {
            throw new NotImplementedException();
        }

        public Task<Authentication> PostLoginInfo(Authentication auth)
        {
            throw new NotImplementedException();
        }

        public async Task<Authentication> RegisterNewUser(Authentication auth)
        {
            try
            {
                var user = _mapper.Map<Authentication>(auth);
                var result = await _userManager.CreateAsync(user, auth.Password);
                return auth;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Task<Authentication> RetrieveUserInfo(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
