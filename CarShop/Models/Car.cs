//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CarShop.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Car
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Preview { get; set; }
        public string SubPreview { get; set; }
        public string Type { get; set; }
        public Nullable<int> Count { get; set; }
        public Nullable<int> Price { get; set; }
    }
}
