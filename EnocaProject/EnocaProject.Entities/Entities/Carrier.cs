using System;
using EnocaProject.Entities.Entities.Common;

namespace EnocaProject.Entities.Entities
{
	public class Carrier : BaseEntity
	{
		public string CarrierName { get; set; }
		public bool CarrierIsActive { get; set; }
		public int CarrierPlusDesiCost { get; set; }
		public ICollection<CarrierConfiguration> CarrierConfigurations { get; set; }
	}
}

