using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Apteka.Models
{
    public class AptekaContext : DbContext
    {
        public DbSet<CartItemModel> t_CartItems { get; set; }
    }
}