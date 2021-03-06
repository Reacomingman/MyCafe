//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyCafe_v1._5.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Menu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Menu()
        {
            this.Order_Detail = new HashSet<Order_Detail>();
        }
    
        public int Id { get; set; }
        [StringLength(50, ErrorMessage = "the length should be within 50 characters")]
        public string Name { get; set; }
        [Range(0, 2000, ErrorMessage = "the range is 0 to 2000")]
        public int Price { get; set; }
        public string Description { get; set; }
        public int EmployeeId { get; set; }
        [Required(ErrorMessage = "YYYY/MM/DD")]
        public System.DateTime MCreateTime { get; set; }
    
        public virtual Employee Employee { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order_Detail> Order_Detail { get; set; }
    }
}
