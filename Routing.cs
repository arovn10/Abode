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
    public void AddAccount(Accounts Accounts)
    {
        try
        {
            var newAccount = new Accounts
            {
             
                email = Accounts.email,
                username = Accounts.username,
                password = Accounts.password,
                userType = Accounts.userType,
                school = Accounts.school
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

    [HttpGet("accounts/{id}")]
    public ActionResult<object> GetAccount(int id)
    {
        var Accounts = _dbContext.Accounts.FirstOrDefault(x => x.userId == id);

        if (Accounts == null)
        {
            return NotFound();
        }

        var newAccount = new Accounts
        {
            userId = Accounts.userId,
            email = Accounts.email,
            username = Accounts.username,
            password = Accounts.password,
            userType = Accounts.userType,
            school = Accounts.school
        };

        return Ok(newAccount);
    }

    [HttpPost("home/create")]
    public IActionResult CreateHome(Homes input)
    {
        AddHome(input);
        return Ok("Success");
    }

    [HttpGet("rentalListing/{id}")]
    public ActionResult<object> GetRentalListing(decimal id)
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
    }
    public void AddRentalListing(RentalListing rental)
    {
        try
        {
            var newRental = new RentalListing
            {
                ListingID = rental.ListingID,
                PropertyName = rental.PropertyName,
                MonthlyRent = rental.MonthlyRent,
                Address = rental.Address,
                AvailableDate = rental.AvailableDate
            };

            _dbContext.RentalListing.Add(newRental);
            _dbContext.SaveChanges(); // Assuming SaveChanges is synchronous
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    [HttpPost("rentalListing/create")]
    public IActionResult CreateRentalListing(RentalListing input)
    {
        AddRentalListing(input);
        return Ok("Rental Listing Successfullly Added");
    }
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

    [HttpDelete("deleteTenant/{id}")]
    public ActionResult<object> DeleteTenant(int id)
    {
        var tenant = _dbContext.Tenants.FirstOrDefault(x => x.PersonID == id);
        if (tenant == null)
        {
            return NotFound();
        }
        _dbContext.Tenants.Remove(tenant);
        _dbContext.SaveChanges(); 
        return Ok("Tenant Successfully Deleted");
    }

    [HttpGet("property/{username}")]
    public ActionResult<object> GetPropertyData(string username)
    {
        var Property = _dbContext.AddProperties.FirstOrDefault(x => x.username == username);

        if (Property == null)
        {
            return NotFound();
        }

        var newProperty = new AddProperties
        {
            property_id = Property.property_id,
            username = Property.username,
            Address = Property.Address,
            name = Property.name,
            description = Property.description,
            bedrooms = Property.bedrooms,
            bathrooms = Property.bathrooms,
            price = Property.price,
            squareFeet = Property.squareFeet,
            amenities = Property.amenities,
            leaseTerms = Property.leaseTerms,
            photo = Property.photo

        };

        return Ok(newProperty);
    }

    public void AddProperty(AddProperties Property)
    {
        try
        {
            var newProperty = new AddProperties
            {
                property_id = Property.property_id,
                username = Property.username,
                Address = Property.Address,
                name = Property.name,
                description = Property.description,
                bedrooms = Property.bedrooms,
                bathrooms = Property.bathrooms,
                price = Property.price,
                squareFeet = Property.squareFeet,
                amenities = Property.amenities,
                leaseTerms = Property.leaseTerms,
                photo = Property.photo
            };

            _dbContext.AddProperties.Add(newProperty);
            _dbContext.SaveChanges(); // Assuming SaveChanges is synchronous
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    [HttpPost("property/create")]
    public IActionResult CreateProperty(AddProperties input)
    {
        AddProperty(input);
        return Ok("Property successfully added");
    }
}
