using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Apteka.ViewModels
{
    public class ShoppingCartViewModel
    {
        public List<t_CartItems> CartItems { get; set; }
        public decimal CartTotal { get; set; }
        public int CartTotalNumber { get; set; }
        public IEnumerable<t_produkty> Products { get; set; }
        public t_users User { get; set; }
    }
}