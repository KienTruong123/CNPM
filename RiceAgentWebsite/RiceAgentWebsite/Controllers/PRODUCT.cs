//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RiceAgentWebsite.Controllers
{
    using System;
    using System.Collections.Generic;
    
    public partial class PRODUCT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PRODUCT()
        {
            this.BILL_PRODUCTS = new HashSet<BILL_PRODUCTS>();
            this.CART = new HashSet<CART>();
            this.PRODUCT_TYPE = new HashSet<PRODUCT_TYPE>();
        }
    
        public int PRODUCTID { get; set; }
        public string PRODUCT_NAME { get; set; }
        public Nullable<int> QUANTITY { get; set; }
        public Nullable<int> PRICE { get; set; }
        public string BRAND { get; set; }
        public Nullable<int> WEIGHT { get; set; }
        public string COUNTRY { get; set; }
        public string IMG_PATH { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BILL_PRODUCTS> BILL_PRODUCTS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CART> CART { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PRODUCT_TYPE> PRODUCT_TYPE { get; set; }
    }
}