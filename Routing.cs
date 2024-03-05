using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Main;

[ApiController]
[Route("api/")]
public class RoutingController : ControllerBase
{
    private readonly AbodeDbContext _dbContext;
    

    [HttpGet("test")]
    public ActionResult<List<string>> Test()
    {
        return Ok(new List<string> { "hi" });
    }

    [HttpGet("landlords/{id}")]
    public ActionResult<List<string>> GetLandlord(long id)
    {
        var landlord = _dbContext.Landlord.FirstOrDefault(x => x.LandlordID == id);

        if (landlord == null)
        {
            return NotFound();
        }

        var firstName = landlord.FirstName;
        var lastName = landlord.LastName;
        var fullName = $"{firstName} {lastName}";
        var names = new List<string> { fullName };
        return Ok(names);
    }

}