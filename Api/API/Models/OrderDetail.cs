//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace API.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class OrderDetail
    {
        public int DetailID { get; set; }
        public Nullable<int> DetailOrderID { get; set; }
        public Nullable<int> DetailProductID { get; set; }
        public string DetailName { get; set; }
        public Nullable<double> DetailPrice { get; set; }
        public Nullable<int> DetailQuantity { get; set; }
    
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}