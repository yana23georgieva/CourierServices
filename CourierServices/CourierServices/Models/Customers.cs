using System;
using System.Collections.Generic;

namespace CourierServices.Models
{
    public partial class Customers
    {
        public Customers()
        {
            ShipmentsReceiverNavigation = new HashSet<Shipments>();
            ShipmentsSenderNavigation = new HashSet<Shipments>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public int? ShipmentNumber { get; set; }

        public virtual Shipments ShipmentNumberNavigation { get; set; }
        public virtual ICollection<Shipments> ShipmentsReceiverNavigation { get; set; }
        public virtual ICollection<Shipments> ShipmentsSenderNavigation { get; set; }
    }
}
