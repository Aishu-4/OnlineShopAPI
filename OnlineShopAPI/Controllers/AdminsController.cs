using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShopAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminsController : ControllerBase
    {
        private readonly OnlineShopDBContext _context;
        public AdminsController(OnlineShopDBContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Admins);
        }


        [HttpPost("AdminLogin")]
        public IActionResult AdminLogin(Admins admin)
        {
            var result = _context.Admins.Where(u => u.Email == admin.Email && u.Password == admin.Password).FirstOrDefault();
            if (result != null)
            {
                return Ok(new { status = "successful" });
            }
            return Ok(new { status = "unsuccessful" });
        }
    }
}
