using System;
using System.Collections.Generic;

namespace CourierServices.Models
{
    public partial class History
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
        public int? ShipmentId { get; set; }

        public virtual Shipments Shipment { get; set; }
    }
}
