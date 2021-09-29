using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShopAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;




using System.Threading.Tasks;

namespace OnlineShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly OnlineShopDBContext _context;
        public  UserController(OnlineShopDBContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.TblUser);
        }
        
       
        [HttpPost("UserLogin")]
        public IActionResult UserLogin(TblUser user)
        {
            var result = _context.TblUser.Where(u => u.Useremail == user.Useremail && u.Userpassword == user.Userpassword).FirstOrDefault();
            if (result != null)
            {
                return Ok(new { status = "successful" });
            }
            return Ok(new { status = "unsuccessful" });
        }
        [HttpPost("AddUser")]
        public IActionResult AddUser(TblUser user)
        {
            var existUser = _context.TblUser.Find(user.Useremail);
            if (existUser ==null)
            {
                _context.TblUser.Add(user);
                _context.SaveChanges();
                return Ok(new { status = "successful" });
            }
            else
            {
                return Ok(new { status = "unsuccessful" });
            }
        }



    }
}
