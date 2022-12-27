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
    
    public partial class Route
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Route()
        {
            this.Stop_Route = new HashSet<Stop_Route>();
        }
    
        public int RouteID { get; set; }
        public int BusRoutesID { get; set; }
        public int StartPositionID { get; set; }
        public int EndPositionID { get; set; }
        public string RouteName { get; set; }
        public int RouteAmount { get; set; }
        public System.TimeSpan RouteTime { get; set; }
        public System.DateTime StartTime { get; set; }
        public System.DateTime EndTime { get; set; }
        public System.DateTime ApplicableDate { get; set; }
        public System.DateTime OperationDate { get; set; }
    
        public virtual BusStop BusStop { get; set; }
        public virtual BusStop BusStop1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Stop_Route> Stop_Route { get; set; }
        public virtual BusRoute BusRoute { get; set; }
    }
}
