using System;
using System.Collections.Generic;
using System.Text;

namespace APIAutomation.Models
{
    internal class BrandListResponse
    {
        public int ResponseCode { get; set; }
        public List<Brands> Brands { get; set; }
    }
}
