//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BusinessLayer.DBAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class Stop_Route
    {
        public int StopRouteID { get; set; }
        public int RouteID { get; set; }
        public int EndPositionID { get; set; }
        public int Order { get; set; }
    
        public virtual BusStop BusStop { get; set; }
        public virtual Route Route { get; set; }
    }
}
