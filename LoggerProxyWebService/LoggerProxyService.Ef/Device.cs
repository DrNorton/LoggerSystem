//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LoggerProxyService.Ef
{
    using System;
    using System.Collections.Generic;
    
    public partial class Device
    {
        public Device()
        {
            this.Registrations = new HashSet<Registration>();
        }
    
        public int Id { get; set; }
        public string Guid { get; set; }
        public string Name { get; set; }
        public int PlatformId { get; set; }
        public string OsVersion { get; set; }
    
        public virtual Platform Platform { get; set; }
        public virtual ICollection<Registration> Registrations { get; set; }
    }
}
