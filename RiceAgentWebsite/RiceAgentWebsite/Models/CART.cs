//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RiceAgentWebsite.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CART
    {
        public string USERNAME { get; set; }
        public int PRODUCTID { get; set; }
        public Nullable<int> QUANTITY { get; set; }
    
        public virtual ACCOUNT ACCOUNT { get; set; }
        public virtual PRODUCT PRODUCT { get; set; }
    }
}