using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace ReturnOrderPortal.Models
{
    public class ProcessResponse
    {
        public int RequestId { get; set; }

        public double ProcessingCharge { get; set; }

        public double PackagingAndDeliveryCharge { get; set; }

        public DateTime DateOfDelivery { get; set; }
    }
}
