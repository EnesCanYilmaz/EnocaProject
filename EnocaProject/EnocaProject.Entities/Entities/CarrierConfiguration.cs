using System;
using EnocaProject.Entities.Entities.Common;

namespace EnocaProject.Entities.Entities
{
	public class CarrierConfiguration : BaseEntity
	{
		public int CarrierMaxDesi { get; set; }
		public int CarrierMinDesi { get; set; }
		public decimal CarrierCost { get; set; }
        public int CarrierId { get; set; }
    }
}

