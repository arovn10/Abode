using Abode.Models; // Assuming your DbContext is in this namespace
using Microsoft.AspNetCore.Mvc;

namespace Abode.PhotosRoute
{
    [ApiController]
    [Route("api/photos")]
    public class PhotosRouting : ControllerBase
    {
        private readonly AbodeDbContext _dbContext;

        public PhotosRouting(AbodeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost("create")]
        public IActionResult AddPhotoFunction([FromBody] Photo input)
        {
            try
            {
                var newPhoto = new Photo
                {
                    PropertyKey = input.PropertyKey,
                    PhotoLink = input.PhotoLink,
                    Description = input.Description,
                };

                _dbContext.Photos.Add(newPhoto);
                _dbContext.SaveChanges();
                return Ok("Photo successfully added");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while adding the photo: {ex.Message}. Details: {ex.InnerException?.Message}");
            }
        }

        [HttpGet("test")]
        public IActionResult Test()
        {
            return Ok("Test successful");
        }
    }
}
