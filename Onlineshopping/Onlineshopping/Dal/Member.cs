//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Onlineshopping.Dal
{
    using System;
    using System.Collections.Generic;
    
    public partial class Member
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Member()
        {
            this.shippingdetails = new HashSet<shippingdetail>();
        }
    
        public int memberid { get; set; }
        public string Firstname { get; set; }
        public string lastname { get; set; }
        public string Emailid { get; set; }
        public string password { get; set; }
        public Nullable<bool> Isactive { get; set; }
        public Nullable<bool> Isdelete { get; set; }
        public Nullable<System.DateTime> createdon { get; set; }
        public Nullable<System.DateTime> modifiedon { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<shippingdetail> shippingdetails { get; set; }
    }
}