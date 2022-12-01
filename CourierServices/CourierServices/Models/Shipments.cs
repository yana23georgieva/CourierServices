using System;
using System.Collections.Generic;

namespace CourierServices.Models
{
    public partial class Shipments
    {
        public Shipments()
        {
            Customers = new HashSet<Customers>();
            History = new HashSet<History>();
        }

        public int Id { get; set; }
        public decimal? Weight { get; set; }
        public string FromAddress { get; set; }
        public string ToAddress { get; set; }
        public int? Sender { get; set; }
        public int? Receiver { get; set; }
        public decimal Price { get; set; }
        public int? CourierId { get; set; }

        public virtual Couriers Courier { get; set; }
        public virtual Customers ReceiverNavigation { get; set; }
        public virtual Customers SenderNavigation { get; set; }
        public virtual ICollection<Customers> Customers { get; set; }
        public virtual ICollection<History> History { get; set; }
    }
}
