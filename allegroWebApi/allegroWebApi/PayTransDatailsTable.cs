//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace allegroWebApi
{
    using System;
    using System.Collections.Generic;
    
    public partial class PayTransDatailsTable
    {
        public int ID { get; set; }
        public long payTransID { get; set; }
        public Nullable<long> itemID { get; set; }
        public Nullable<double> payTransDetailsPrice { get; set; }
        public Nullable<int> payTransDetailsCount { get; set; }
    
        public virtual MyIncomingPaymentsTable MyIncomingPaymentsTable { get; set; }
    }
}
