//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Apteka
{
    using System;
    using System.Collections.Generic;
    
    public partial class t_CartItems
    {
        public int RecordId { get; set; }
        public string CartId { get; set; }
        public int Count { get; set; }
        public System.DateTime DateCreated { get; set; }
        public int ProduktId { get; set; }
    
        public virtual t_produkty t_produkty { get; set; }
    }
}
