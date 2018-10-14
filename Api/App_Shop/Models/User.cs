//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace App_Shop.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            this.Orders = new HashSet<Order>();
        }
    
        public int UserID { get; set; }
        public string UserLastName { get; set; }
        public string UserFirstName { get; set; }
        public Nullable<int> UserPhone { get; set; }
        public string UserAddress { get; set; }
        public string Account { get; set; }
        public string Password { get; set; }
        public Nullable<int> AMDI { get; set; }
    
        public virtual AccessManagement AccessManagement { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }
    }
}