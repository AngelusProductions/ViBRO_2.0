using Microsoft.AspNetCore.Mvc;
using Vibro.API2.Data;
using Vibro.API2.Entities;

namespace Vibro.API2.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly DataContext _context;

    public UsersController(DataContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<IEnumerable<User>> GetUsers()
    {
        return _context.Users.ToList();
    }

    [HttpGet("{id}")]
    public ActionResult<User> GetUser(int id)
    {
        return _context.Users.Find(id);
    }
}
