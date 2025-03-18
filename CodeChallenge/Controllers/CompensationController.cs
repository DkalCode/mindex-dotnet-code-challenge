using CodeChallenge.Models;
using CodeChallenge.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace CodeChallenge.Controllers
{
    [ApiController]
    [Route("api/compensation")]
    public class CompensationController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly ICompensationService _compensationService;

        public CompensationController(ILogger<CompensationController> logger, ICompensationService compensationService)
        {
            _logger = logger;
            _compensationService = compensationService;
        }

        /*
         * HTTP Method: POST 
         * URL: /api/compensation
         * RESPONSE: Compensation
         */
        [HttpPost]
        public IActionResult CreateCompensation([FromBody] Compensation compensation)
        {
            _logger.LogDebug($"Received compensation create request for '{compensation.Employee.FirstName} {compensation.Employee.LastName}'");

            // Input Validation to check if the Compensation Input is valid and the EmployeeId exists.
            if (!this.ModelState.IsValid && compensation.Employee.EmployeeId != null)
                return BadRequest();

            /* Error Handling: Checks if the provided Employee within the body exists.
             * My thought process on this is that if an employee doesn't exist then you shouldn't
             * be able to create a compensation for them. This also prevents the user from reciving a
             * laundry list of errors if they misinput a employeeId.
             */
            Compensation res = _compensationService.Create(compensation);
            if (res == null) return BadRequest();

            return CreatedAtRoute("getCompensationById", new { id = compensation.Employee.EmployeeId }, compensation);
        }

        /*
         * HTTP Method: GET
         * URL: /api/compensation/{id}
         * RESPONSE: Compensation
         */
        [HttpGet("{id}", Name = "getCompensationById")]
        public IActionResult GetCompensationById(String id)
        {
            _logger.LogDebug($"Received compensation get request for '{id}'");

            var compensation = _compensationService.GetById(id);

            if (compensation == null)
                return NotFound();

            return Ok(compensation);
        }
    }
}
