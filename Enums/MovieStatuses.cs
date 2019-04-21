namespace HW6MovieSharing.Enums
{
	/// <summary>
	/// Movie and Request statuses
	/// </summary>
	public enum MovieStatuses
	{
		Available, // Movie is a available
		BarrowRequested, // Barrow request is submitted
		BarrowRejected, // Barrow request rejected
		Barrowed, // Movie is barrowed
		ReturnRequested, // Movie has been returned and is awaiting to marked as returned
		Returned, // Movie has been returned
		RequestCompleted // Barrow Request / Return Request completed
	}
}
