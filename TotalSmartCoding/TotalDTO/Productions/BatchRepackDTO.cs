using System;

using TotalBase;

namespace TotalDTO.Productions
{
    public class BatchRepackDTO: BaseDTO
    {
        public int PackID { get; set; }
        public int BatchID { get; set; }
        public DateTime BatchEntryDate { get; set; }
        public string BatchCode { get; set; }
        public string LotCode { get; set; }
        public int FillingLineID { get; set; }
        public string APICode { get; set; }
        public int PrintedTimes { get; set; }
    }
}
