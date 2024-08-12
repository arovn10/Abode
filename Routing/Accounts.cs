/*using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Abode.Main;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abode.Tables; // Added for List<string>


[Route("api/accounts")]
public class AccountsController : ControllerBase
{
    private readonly AbodeDbContext _dbContext;
    public AccountsController(AbodeDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet("test")]
    public ActionResult<List<string>> Test()
    {
        return Ok(new List<string> { "hi" });
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
}*/