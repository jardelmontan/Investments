using FluentValidation;
using Investments.Domain.Dtos;
using Investments.Domain.Dtos.Requests;
using Investments.Domain.Interfaces.Services;
using Investments.WebApi.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Investments.WebApi.Controllers
{
    [ApiController]
    [Route("simulate-investment")]
    public class SimulateInvestmentController(
        ICdbService cdbService, 
        IServiceProvider serviceProvider, 
        ILogger<SimulateInvestmentController> logger) : ControllerBase
    {
        private readonly ICdbService _cdbService = cdbService;
        private readonly IServiceProvider _serviceProvider = serviceProvider;
        private readonly ILogger<SimulateInvestmentController> _logger = logger;

        /// <summary>
        /// Simulate investment in a CDB.
        /// </summary>
        /// <param name="request">The investment simulation request data.</param>
        /// <returns>Returns the simulation result or an error message.</returns>
        [HttpPost("cdb")]
        [ProducesResponseType(typeof(SimulateCdbResponseDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(IEnumerable<RequestValidationErrorDto>), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ErrorDto), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> SimulateCdb([FromBody] SimulateCdbRequestDto request)
        {
            try
            {
                var validator = _serviceProvider.GetRequiredService<IValidator<SimulateCdbRequestDto>>();
                var validationResult = await validator.ValidateAsync(request);

                if (!validationResult.IsValid)
                {
                    return BadRequest(validationResult.GetErrors());
                }

                var result = _cdbService.SimulateInvestment(request);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error");
                return StatusCode(500, new ErrorDto { ErrorMessage = "An unexpected error occurred while processing the information." });
            }
        }
    }
}
