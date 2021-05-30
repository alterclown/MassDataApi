using MassDataApi.Data.Entities;
using MassDataApi.Service.MassService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MassDataApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        //private readonly IStudentService _service;
        private readonly UserManager<IdentityUser> _userManager;
        public StudentController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }
        //[HttpGet]
        //[Route("GetStudentRegistrationList")]
        //public async Task<IActionResult> GetStudentRegistrationList()
        //{
        //    try
        //    {
        //        var response = await _service.GetStudentRegistrationList();
        //        if (response != null)
        //        {
        //            return Ok(response);
        //        }
        //        return StatusCode(StatusCodes.Status204NoContent);
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }

        //}

        // GET: Company/Details/5
        //[HttpGet]
        //[Route("GetStudentRegistrationById/{StudentId}")]
        //public async Task<IActionResult> StudentRegistrationDetails(int StudentId)
        //{
        //    try
        //    {
        //        var response = await _service.GetStudentRegistration(StudentId);
        //        if (response != null)
        //        {
        //            return Ok(response);
        //        }
        //        return StatusCode(StatusCodes.Status204NoContent);
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}

        [HttpPost]
        [Route("PostStudentRegistration")]
        public async Task<IActionResult> CreateStudentRegistration(Authentication auth)
        {

            try
            {
                var user = new IdentityUser
                {
                    UserName = auth.Email,
                    Email = auth.Email,
                };
                var result = await _userManager.CreateAsync(user, auth.Password);
                if (result != null)
                {
                    return Ok(result);
                }
                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }



        //[HttpDelete("DeleteById/{StudentId}")]
        //public async Task<IActionResult> DeleteStudentRegistration(int StudentId)
        //{

        //    try
        //    {
        //        var response = await _service.DeleteStudentRegistration(StudentId);
        //        if (response != null)
        //        {
        //            return Ok(response);
        //        }
        //        return StatusCode(StatusCodes.Status204NoContent);
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }

        //}

        //[HttpPut]
        //[Route("PutStudentRegistration/{StudentRegistrationId}")]
        //public async Task<IActionResult> UpdateStudentRegistration(int StudentId, StudentRegistration certificate)
        //{
        //    try
        //    {
        //        var res = await _service.UpdateStudentRegistration(StudentId, certificate);
        //        if (res != null)
        //        {
        //            return Ok(res);
        //        }
        //        return StatusCode(StatusCodes.Status204NoContent);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
    }
}
