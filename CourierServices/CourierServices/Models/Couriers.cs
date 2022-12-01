using System;
using System.Collections.Generic;

namespace CourierServices.Models
{
    public partial class Couriers
    {
        public Couriers()
        {
            Shipments = new HashSet<Shipments>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JobPossition { get; set; }
        public string PhoneNumber { get; set; }

        public virtual ICollection<Shipments> Shipments { get; set; }
    }
}
