using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace ReturnOrderPortal.Models
{
    
    public class ProcessResponse
    {
        [Key]
        public int RequestId { get; set; }

        public int ProcessingCharge { get; set; }

        public int PackagingAndDeliveryCharge { get; set; }

        public DateTime DateOfDelivery { get; set; }

    }
}
