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
    
    public partial class Kunde
    {
        public Kunde()
        {
            this.Vermietung = new HashSet<Vermietung>();
        }
    
        public int ID_Kunde { get; set; }
        public string Vorname { get; set; }
        public string Name { get; set; }
        public string TelefonNr { get; set; }
        public System.DateTime Geburtstag { get; set; }
    
        public virtual ICollection<Vermietung> Vermietung { get; set; }
    }
}
