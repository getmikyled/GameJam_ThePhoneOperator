namespace IvoryIcicles
{
	public enum CallStatus
	{
		IDLE, AWAITING_OPERATOR, AWAITING_RECEPTOR, ON_GOING, FINISHED
	}

	public class Call
	{
		public int emisorId { get; private set; }
		public int receptorId { get; private set; }

		public bool emisorConnected = false;
		public bool receptorConnected = false;
		public bool operatorConnected = false;
		
		public bool started = false;
		public bool operatorAnswered = false;
		public bool receptorAnswered = false;

		public bool emisorHangUp = false;
		public bool receptorHangUp = false;
		
		public CallStatus status
		{
			get
			{
				if (!started)
					return CallStatus.IDLE;
				if (!operatorAnswered)
					return CallStatus.AWAITING_OPERATOR;
				if (!receptorAnswered)
					return CallStatus.AWAITING_RECEPTOR;
				if (emisorConnected && receptorConnected)
					return CallStatus.ON_GOING;
				if (emisorHangUp && receptorHangUp)
					return CallStatus.FINISHED;
				else
					return CallStatus.ON_GOING;
			}
		}

		public Call(int emisorId, int receptorId)
		{
			this.emisorId = emisorId;
			this.receptorId = receptorId;
		}
	}
}