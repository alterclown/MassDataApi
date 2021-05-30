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
    public class TemporaryCertificateController : ControllerBase
    {
        private readonly ITemporaryCertificateService _service;
        public TemporaryCertificateController(ITemporaryCertificateService service)
        {
            _service = service;
        }
        [HttpGet]
        [Route("GetTemporaryCertificateList")]
        public async Task<IActionResult> GetTemporaryCertificateList()
        {
            try
            {
                var response = await _service.GetTemporaryCertificateList();
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
        [Route("GetTemporaryCertificateById/{TemporaryCertificateId}")]
        public async Task<IActionResult> TemporaryCertificateDetails(int TemporaryCertificateId)
        {
            try
            {
                var response = await _service.GetTemporaryCertificate(TemporaryCertificateId);
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
        [Route("PostTemporaryCertificate")]
        public async Task<IActionResult> CreateTemporaryCertificate(TemporaryCertificate certificate)
        {

            try
            {
                var response = await _service.CreateNewTemporaryCertificate(certificate);
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



        [HttpDelete("DeleteById/{TemporaryCertificateId}")]
        public async Task<IActionResult> DeleteTemporaryCertificate(int TemporaryCertificateId)
        {

            try
            {
                var response = await _service.DeleteTemporaryCertificate(TemporaryCertificateId);
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
        [Route("PutTemporaryCertificate/{TemporaryCertificateId}")]
        public async Task<IActionResult> UpdateTemporaryCertificate(int TemporaryCertificateId, TemporaryCertificate certificate)
        {
            try
            {
                var res = await _service.UpdateTemporaryCertificate(TemporaryCertificateId, certificate);
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
