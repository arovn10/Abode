/*using Microsoft.AspNetCore.Mvc;
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
*/
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Abode.Main;
using System.Collections.Generic; // Added for List<string>

[ApiController]
[Route("api/")]
public class RoutingController : ControllerBase
{
    private readonly AbodeDbContext _dbContext; // Added field for AbodeDbContext

    // Constructor to inject AbodeDbContext
    public RoutingController(AbodeDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet("test")]
    public ActionResult<List<string>> Test()
    {
        return Ok(new List<string> { "hi" });
    }

    [HttpGet("homes/{id}")]
    public ActionResult<object> GetHome(int id)
    {
        var home = _dbContext.Homes.FirstOrDefault(x => x.PersonId == id);
        
        if (home == null)
        {
            return NotFound();
        }
        
        var result = new
        {
            FirstName = home.FirstName,
            LastName = home.LastName,
            Address = home.Address,
            City = home.City
        };
        return Ok(result);
    }

    [HttpGet("landlords/{id}")]
    public ActionResult<object> GetLandlord(int id)
    {
        var landlord = _dbContext.Landlord.FirstOrDefault(x => x.LandlordID == id);
        if (landlord == null)
        {
            return NotFound();
        }
        var result = new
        {
            FirstName = landlord.FirstName,
            LastName = landlord.LastName,
            EmailAddress = landlord.EmailAddress,
            Phone = landlord.Phone
        };
        return Ok(result);
    }

}
