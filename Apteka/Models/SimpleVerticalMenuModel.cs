using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Apteka.Models
{
    public class SimpleVerticalMenuModel
    {
        public string Text { get; set; }
        public bool Active { get; set; }
        public List<MenuItemModel> MenuItems { get; set; }
    }
}