using System;
using EnocaProject.Entities.Entities.Common;

namespace EnocaProject.Entities.Entities
{
	public class Order : BaseEntity
	{
		public int OrderDesi { get; set; }
		public DateTime OrderDate { get; set; }
		public decimal OrderCarrierCost { get; set; }
        public int CarrierId { get; set; }
    }
}

