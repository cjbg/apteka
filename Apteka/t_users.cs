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
    
    public partial class t_users
    {
        public t_users()
        {
            this.t_sklepy = new HashSet<t_sklepy>();
            this.t_zamowienia = new HashSet<t_zamowienia>();
        }
    
        public int Id { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Login { get; set; }
        public string Haslo { get; set; }
        public string email { get; set; }
        public string Ulica { get; set; }
        public string Miasto { get; set; }
        public string KodPocztowy { get; set; }
        public bool Admin { get; set; }
    
        public virtual ICollection<t_sklepy> t_sklepy { get; set; }
        public virtual ICollection<t_zamowienia> t_zamowienia { get; set; }
    }
}