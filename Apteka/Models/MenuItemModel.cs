using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Apteka.Models
{
    public class MenuItemModel
    {
        public string Controller { get; set; }
        public string Action { get; set; }
        public string Text { get; set; }
        public bool Selected { get; set; }
    }
}