//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Card
    {
        public int CardID { get; set; }
        public Nullable<int> ProductID { get; set; }
        public Nullable<System.DateTime> DateCreate { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<bool> Status { get; set; }
        public Nullable<decimal> TotalMoney { get; set; }
    
        public virtual Product Product { get; set; }
    }
}
