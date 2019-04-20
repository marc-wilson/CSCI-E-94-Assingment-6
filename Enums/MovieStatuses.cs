using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HW6MovieSharing.Enums
{
	public enum MovieStatuses
	{
		Available,
		BarrowRequested,
		BarrowApproved,
		BarrowRejected,
		Barrowed,
		ReturnRequested,
		Returned,
		RequestCompleted
	}
}
