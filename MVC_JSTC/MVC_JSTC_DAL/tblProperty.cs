//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVC_JSTC_DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblProperty
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblProperty()
        {
            this.tblPropertyValues = new HashSet<tblPropertyValue>();
        }
    
        public int Property_Id { get; set; }
        public string Property_Name { get; set; }
        public Nullable<bool> Property_isType { get; set; }
        public Nullable<bool> Property_isTechSpec { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblPropertyValue> tblPropertyValues { get; set; }
    }
}