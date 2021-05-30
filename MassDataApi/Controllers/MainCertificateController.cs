using MassDataApi.Data.Entities;
using MassDataApi.Service.MassService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MassDataApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainCertificateController : ControllerBase
    {
        private readonly IMainCertificateService _service;
        public MainCertificateController(IMainCertificateService service)
        {
            _service = service;
        }
        [HttpGet]
        [Route("GetMainCertificateList")]
        public async Task<IActionResult> GetMainCertificateList()
        {
            try
            {
                var response = await _service.GetMainCertificateList();
                if (response != null)
                {
                    return Ok(response);
                }
                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        // GET: Company/Details/5
        [HttpGet]
        [Route("GetMainCertificateById/{MainCertificateId}")]
        public async Task<IActionResult> MainCertificateDetails(int MainCertificateId)
        {
            try
            {
                var response = await _service.GetMainCertificate(MainCertificateId);
                if (response != null)
                {
                    return Ok(response);
                }
                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPost]
        [Route("PostMainCertificate")]
        public async Task<IActionResult> CreateMainCertificate(MainCertificate certificate)
        {

            try
            {
                var response = await _service.CreateNewMainCertificate(certificate);
                if (response != null)
                {
                    return Ok(response);
                }
                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }



        [HttpDelete("DeleteById/{MainCertificateId}")]
        public async Task<IActionResult> DeleteMainCertificate(int MainCertificateId)
        {

            try
            {
                var response = await _service.DeleteMainCertificate(MainCertificateId);
                if (response != null)
                {
                    return Ok(response);
                }
                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        [HttpPut]
        [Route("PutMainCertificate/{MainCertificateId}")]
        public async Task<IActionResult> UpdateMainCertificate(int MainCertificateId, MainCertificate certificate)
        {
            try
            {
                var res = await _service.UpdateMainCertificate(MainCertificateId, certificate);
                if (res != null)
                {
                    return Ok(res);
                }
                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
