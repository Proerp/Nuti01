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
    
    public partial class SalesOrderViewDetail
    {
        public int SalesOrderDetailID { get; set; }
        public int SalesOrderID { get; set; }
        public int CommodityID { get; set; }
        public string CommodityCode { get; set; }
        public string CommodityName { get; set; }
        public decimal Quantity { get; set; }
        public decimal Volume { get; set; }
        public string Remarks { get; set; }
        public string Unit { get; set; }
        public string PackageSize { get; set; }
        public decimal PackageVolume { get; set; }
        public decimal LineVolume { get; set; }
        public decimal QuantityAvailable { get; set; }
        public decimal LineVolumeAvailable { get; set; }
    }
}
