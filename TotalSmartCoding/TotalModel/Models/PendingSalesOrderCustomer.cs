//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TotalModel.Models
{
    using System;
    
    public partial class PendingSalesOrderCustomer
    {
        public int CustomerID { get; set; }
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public string ContactInfo { get; set; }
        public string ShippingAddress { get; set; }
        public Nullable<int> SalespersonID { get; set; }
        public int ReceiverID { get; set; }
        public string ReceiverCode { get; set; }
        public string ReceiverName { get; set; }
    }
}
