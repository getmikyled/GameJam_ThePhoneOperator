namespace IvoryIcicles.SwitchboardInternals
{
	public enum ConnectionStatus
	{
		IDLE = 0,
		PENDING_OPERATOR_ANSWER = 1,
		ANSWERED_BY_OPERATOR = 2,
		PENDING_CONNECTION = 3,
		CONNECTED = 4
	}
}