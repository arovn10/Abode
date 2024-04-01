using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Abode.Main;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abode.Tables; // Added for List<string>

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
        var home = _dbContext.Homes.FirstOrDefault(x => x.PersonID == id);

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
    public void AddAccount(Accounts account)
    {
        try
        {
            var newAccount = new Accounts
            {
                email = account.email,
                username = account.username,
                password = account.password,
                userType = account.userType,
                school = account.school
            };

            _dbContext.Accounts.Add(newAccount);
            _dbContext.SaveChanges(); // Assuming SaveChanges is synchronous
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    [HttpPost("accounts/create")]
    public IActionResult CreateAccount(Accounts input)
    {
        AddAccount(input);
        return Ok("Success");
    }
    public void AddHome(Homes home)
    {
        try
        {
            var newHome = new Homes
            {
                PersonID = home.PersonID,
                LastName = home.LastName,
                FirstName = home.LastName,
                Address = home.LastName,
                City = home.LastName
            };

            _dbContext.Homes.Add(newHome);
            _dbContext.SaveChanges(); // Assuming SaveChanges is synchronous
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    [HttpPost("home/create")]
    public IActionResult CreateHome(Homes input)
    {
        AddHome(input);
        return Ok("Success");
    }

    //not working says the wrong type cast for ListingID but im confused bc its def an int
    /*[HttpGet("rentalListing/{id}")]
    public ActionResult<object> GetRentalListing(int id)
    {
        var listing = _dbContext.RentalListing.FirstOrDefault(x => x.ListingID == id);

        if (listing == null)
        {
            return NotFound();
        }

        var result = new
        {
            PropertyName = listing.PropertyName,
            MonthlyRent = listing.MonthlyRent,
            Address = listing.Address,
            AvailableDate = listing.AvailableDate
        };
        return Ok(result);
    }*/
    public void AddTenant(Tenants tenant)
    {
        try
        {
            var newTenant = new Tenants
            {
                PersonID = tenant.PersonID,
                LastName = tenant.LastName,
                FirstName = tenant.LastName,
                Address = tenant.LastName,
                City = tenant.LastName
            };

            _dbContext.Tenants.Add(newTenant);
            _dbContext.SaveChanges(); // Assuming SaveChanges is synchronous
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    [HttpPost("tenant/create")]
    public IActionResult CreateTenant(Tenants input)
    {
        AddTenant(input);
        return Ok("Success");
    }
    [HttpGet("tenant/{id}")]
    public ActionResult<object> GetTenant(int id)
    {
        var tenant = _dbContext.Tenants.FirstOrDefault(x => x.PersonID == id);
        if (tenant == null)
        {
            return NotFound();
        }
        var result = new
        {
            FirstName = tenant.FirstName,
            LastName = tenant.LastName,
            Address = tenant.Address,
            City = tenant.City
        };
        return Ok(result);
    }

}
