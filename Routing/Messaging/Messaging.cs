/*using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Abode.Main;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abode.Tables; // Added for List<string>


[Route("api/messaging")]
public class MessagingController : ControllerBase
{
    private readonly AbodeDbContext _dbContext; 
    public MessagingController(AbodeDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    [HttpGet("test")]
    public ActionResult<List<string>> Test()
    {
        return Ok(new List<string> { "hi" });
    }
}*/