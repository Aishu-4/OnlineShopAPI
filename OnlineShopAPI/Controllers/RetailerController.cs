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
    public class RetailerController : ControllerBase
    {
        private readonly OnlineShopDBContext _context;
        public RetailerController(OnlineShopDBContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.TblRetailer);
        }
        [HttpPost("RetailerLogin")]
        public IActionResult ReatailerLogin(TblRetailer retailer)
        {
            var result = _context.TblRetailer.Where(u => u.Retaileremail == retailer.Retaileremail && u.Retailerpassword == retailer.Retailerpassword).FirstOrDefault();
            if (result != null)
            {
                return Ok(new { status = "successful" });
            }
            return Ok(new { status = "unsuccessful" });
        }

        [HttpPost("RetailerRegister")]

        public IActionResult RetailerRegister(TblRetailer retailer)
        {
            try
            {
                retailer = new TblRetailer()
                {
                    Retailername ="Aishwarya R",
                    Retaileremail = "Aishu@gmail.com",
                    Retailerpassword = "Aish1",
                    MobNo = 4355876923,
                    Gst = retailer.Gst,
                    Aadhar = retailer.Aadhar,
                    Pan = retailer.Pan,
                    CompanyDetails = retailer.CompanyDetails,
                    UserTypeId = 1001,
                    Approved = "pending"

                };

                _context.TblRetailer.Add(retailer);
                _context.SaveChanges();
                return Ok(new { status = "successful" });
            }
            catch (Exception e)
            {
                return Ok(new { status = "unsuccessful" });
            }





        }
    }
}
