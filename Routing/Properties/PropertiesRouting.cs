using Abode.Models; // Assuming your DbContext is in this namespace
using Microsoft.AspNetCore.Mvc;

namespace Abode.PhotosRoute
{
    [ApiController]
    [Route("api/properties")]
    public class PropertiesRouting : ControllerBase
    {
        private readonly AbodeDbContext _dbContext;

        public PropertiesRouting(AbodeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost("create/specs")]
        public IActionResult AddPropertySpecs([FromBody] Spec input)
        {
            try
            {
                var newSpecs = new Spec
                {
                    PropertyId = input.PropertyId,
                    Keys = input.Keys,
                    Paint = input.Paint,
                    Door = input.Door,
                    Flooring = input.Flooring,
                    SquareFeet = input.SquareFeet,
                 
                };

                _dbContext.Specs.Add(newSpecs);
                _dbContext.SaveChanges();
                return Ok("Specs successfully added");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while adding specs: {ex.Message}. Details: {ex.InnerException?.Message}");
            }
        }

        [HttpGet("get/specsByPropertyId/{id}")]
        public ActionResult<object> GetSpecsByPropertyId(int id)
        {
            var specs = _dbContext.Specs
                .Where(x => x.PropertyId == id)
                .ToList();

            if (!specs.Any())
            {
                return NotFound($"No specs found for property ID {id}");
            }

            return Ok(specs);
        }
    }

}
