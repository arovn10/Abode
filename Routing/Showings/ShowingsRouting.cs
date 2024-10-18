using Abode.Models; // Assuming your DbContext is in this namespace
using Microsoft.AspNetCore.Mvc;

namespace Abode.ShowingsRoute
{
    [ApiController]
    [Route("api/showings")]
    public class ShowingsRouting : ControllerBase
    {
        private readonly AbodeDbContext _dbContext;

        public ShowingsRouting(AbodeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost("create")]
        public IActionResult AddShowingFunction([FromBody] ShowingScheduler input)
        {
            try
            {
                var newShowing = new ShowingScheduler
                {
                    PropertyId = input.PropertyId,
                    StartTime = input.StartTime,
                    EndTime = input.EndTime,
                    PublicShowing = input.PublicShowing,
                };

                _dbContext.ShowingSchedulers.Add(newShowing);
                _dbContext.SaveChanges();
                return Ok("Showing successfully added");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while adding the showing: {ex.Message}. Details: {ex.InnerException?.Message}");
            }
        }

        [HttpPost("attendee")]
        public IActionResult AddAttendee([FromBody] ShowingAttendee input)
        {
            try
            {
                var newAttendee = new ShowingAttendee
                {
                    ShowingId = input.ShowingId,
                    UserId = input.UserId,
                    Notes = input.Notes
                };

                _dbContext.ShowingAttendees.Add(newAttendee);
                _dbContext.SaveChanges();
                return Ok("Attendee successfully added");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while adding the attendee: {ex.Message}. Details: {ex.InnerException?.Message}");
            }
        }


        [HttpGet("get/{id}")]
        public ActionResult<object> GetShowingsByPropertyId(int id)
        {
            var showings = _dbContext.ShowingSchedulers
                .Where(x => x.PropertyId == id)
                .ToList();

            if (!showings.Any())
            {
                return NotFound($"No showings found for property ID {id}");
            }

            // Create the result based on all photos found
            var result = showings.Select(x => new
            {
                PropertyId = x.PropertyId,
                StartTime = x.StartTime,
                EndTime = x.EndTime,
                PublicShowing = x.PublicShowing,
            });

            return Ok(result);
        }

        [HttpGet("get/attendeesByShowingId/{id}")]
        public ActionResult<object> GetAttendeesByShowingId(int id)
        {
            // Fetch all attendees for the given showingId
            var showings = _dbContext.ShowingAttendees
                .Where(x => x.ShowingId == id)
                .ToList();

            // Check if no attendees were found for the given showingId
            if (!showings.Any())
            {
                return NotFound($"No attendees found for this showing with id {id}.");
            }

            // Create the result based on all attendees found for the showing
            var result = showings.Select(x => new
            {
                ShowingId = x.ShowingId,
                UserId = x.UserId,
                Notes = x.Notes
            });

            return Ok(result);
        }


        [HttpPut("update/{id}")]
        public IActionResult UpdateShowing(int id, [FromBody] ShowingScheduler input)
        {
            try
            {
                // Find the existing showing by id
                var existingShowing = _dbContext.ShowingSchedulers.FirstOrDefault(p => p.ShowingId == id);

                if (existingShowing == null)
                {
                    return NotFound($"No showing found with ID {id}");
                }

                // Update the photo fields
                existingShowing.PropertyId = input.PropertyId;
                existingShowing.StartTime = input.StartTime;
                existingShowing.EndTime = input.EndTime;
                existingShowing.PublicShowing = input.PublicShowing;

                _dbContext.SaveChanges();

                return Ok("Showing updated successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while updating the showing: {ex.Message}. Details: {ex.InnerException?.Message}");
            }
        }

        [HttpDelete("deleteShowingByShowingId/{showingId}")]
        public ActionResult<object> DeleteShowing(int showingId)
        {
            var showings = _dbContext.ShowingSchedulers.Where(x => x.ShowingId == showingId).ToList();
            if (!showings.Any())
            {
                return NotFound();
            }
            _dbContext.ShowingSchedulers.RemoveRange(showings);
            _dbContext.SaveChanges();
            return Ok("Showing Successfully Deleted");
        }


    }

}
