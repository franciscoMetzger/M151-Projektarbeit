//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Skivermietung.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Kategorie
    {
        public Kategorie()
        {
            this.Artikel = new HashSet<Artikel>();
        }
    
        public int ID_Kategorie { get; set; }
        public string Bezeichnung { get; set; }
    
        public virtual ICollection<Artikel> Artikel { get; set; }
    }
}
