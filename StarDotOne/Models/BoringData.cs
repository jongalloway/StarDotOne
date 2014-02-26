using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StarDotOne.Models
{
    public class BoringData
    {
        public int Id { get; set; }
        public long DataLong { get; set; }
        public byte[] DataBytes { get; set; }
        public DateTime DataDate { get; set; }
    }
}