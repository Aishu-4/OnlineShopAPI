using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace OnlineShopAPI.Models
{
    public partial class TblCompare
    {
        public int Id { get; set; }
        public int? ProductId { get; set; }
        public string Useremail { get; set; }

        public virtual TblProduct Product { get; set; }
        public virtual TblUser UseremailNavigation { get; set; }
    }
}
