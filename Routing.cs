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


    [HttpGet("accounts/{username}")]
    public ActionResult<object> GetAccountByUsername(string username)
    {
        var account = _dbContext.Accounts
            .FirstOrDefault(acc => EF.Functions.Like(acc.username, username));


        if (account == null)
        {
            return NotFound(new { message = "No account found with that username." });
        }


        return Ok(new {
            userId = account.userId,
            email = account.email,
            username = account.username,
            password = account.password,
            userType = account.userType,
            school = account.school
        });
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
    public ActionResult<List<object>> GetPropertiesByUsername(string username)
    {
        // Fetch all properties that match the given username
        var properties = _dbContext.AddProperties.Where(p => p.username == username).ToList();


        // Check if no properties were found
        if (!properties.Any())
        {
            return NotFound("No properties found for this user.");
        }


        // Return the list of properties
        return Ok(properties.Select(p => new
        {
            property_id = p.property_id,
            username = p.username,
            Address = p.Address,
            name = p.name,
            description = p.description,
            bedrooms = p.bedrooms,
            bathrooms = p.bathrooms,
            price = p.price,
            squareFeet = p.squareFeet,
            amenities = p.amenities,
            leaseTerms = p.leaseTerms,
            photo = p.photo,
            school = p.school
        }).ToList());
    }

    [HttpGet("propertyfromID/{id}")]
    public ActionResult<List<object>> GetPropertiesByPropertyID(int id)
    {
        // Fetch all properties that match the given username
        var properties = _dbContext.AddProperties.Where(p => p.property_id == id).ToList();


        // Check if no properties were found
        if (!properties.Any())
        {
            return NotFound("No properties found for this user.");
        }


        // Return the list of properties
        return Ok(properties.Select(p => new
        {
            property_id = p.property_id,
            username = p.username,
            Address = p.Address,
            name = p.name,
            description = p.description,
            bedrooms = p.bedrooms,
            bathrooms = p.bathrooms,
            price = p.price,
            squareFeet = p.squareFeet,
            amenities = p.amenities,
            leaseTerms = p.leaseTerms,
            photo = p.photo,
            school = p.school
        }).ToList());
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
                photo = Property.photo,
                school = Property.school
            };


            _dbContext.AddProperties.Add(newProperty);
            _dbContext.SaveChanges(); // Assuming SaveChanges is synchronous
        }
        catch (Exception ex)
        {
            // Better error handling: Log this exception or throw a more informative error
            throw new Exception("Failed to add property: " + ex.Message);
        }
    }

    [HttpPost("property/create")]
    public IActionResult CreateProperty(AddProperties input)
    {
        AddProperty(input);


        return Ok("Property successfully added");
    }


    [HttpDelete("deleteProperty/{id}")]
    public ActionResult<object> DeleteProperty(int id)
    {
        var property = _dbContext.AddProperties.FirstOrDefault(x => x.property_id == id);
        if (property == null)
        {
            return NotFound();
        }
        _dbContext.AddProperties.Remove(property);
        _dbContext.SaveChanges();
        return Ok("Property Successfully Deleted");
    }


    [HttpPut("property/update/{id}")]
    public IActionResult UpdateProperty(int id, AddProperties updatedProperty)
    {
        var property = _dbContext.AddProperties.FirstOrDefault(p => p.property_id == id);
        if (property == null)
        {
            return NotFound("Property not found");
        }


        property.Address = updatedProperty.Address;
        property.amenities = updatedProperty.amenities;
        property.bathrooms = updatedProperty.bathrooms;
        property.bedrooms = updatedProperty.bedrooms;
        property.description = updatedProperty.description;
        property.leaseTerms = updatedProperty.leaseTerms;
        property.name = updatedProperty.name;
        property.photo = updatedProperty.photo;
        property.price = updatedProperty.price;
        property.squareFeet = updatedProperty.squareFeet;
        property.school = updatedProperty.school;



        try
        {
            _dbContext.SaveChanges();
            return Ok("Property updated successfully");
        }
        catch (DbUpdateException ex)
        {
            // Log the error
            Console.WriteLine(ex.InnerException?.Message);
            return BadRequest("Failed to update property: " + ex.InnerException?.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return BadRequest("An error occurred while updating the property: " + ex.Message);
        }
    }

    [HttpGet("properties")]
    public ActionResult<List<object>> GetAllProperties()
    {
        // Fetch all properties
        var properties = _dbContext.AddProperties.ToList();

        // Check if properties list is empty
        if (!properties.Any())
        {
            return NotFound("No properties found.");
        }

        // Return the list of properties mapped to desired structure
        return Ok(properties.Select(p => new
        {
            property_id = p.property_id,
            username = p.username,
            Address = p.Address,
            name = p.name,
            description = p.description,
            bedrooms = p.bedrooms,
            bathrooms = p.bathrooms,
            price = p.price,
            squareFeet = p.squareFeet,
            amenities = p.amenities,
            leaseTerms = p.leaseTerms,
            photo = p.photo,
            school = p.school
        }).ToList());
    }

    [HttpGet("getMessages/{username}")]
    public ActionResult<object> GetMessages(string username)
    {
        var accountType = _dbContext.Accounts
            .Where(x => x.username == username)
            .Select(x => x.userType).FirstOrDefault();

        if (accountType == null)
        {
            return NotFound();
        }

        var data = new Dictionary<string, object>();

        if (accountType == "Student")
        {
            var chats = _dbContext.Messages
                .Where(x => x.studentUsername == username)
                .Select(message => new
                {
                    property_id = message.propertyID,
                    landlordUsername = message.landlordUsername,
                    messages = message.messages,
                    dateTime = message.dateTime,
                    studentUsername = message.studentUsername,
                })
                .ToList();

            var leadsString = "leads";
            data.Add(leadsString, chats);

            var chatstwo = _dbContext.Messages
                .Where(x => x.tenantUsername == username)
                .Select(message => new
                {
                    property_id = message.propertyID,
                    landlordUsername = message.landlordUsername,
                    messages = message.messages,
                    dateTime = message.dateTime,
                    tenantUsername = message.tenantUsername,
                })
                .ToList();

            var tenantsString = "tenants";
            data.Add(tenantsString, chatstwo);
        }
    
        return Ok(data);
    }
        

    [HttpPost("PostStudentInquiry/{username}/{property_id}/{message}")]
    public ActionResult<object> PostMessage(string username, int property_id, string message)
    {
        /*find if chat between landlord and student or landlord and tenant exists
        var chat = _dbContext.Messages.FirstOrDefault(x => x.propertID == landlordUsername &&
                                                     (x.tenantUsername == username || x.studentUsername == username));
        */


        //find landlord from propertyid
        var landlord = _dbContext.AddProperties
           .Where(p => p.property_id == property_id)
           .Select(p => p.username).FirstOrDefault();

        if (landlord != null) {
            var chat = new Messages
            {
                propertyID = property_id,
                landlordUsername = landlord,
                messages = message,
                dateTime = DateTime.Now,
                studentUsername = username,
                
            };

            _dbContext.Messages.Add(chat);
            _dbContext.SaveChanges();
            return Ok("New chat created and message posted successfully");
        }

        else
        {
            return BadRequest();
        }
    }

    [HttpPost("PostTenantMessage/{username}/{property_id}/{message}")]
    public ActionResult<object> PostTenantMessage(string username, int property_id, string message)
    {
        /*find if chat between landlord and student or landlord and tenant exists
        var chat = _dbContext.Messages.FirstOrDefault(x => x.propertID == landlordUsername &&
                                                     (x.tenantUsername == username || x.studentUsername == username));
        */


        //find landlord from propertyid
        var landlord = _dbContext.AddProperties
           .Where(p => p.property_id == property_id)
           .Select(p => p.username).FirstOrDefault();

        if (landlord != null)
        {
            var chat = new Messages
            {
                propertyID = property_id,
                landlordUsername = landlord,
                messages = message,
               // dateTime = DateTime.Now,
                tenantUsername = username,

            };

            _dbContext.Messages.Add(chat);
            _dbContext.SaveChanges();
            return Ok("New chat created and message posted successfully");
        }

        else
        {
            return BadRequest();
        }
    }

    [HttpPut("username/update/{id}")]
    public IActionResult UpdateUsername(int id, Accounts updatedUsername)
    {
        var username = _dbContext.Accounts.FirstOrDefault(p => p.userId == id);
        if (username == null)
        {
            return NotFound("Username not found");
        }


        username.username = updatedUsername.username;
        

        try
        {
            _dbContext.SaveChanges();
            return Ok("Username updated successfully");
        }
        catch (DbUpdateException ex)
        {
            // Log the error
            Console.WriteLine(ex.InnerException?.Message);
            return BadRequest("Failed to update username: " + ex.InnerException?.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return BadRequest("An error occurred while updating the username: " + ex.Message);
        }
    }

    [HttpPut("password/update/{id}")]
    public IActionResult UpdatePassword(int id, Accounts updatedPassword)
    {
        var password = _dbContext.Accounts.FirstOrDefault(p => p.userId == id);
        if (password == null)
        {
            return NotFound("Username not found");
        }


        password.password = updatedPassword.password;


        try
        {
            _dbContext.SaveChanges();
            return Ok("password updated successfully");
        }
        catch (DbUpdateException ex)
        {
            // Log the error
            Console.WriteLine(ex.InnerException?.Message);
            return BadRequest("Failed to update password: " + ex.InnerException?.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return BadRequest("An error occurred while updating the password: " + ex.Message);
        }
    }

    [HttpPut("email/update/{id}")]
    public IActionResult UpdateEmail(int id, Accounts updatedEmail)
    {
        var email = _dbContext.Accounts.FirstOrDefault(p => p.userId == id);
        if (email == null)
        {
            return NotFound("Email not found");
        }


        email.email = updatedEmail.email;


        try
        {
            _dbContext.SaveChanges();
            return Ok("email updated successfully");
        }
        catch (DbUpdateException ex)
        {
            // Log the error
            Console.WriteLine(ex.InnerException?.Message);
            return BadRequest("Failed to update password: " + ex.InnerException?.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return BadRequest("An error occurred while updating the email: " + ex.Message);
        }
    }

}









