using CodeChallenge.Models;
using CodeChallenge.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace CodeChallenge.Controllers
{
    [ApiController]
    [Route("api/reporting")]
    public class ReportingController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IReportingService _reportingService;

        public ReportingController(ILogger<EmployeeController> logger, IReportingService reportingService)
        {
            _logger = logger;
            _reportingService = reportingService;
        }

        /*
         * HTTP Method: GET 
         * URL: /api/reporting/{id}
         * RESPONSE: ReportingStructure
         */
        [HttpGet("{id}", Name = "getReportingByEmployeeId")]
        public IActionResult GetReportingByEmployeeId(string id)
        {
            _logger.LogDebug($"Received reporting get request for '{id}'");

            ReportingStructure reporting = _reportingService.GetById(id);

            if (reporting == null)
                return NotFound();

            return Ok(reporting);
        }
    }
}
