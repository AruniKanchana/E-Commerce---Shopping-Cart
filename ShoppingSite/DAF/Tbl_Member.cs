//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ShoppingSite.DAF
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tbl_Member
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tbl_Member()
        {
            this.Tbl_MemberRole = new HashSet<Tbl_MemberRole>();
            this.Tbl_ShippingDetails = new HashSet<Tbl_ShippingDetails>();
        }
    
        public int MemberId { get; set; }
        public string Firstname { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> IsDelete { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_MemberRole> Tbl_MemberRole { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_ShippingDetails> Tbl_ShippingDetails { get; set; }
    }
}
