using Abode.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Abode.MaintenanceRoute
{
    [ApiController]
    [Route("api/maintenance")]
    public class MaintenanceRequestRouting : ControllerBase
    {
        private readonly AbodeDbContext _dbContext;

        public MaintenanceRequestRouting(AbodeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateMaintenanceRequest([FromBody] MaintenanceRequest input)
        {
            try
            {
                var newRequest = new MaintenanceRequest
                {
                    PropertyId = input.PropertyId,
                    TenantId = input.TenantId,
                    RequestDescription = input.RequestDescription,
                    RequestStatus = "In-Progress",
                    SubmissionDate = DateTime.Now
                };

                _dbContext.MaintenanceRequests.Add(newRequest); // Corrected DbSet name
                await _dbContext.SaveChangesAsync();

                return Ok("Maintenance request successfully created");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while creating the request: {ex.Message}. Details: {ex.InnerException?.Message}");
            }
        }

        // GET: Retrieve maintenance requests by Property ID
        [HttpGet("get/byPropertyId/{propertyId}")]
        public async Task<IActionResult> GetRequestsByPropertyId(int propertyId)
        {
            var requests = await _dbContext.MaintenanceRequests
                .Where(r => r.PropertyId == propertyId)
                .ToListAsync();

            if (!requests.Any())
            {
                return NotFound($"No maintenance requests found for property ID {propertyId}");
            }

            return Ok(requests);
        }
    }
}

