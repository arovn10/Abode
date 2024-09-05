﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Abode.Main;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abode.Tables; // Added for List<string>
using Abode.Models; // Assuming your DbContext is in this namespace


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
        var landlord = _dbContext.Landlords.FirstOrDefault(x => x.LandlordId == id);
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
            var newAccount = new Account
            {

                Email = Accounts.email,
                Username = Accounts.username,
                Password = Accounts.password,
                UserType = Accounts.userType,
                School = Accounts.school
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
            var newHome = new Home
            {
                PersonId = home.PersonID,
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
            .FirstOrDefault(acc => EF.Functions.Like(acc.Username, username));


        if (account == null)
        {
            return NotFound(new { message = "No account found with that username." });
        }


        return Ok(new {
            userId = account.UserId,
            email = account.Email,
            username = account.Username,
            password = account.Password,
            userType = account.UserType,
            school = account.School
        });
    }
[HttpGet("accounts/by-id/{userId}")]

public ActionResult<object> GetAccountById(int userId)
{
    var account = _dbContext.Accounts
        .FirstOrDefault(acc => acc.UserId == userId);

    if (account == null)
    {
        return NotFound(new { message = "No account found with that user ID." });
    }

    return Ok(new {
        userId = account.UserId,
        email = account.Email,
        username = account.Username,
        password = account.Password,
        userType = account.UserType,
        school = account.School
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
        var listing = _dbContext.RentalListings.FirstOrDefault(x => x.ListingId == id);


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
                ListingId = rental.ListingId,
                PropertyName = rental.PropertyName,
                MonthlyRent = rental.MonthlyRent,
                Address = rental.Address,
                AvailableDate = rental.AvailableDate
            };


            _dbContext.RentalListings.Add(newRental);
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
    public void AddTenant(Tenant tenant)
    {
        try
        {
            var newTenant = new Tenant
            {
                /*TenantId = tenant.TenantId,*/
                Username = tenant.Username,
                Name = tenant.Name,
                Email = tenant.Email,
                PhoneNumber = tenant.PhoneNumber,
                PropertyId = tenant.PropertyId,
                LeaseStartDate = tenant.LeaseStartDate,
                LeaseEndDate = tenant.LeaseEndDate,
                Status = tenant.Status,
              /*  LeaseStartDate = tenant.*/
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
    public IActionResult CreateTenant(Tenant input)
    {
        AddTenant(input);
        return Ok("Success");
    }


    [HttpGet("tenant/{id}")]
    public ActionResult<object> GetTenant(int id)
    {
        var tenant = _dbContext.Tenants
             /*           .Include(x => x.LeaseAgreements)  // Include related LeaseAgreements*/
            /*            .Include(x => x.Property)  // Include related Property*/
                        .FirstOrDefault(x => x.TenantId == id);
        if (tenant == null)
        {
            return NotFound();
        }
        var result = new
        {
            TenantId = tenant.TenantId,
            Username = tenant.Username,
            Name = tenant.Name,
            Email = tenant.Email,
            PhoneNumber = tenant.PhoneNumber,
            PropertyId = tenant.PropertyId,
            LeaseStartDate = tenant.LeaseStartDate,
            LeaseEndDate = tenant.LeaseEndDate,
            Status = tenant.Status,
          /*  LeaseAgreements = tenant.LeaseAgreements,
            Property = tenant.Property*/
        };
        return Ok(result);
    }


    [HttpDelete("deleteTenant/{id}")]
    public ActionResult<object> DeleteTenant(int id)
    {
        var tenant = _dbContext.Tenants.FirstOrDefault(x => x.TenantId == id);
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
        var properties = _dbContext.AddProperties.Where(p => p.Username == username).ToList();


        // Check if no properties were found
        if (!properties.Any())
        {
            return NotFound("No properties found for this user.");
        }


        // Return the list of properties
        return Ok(properties.Select(p => new
        {
            property_id = p.PropertyId,
            username = p.Username,
            Address = p.Address,
            name = p.Name,
            description = p.Description,
            bedrooms = p.Bedrooms,
            bathrooms = p.Bathrooms,
            price = p.Price,
            squareFeet = p.SquareFeet,
            amenities = p.Amenities,
            leaseTerms = p.LeaseTerms,
            photo = p.Photo,
            school = p.School
        }).ToList());
    }

    [HttpGet("propertyfromID/{id}")]
    public ActionResult<List<object>> GetPropertiesByPropertyID(int id)
    {
        // Fetch all properties that match the given username
        var properties = _dbContext.AddProperties.Where(p => p.PropertyId == id).ToList();


        // Check if no properties were found
        if (!properties.Any())
        {
            return NotFound("No properties found for this user.");
        }


        // Return the list of properties
        return Ok(properties.Select(p => new
        {
            property_id = p.PropertyId,
            username = p.Username,
            Address = p.Address,
            name = p.Name,
            description = p.Description,
            bedrooms = p.Bedrooms,
            bathrooms = p.Bathrooms,
            price = p.Price,
            squareFeet = p.SquareFeet,
            amenities = p.Amenities,
            leaseTerms = p.LeaseTerms,
            photo = p.Photo,
            school = p.School
        }).ToList());
    }
    public void AddProperty(AddProperty Property)
    {
        try
        {
            var newProperty = new AddProperty
            {
                PropertyId = Property.PropertyId,
                Username = Property.Username,
                Address = Property.Address,
                Name = Property.Name,
                Description = Property.Description,
                Bedrooms = Property.Bedrooms,
                Bathrooms = Property.Bathrooms,
                Price = Property.Price,
                SquareFeet = Property.SquareFeet,
                Amenities = Property.Amenities,
                LeaseTerms = Property.LeaseTerms,
                Photo = Property.Photo,
                School = Property.School
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
    public IActionResult CreateProperty(AddProperty input)
    {
        AddProperty(input);


        return Ok("Property successfully added");
    }


    [HttpDelete("deleteProperty/{id}")]
    public ActionResult<object> DeleteProperty(int id)
    {
        var property = _dbContext.AddProperties.FirstOrDefault(x => x.PropertyId == id);
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
        var property = _dbContext.AddProperties.FirstOrDefault(p => p.PropertyId == id);
        if (property == null)
        {
            return NotFound("Property not found");
        }


        property.Address = updatedProperty.Address;
        property.Amenities = updatedProperty.amenities;
        property.Bathrooms = updatedProperty.bathrooms;
        property.Bedrooms = updatedProperty.bedrooms;
        property.Description = updatedProperty.description;
        property.LeaseTerms = updatedProperty.leaseTerms;
        property.Name = updatedProperty.name;
        property.Photo = updatedProperty.photo;
        property.Price = updatedProperty.price;
        property.SquareFeet = updatedProperty.squareFeet;
        property.School = updatedProperty.school;



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
            property_id = p.PropertyId,
            username = p.Username,
            Address = p.Address,
            name = p.Name,
            description = p.Description,
            bedrooms = p.Bedrooms,
            bathrooms = p.Bathrooms,
            price = p.Price,
            squareFeet = p.SquareFeet,
            amenities = p.Amenities,
            leaseTerms = p.LeaseTerms,
            photo = p.Photo,
            school = p.School
        }).ToList());
    }

    [HttpGet("getMessages/{username}")]
    public ActionResult<object> GetMessages(string username)
    {
     /*   var accountType = _dbContext.Accounts
            .Where(x => x.Username == username)
            .Select(x => x.UserType).FirstOrDefault();

        if (accountType == null)
        {
            return NotFound();
        }
*/
        var data = new Dictionary<string, object>();


        var chats = _dbContext.Messages
            .Where(x => x.Sender == username)
            .Select(message => new
            {
                property_id = message.PropertyId,
                messages = message.Messages,
                dateTime = message.DateTime,
                MessageID = message.MessageId,
                senderUsername = message.Sender,
                sendeeUsername = message.Sendee
            })
            .ToList();

        data.Add("chats as sender", chats);

        var chatstwo = _dbContext.Messages
                .Where(x => x.Sendee == username)
                .Select(message => new
                {
                    property_id = message.PropertyId,
                    messages = message.Messages,
                    dateTime = message.DateTime,
                    MessageID = message.MessageId,
                    senderUsername = message.Sender,
                    sendeeUsername = message.Sendee
                })
                .ToList();

        data.Add("chats as sendee", chatstwo);



        return Ok(data);
    }

    [HttpDelete("deleteMessages/{propertyID}")]
    public ActionResult<object> DeleteMessages(int propertyID)
    {
        var messages = _dbContext.Messages.Where(x => x.PropertyId == propertyID).ToList();
        if (!messages.Any())
        {
            return NotFound();
        }
        _dbContext.Messages.RemoveRange(messages);
        _dbContext.SaveChanges();
        return Ok("Messages Successfully Deleted");
    }

    [HttpPost("PostMessage/{sendeeUsername}/{property_id}/{message}/{senderUsername}")]
    public ActionResult<object> PostMessage(string sendeeUsername, string senderUsername, int property_id, string message)
    {
        

        
            var chat = new Message
            {
                PropertyId = property_id,
                Messages = message,
                DateTime = DateTime.Now,
                Sendee = senderUsername,
                Sender = sendeeUsername

            };

            _dbContext.Messages.Add(chat);
            _dbContext.SaveChanges();
            return Ok("New chat created and message posted successfully");
        

        
    }

    [HttpPut("username/update/{id}")]
    public IActionResult UpdateUsername(int id, Accounts updatedUsername)
    {
        var username = _dbContext.Accounts.FirstOrDefault(p => p.UserId == id);
        if (username == null)
        {
            return NotFound("Username not found");
        }


        username.Username = updatedUsername.username;
        

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
        var password = _dbContext.Accounts.FirstOrDefault(p => p.UserId == id);
        if (password == null)
        {
            return NotFound("Username not found");
        }


        password.Password = updatedPassword.password;


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
        var email = _dbContext.Accounts.FirstOrDefault(p => p.UserId == id);
        if (email == null)
        {
            return NotFound("Email not found");
        }


        email.Email = updatedEmail.email;


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

    [HttpGet("chat/{id}")]
    public ActionResult<object> GetChat(int id)
    {
        var chat = _dbContext.Messages.FirstOrDefault(x => x.MessageId == id);


        if (chat == null)
        {
            return NotFound();
        }


        var result = new
        {
            messages = chat.Messages,
            dateTime = chat.DateTime,
            propertyID = chat.PropertyId,
            MessageID = chat.MessageId,
 /*           senderUsername = chat.senderUsername,
            sendeeUsername = chat.sendeeUsername*/
        };
        return Ok(result);
    }

  
    //not working rn
    
    public void AddAmenities(Amenity amenities)
    {
        try
        {
            var a = new Amenity
            {
                FullyFurnished = amenities.FullyFurnished,
                Pool = amenities.Pool,
                PowderRoom = amenities.PowderRoom,
                Driveway = amenities.Driveway,
                LaundryUnit = amenities.LaundryUnit,
                CentralAc = amenities.CentralAc,
                Backyard = amenities.Backyard,
                Fireplace = amenities.Fireplace,
                PetFriendly = amenities.PetFriendly,
                PropertyId = amenities.PropertyId


            };


            _dbContext.Amenities.Add(a);
            _dbContext.SaveChanges();
        }
        catch (Exception ex)
        {
            throw;
        }
    }


    [HttpPost("amenities/create")]
    public IActionResult CreateAmenities(Amenity input)
    {
        AddAmenities(input);
        return Ok("Success");
    }

    [HttpPut("PostChat/{senderUsername}/{MessageID}/{message}")]
    public ActionResult<object> PostChat(string senderUsername, int MessageID, string message)
    {
        /*find if chat between landlord and student or landlord and tenant exists
        var chat = _dbContext.Messages.FirstOrDefault(x => x.propertID == landlordUsername &&
                                                     (x.tenantUsername == username || x.studentUsername == username));
        */

        //find landlord from propertyid
        var chat = _dbContext.Messages
           .Where(p => p.MessageId == MessageID)
           .FirstOrDefault();

        if (chat == null)
        {
            return BadRequest();
        }

        chat.Messages = message;
/*        chat.senderUsername = senderUsername;*/

        _dbContext.SaveChanges();
        return Ok("New chat posted");
    }

}










